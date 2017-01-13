using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarForce : MonoBehaviour {
	float v, h; //vertical, horizontal input
	bool b; //brakes
	public float engineTorque = 50000f; //how much force the engine can apply
	public float maxSpeed = 100f; //how fast the vehicle can go
	public float reverseMultiplier = 5f; //the factor by which speed in reverse is divided
	public float turnForce = 80000f; //how much force it takes to turn the wheels while in motion
	public float maxTurnForce = 4000f; //the maximum force that can be applied to the steering
	public float maxStoppedTurnSpeed = 2f; //the maximum degrees per frame that the vehicle can turn while stopped
	float newRot;
	Rigidbody rb;
	Vector3 newVelocity;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		//Set the center of mass for your vehicle.
		rb.centerOfMass = new Vector3 (0f, 0.5f, -1f);
		//Set max angular velocity for the rigidbody
		rb.maxAngularVelocity = 30f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//Read the forward input only.
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");
		b = Input.GetKey ("space");

		GasPedal (v);
		Brakes (b);
		SteeringWheel (h);

	}

	void GasPedal(float v) {
		//Get v input and set to forward
		newVelocity.Set(0f, 0f, v);

		//Clamp the magnitude (strength) of the velocity to make sure it doesn't exceed max speed
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxSpeed);

		//Add force in that direction
		rb.AddRelativeForce(newVelocity.normalized * engineTorque);

	}

	void Brakes(bool b){
		if (b) {
			//Bring its velocity toward zero.
			newVelocity = Vector3.Lerp (rb.velocity, Vector3.zero, rb.mass * Time.deltaTime);
			//Keep the existing y velocity so gravity stays active.
			newVelocity.y = rb.velocity.y;

			rb.velocity = newVelocity;

			//Also bring angular velocity towards zero
			rb.angularVelocity = Vector3.Lerp (rb.angularVelocity, Vector3.zero, rb.mass * Time.deltaTime);
		}
	}

	void SteeringWheel(float h) {
		if (rb.velocity.magnitude < 0.05f) {
			//Allow for finer controls when stopped

			//multiply horizontal input by maximum stopped turning speed
			h *= maxStoppedTurnSpeed;

			//Get the current y-axis rotation and store it
			newRot = rb.rotation.eulerAngles.y;
			//Add to existing rotation
			newRot += h;
			//Tell the rigidbody to move its rotation to the new value
			rb.MoveRotation (Quaternion.Euler(0, newRot, 0));
		} else {
			//Use torque around y-axis while force is being applied

			//ClampMagnitude to limit the torque so it does not exceed a maximum level
			rb.AddTorque (Vector3.ClampMagnitude(transform.up * h * turnForce, maxTurnForce));

			//clamp the angular velocity so that the result of line 83 also does not exceed maximum velocity
			rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, maxSpeed / 2);
		}
	}
}
