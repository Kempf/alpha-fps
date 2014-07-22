using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (Physics.Raycast (transform.localPosition, Vector3.forward * 10f)) {
			if (Input.GetButton ("Fire1")){
				print ("Hit");

			}
		}
	}
}
