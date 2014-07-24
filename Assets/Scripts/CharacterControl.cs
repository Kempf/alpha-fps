using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	//Look controls
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
	public int MaxY = 90;
	public int MinY = -70;
	public float RotX = 0f;
	public float RotY = 0f;
	public int RotZ;
	public int MaxZ = 40;

	//Movement Controls
	public int onGround;
	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public float jumpHeight = 2.0f;
	public int PKJump = 5000;
	
	void Awake () {
		lastSynchronizationTime = Time.time;
	}

	// network sync
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting) {
			syncPosition = rigidbody.position;
			stream.Serialize(ref syncPosition);
			syncPosition = rigidbody.velocity;
			stream.Serialize(ref syncVelocity);
        	} else {
            		stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);

			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;

			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = rigidbody.position;
		}
	}

	private void SyncedMovement() {
		syncTime += Time.deltaTime;

		rigidbody.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}

	// player control function
	private void InputMovement () {

	  if (Input.GetKey ("escape"))
			Screen.lockCursor = true; 

	//Lean function
	if (Input.GetButton ("Lean Left")) {
		if (RotZ < MaxZ) {
			RotZ += 5;
	  }
	} else if (Input.GetButton ("Lean Right")) {
		if (RotZ > -MaxZ) {
			RotZ -= 5;
		}
	} else if (RotZ > 0) {
		  RotZ -= 5;
	} else if (RotZ < 0) {
		  RotZ += 5;
	}

	//Raycasts for testing
	Debug.DrawRay (transform.position, Vector3.down, Color.red);
	Debug.DrawRay (transform.position, transform.TransformDirection (0, -1, 0), Color.red);
	
	//X Rotation
	RotX += Input.GetAxis ("Mouse X") * sensitivityX;
	transform.localEulerAngles = new Vector3 (0, RotX, transform.localEulerAngles.x);

	//Y Rotation
	RotY += Input.GetAxis ("Mouse Y") * sensitivityY;
	RotY = Mathf.Clamp (RotY, MinY, MaxY);
	transform.localEulerAngles = new Vector3 (-RotY, transform.localEulerAngles.y, RotZ);

	//- Movement Controls ----------------------------------//
	//Check onGround state
	if (onGround != 3) {
		if (Physics.Raycast (transform.position, Vector3.down, 1.5f)) 
			onGround = 1;
		else if (Physics.Raycast (transform.position, transform.TransformDirection (0, -1, 0), 1.5f))
			onGround = 2;
		else
			onGround = 0;
	}

	//Movement while on the ground (onGround == 1)
	if (onGround == 1) {
	  // Calculate how fast we should be moving
		Vector3 targetVelocity = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		targetVelocity = transform.TransformDirection (targetVelocity);
		targetVelocity *= speed;

		// Apply a force that attempts to reach our target velocity
		Vector3 velocity = rigidbody.velocity;
		Vector3 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
		rigidbody.AddForce (velocityChange, ForceMode.VelocityChange);
	}

	//General non flying scripts
	if (onGround > 0) {
		//Crouching onGround state
		if (Input.GetButton ("Crouch"))
			onGround = 3;
		else
			onGround = 0;
		//If onGround is 1 or 2
		if (onGround != 3) {
			//Jumping
			if (Input.GetButton ("Jump")) {
				rigidbody.AddRelativeForce (0, PKJump, PKJump/10);
			}
		}
	}
	//Gravity
	rigidbody.AddForce (Vector3.down * gravity * 100);

	}

	void FixedUpdate () {
		// only fuck with the player if it belongs to you, okay?  
		if (networkView.isMine && (Network.isClient || Network.isServer)) {
			InputMovement();
		} else {
			SyncedMovement();
		}
		// enable mouse if not playing
		if (Network.isClient || Network.isServer) {
			Screen.lockCursor = true;
		} else {
			Screen.lockCursor = false;
		}
	}
}
