﻿using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	public float BulletSpeed;

	void Start () {
	
		Destroy (gameObject, 4f);

	}
}
