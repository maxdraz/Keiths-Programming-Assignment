using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour {

	public float health = 100f;

	public void TakeDamage(float damageTaken){

		health -= damageTaken;

		if (health <= 0) {
			Die ();
		}
	}

	void Die(){
		Destroy (gameObject);
	}
}
