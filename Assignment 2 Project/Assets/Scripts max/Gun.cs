using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage = 25f;
	public float range = 100f;
	public float impactForce;

	public Transform cam;

	//cosmetics
	public ParticleSystem muzzleFlash; 
	public Animation gunAnim;
	AudioSource shootSound;
	public GameObject impact;

	void Awake(){
		shootSound = GetComponentInChildren<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			Shoot ();
		}
	}

	void Shoot(){

		muzzleFlash.Play ();
		gunAnim.Play ();
		shootSound.Play ();

		RaycastHit hitInfo;

		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hitInfo, range)) {
			Debug.Log (hitInfo.transform.name);
		}

		EnemyData enemyData = hitInfo.transform.GetComponent<EnemyData> ();
		if (enemyData != null) {
			enemyData.TakeDamage (damage);
		}

		if (hitInfo.rigidbody != null) {
			hitInfo.rigidbody.AddForce (impactForce * -hitInfo.normal);
		}

		GameObject impactInstance =Instantiate (impact, hitInfo.point, Quaternion.LookRotation (hitInfo.normal));
		Destroy (impactInstance, 1);
	}
}
