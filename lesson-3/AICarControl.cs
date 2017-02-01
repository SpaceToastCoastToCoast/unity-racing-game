using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarControl : MonoBehaviour {

	public GameObject navigationPath;
	public float speed = 50000f;
	public float maxSpeed = 100f;
	public float slowingFactor = 1f;
	public float angularSpeed = 80000f;
	public float maxAngularSpeed = 4000f;
	public float maxStoppedTurnSpeed = 2f;
	Quaternion newRot;
	float distance;
	Rigidbody rb;
	Vector3 target;
	Transform[] navPts;
	int currentNav = 1;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		//Set the center of mass for your vehicle.
		rb.centerOfMass = new Vector3 (0f, 0.5f, -1f);
		//Set max angular velocity for the rigidbody
		rb.maxAngularVelocity = 30f;
		navPts = navigationPath.GetComponentsInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}

	void Move() {
		distance = Vector3.Distance (transform.position, navPts [currentNav].position);

		if (distance < 40f) {
			//Slow down
			slowingFactor = 3f;

			//Increment which target we seek if the previous target is behind us.
			currentNav++;
			if (currentNav >= navPts.Length) {
				currentNav = 1;
			}
			Debug.Log (navPts [currentNav].name);
		} else {
			slowingFactor = 1f;
		}

		//Get direction to next target
		target = (navPts[currentNav].position - transform.position);
		target.y = 0;

		//Look in that direction
		newRot = Quaternion.LookRotation (target);

		//Smoothly move to this new rotation
		rb.MoveRotation (Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * maxStoppedTurnSpeed));
 		
		//Clamp the magnitude (strength) of the velocity to make sure it doesn't exceed max speed
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxSpeed);

		//Add force in that direction
		rb.AddRelativeForce((Vector3.forward / slowingFactor) * speed);
	}
}
