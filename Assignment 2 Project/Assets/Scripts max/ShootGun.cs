using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour {

	public GameObject bullet;
	Rigidbody rb;
	public Transform bulletSpawn;
	public Animation gunAnim;
	public float bulletSpeed = 5000f;


	void Awake(){
		
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			gunAnim.Play();
			Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);

		}

	}


}
