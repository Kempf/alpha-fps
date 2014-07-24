using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	public float BulletSpeed;

	void Start () {
		Destroy (gameObject, 4f);
	}

	void FixedUpdate() {

		rigidbody.AddForce (0, -2, 0);

	}
}
