using UnityEngine;
using System.Collections;

public class HitDetect : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		if (collision.relativeVelocity.magnitude > 10)
			Destroy(gameObject);
	}
}
