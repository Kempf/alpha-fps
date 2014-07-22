using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour {

	public Transform BarrelEnd;
	public Rigidbody Bullet;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
			if(Input.GetButtonDown("Fire1"))
			{
				Rigidbody FireBullet;
				FireBullet = Instantiate(Bullet, BarrelEnd.position, BarrelEnd.rotation) as Rigidbody;
				FireBullet.AddForce(BarrelEnd.forward * 5000);
			}
		}
	}

