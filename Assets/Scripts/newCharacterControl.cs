using UnityEngine;
using System.Collections;

public class newCharacterControl : MonoBehaviour {

	//Look controls
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
	public int MaxY = 90;
	public int MinY = -70;
	public float RotX = 0f;
	public float RotY = 0f;
	public int RotZ;
	public int MaxZ = 40;



	void Awake () {
		Screen.lockCursor = true;
	}
	
	void FixedUpdate () {
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
			} else if (RotZ > 0)
					RotZ -= 5;
			else if (RotZ < 0)
					RotZ += 5;
		
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








	}
}
