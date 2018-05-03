using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.DrawRay (transform.position, transform.forward, Color.green);
	}
}
