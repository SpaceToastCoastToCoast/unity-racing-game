using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour {
	Vector3 movement;
	float v, h; //vertical, horizontal input
	bool b; //brakes
	public float speed = 100f;
	public float maxSpeed = 100f;
	public float reverseMultiplier = 5f;
	public float angularSpeed = 2f;
	float newRot;
	Rigidbody rb;
	Vector3 newVelocity;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		//Set the center of mass for your vehicle.
		rb.centerOfMass = new Vector3 (0f, 0.5f, -1f);
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
		//Multiply the amount of forward input by the movement speed.
		v *= speed;

		//Move it slower if it is in reverse.
		if (v < 0) {
			v /= reverseMultiplier;
		}

		if (v > -0.05f && v < 0.05f) {
			
		} else {
			//Move it relative to the object's forward axis.
			newVelocity = Vector3.Lerp(Vector3.zero, transform.forward.normalized * v, speed * Time.deltaTime);
			//Keep the existing y velocity so gravity stays active.
			newVelocity.y = rb.velocity.y;
			newVelocity = Vector3.ClampMagnitude (newVelocity, maxSpeed);

			rb.velocity = newVelocity;
		}
	}

	void Brakes(bool b){
		if (b) {
			//Bring its velocity toward zero.
			newVelocity = Vector3.Lerp (rb.velocity, Vector3.zero, speed * Time.deltaTime);
			//Keep the existing y velocity so gravity stays active.
			newVelocity.y = rb.velocity.y;

			rb.velocity = newVelocity;
		}
	}

	void SteeringWheel(float h) {
		h *= angularSpeed;
		newRot = rb.rotation.eulerAngles.y;
		newRot += h;
		rb.MoveRotation (Quaternion.Euler(0, newRot, 0));
	}
}
