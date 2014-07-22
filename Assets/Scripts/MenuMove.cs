using UnityEngine;
using System.Collections;

public class MenuMove : MonoBehaviour {

	public float RotX;
	public float RotY;

	void onGUI () {

		if (GUI.Button (new Rect (50, 50, 100, 50), "Click"))
				Application.LoadLevel ("TestMap");

	}

	void FixedUpdate () {
	
		//X Rotation
		RotX += Input.GetAxis ("Mouse X")/3;
		RotX = Mathf.Clamp (RotX, -10, 10);
		transform.localEulerAngles = new Vector3 (0, RotX, transform.localEulerAngles.x);
		
		//Y Rotation
		RotY += Input.GetAxis ("Mouse Y")/3;
		RotY = Mathf.Clamp (RotY, -10, 10);
		transform.localEulerAngles = new Vector3 (-RotY, transform.localEulerAngles.y, 0);
	}
}
