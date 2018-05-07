using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

	public GameObject hook;
	public GameObject hookHolder;
	Transform originalHookTransform;
	public float hookTravelSpeed;
	public float playerTravelSpeed;

	public static bool fired;
	public  bool hooked;

	public float maxDistance;
	private float currentDistance;

	public GameObject hookedObj;

	private bool grounded;


	void Update(){

		// firing the hook
	if (Input.GetMouseButtonDown (1) && fired == false)
			fired = true;

		// if the hook has been fired
		if (fired == true && hooked == false) {
			hook.transform.Translate (Vector3.forward * Time.deltaTime * playerTravelSpeed);
			currentDistance = Vector3.Distance (transform.position, hook.transform.position);

			if (currentDistance >= maxDistance)
				ReturnHook ();
		}

		// if the hook collided with a hookable object
		if (hooked) {
			hook.transform.parent = hookedObj.transform;
			transform.position = Vector3.MoveTowards (transform.position, hook.transform.position, playerTravelSpeed * Time.deltaTime);
			float distanceToHook = Vector3.Distance (transform.position, hook.transform.position);

			this.GetComponent<Rigidbody> ().useGravity = false;

			if (distanceToHook < 2) {
				ReturnHook ();
				//if (grounded == false) {
				//	this.transform.Translate
				//}
			} 
		} else {
			//hook.transform.parent = hookHolder.transform;

			this.GetComponent<Rigidbody> ().useGravity = true;
		}

	}

	void ReturnHook(){
		
		hook.transform.parent = hookHolder.transform;
		hook.transform.localScale = new Vector3( 0.2f,0.2f,0.2f);
		hook.transform.rotation = hookHolder.transform.rotation;
		hook.transform.position = hookHolder.transform.position;
		fired = false;
		hooked = false;
	}

	void CheckIfGrounded(){

		RaycastHit hitInfo;
		float range = 1f;
		Vector3 dir = new Vector3 (0, -1);

		if (Physics.Raycast (transform.position, dir, out hitInfo, range)) {
			grounded = true;
		} else {
			grounded = false;
		}
	}
}
