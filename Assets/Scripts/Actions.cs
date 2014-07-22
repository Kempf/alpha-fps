using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour {

	public Transform BarrelEnd;
	public Rigidbody Bullet;

	void FixedUpdate () {
	
			if(Input.GetButtonDown("Fire1"))
			{
				Rigidbody FireBullet;
				FireBullet = Instantiate(Bullet, BarrelEnd.position, BarrelEnd.rotation) as Rigidbody;
				FireBullet.AddForce(BarrelEnd.forward * 1000);
			}
		}
	}

