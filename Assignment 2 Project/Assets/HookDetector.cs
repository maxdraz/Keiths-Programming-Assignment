using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour {

	public GameObject player;

	void OnTriggerEnter(Collider col){
		if (col.tag == "Hookable") {
			player.GetComponent<GrapplingHook> ().hooked = true;
			player.GetComponent<GrapplingHook> ().hookedObj = col.gameObject;
		}
	}
}
