using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlight : MonoBehaviour {

	Rigidbody rb;
	public int bulletDamage;
	public float magnitude;


	void Awake(){
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void Update () {
		rb.AddForce (transform.forward * magnitude * Time.deltaTime, ForceMode.Impulse);
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyData> ().TakeDamage (bulletDamage);
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Environment") {
			Destroy (this.gameObject, 0.05f);
		}
	}


	}

