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


		if (fired) {
			LineRenderer rope = hook.GetComponent<LineRenderer> ();
			rope.positionCount = 2;
			rope.SetPosition (0, hookHolder.transform.position);
			rope.SetPosition (1, hook.transform.position);
		}

		// if the hook has been fired
		if (fired == true && hooked == false) {
			hook.transform.Translate (Vector3.forward * Time.deltaTime * playerTravelSpeed);
			currentDistance = Vector3.Distance (transform.position, hook.transform.position);

			if (currentDistance >= maxDistance)
				ReturnHook ();
		}

		// if the hook collided with a hookable object
		if (hooked == true && fired == true) {
			hook.transform.parent = hookedObj.transform;
			transform.position = Vector3.MoveTowards (transform.position, hook.transform.position, playerTravelSpeed * Time.deltaTime);
			float distanceToHook = Vector3.Distance (transform.position, hook.transform.position);

			this.GetComponent<Rigidbody> ().useGravity = false;

			if (Input.GetMouseButtonDown (1)) {
				ReturnHook ();
			}

			if (distanceToHook < 2) {
				//ReturnHook ();
				if (grounded == false) {
					this.transform.Translate (Vector3.forward * Time.deltaTime * 10f);
					this.transform.Translate (Vector3.up * Time.deltaTime * 25f);
				}

				StartCoroutine ("Climb");

			} 
		} else {
			//hook.transform.parent = hookHolder.transform;

			this.GetComponent<Rigidbody> ().useGravity = true;
		}

	}

	IEnumerator Climb(){
		yield return new WaitForSeconds (0.1f);
			ReturnHook();
	}

	void ReturnHook(){

		LineRenderer rope = hook.GetComponent<LineRenderer> ();
		rope.positionCount = 0;
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
