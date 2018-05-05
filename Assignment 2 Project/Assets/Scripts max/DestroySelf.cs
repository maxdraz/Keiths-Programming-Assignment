using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {


	public float delay;
	
	// Update is called once per frame
	void Update(){
		Destroy (this.gameObject, delay);
	}
}
