using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public float smoothing = 4f;
	Transform target;
	Vector3 cameraOffset;
	// Use this for initialization
	void Awake () {
		//Automatically find the player (Find is expensive so only use once per script)
		target = GameObject.Find ("Player").transform;
		//Calculate how far away the camera needs to be from the target
		cameraOffset = transform.position - target.position;
	}

	// Update is called once per frame
	void Update () {
		//Move the camera's position. Using Transform directly is fine because cameras are not moved by physics
		//Use TransformPoint on the target to get position relative to the target, so that it stays behind the target.
		//Lerp to allow smooth transition.
		transform.position = Vector3.Lerp (transform.position, target.TransformPoint(cameraOffset), smoothing * Time.deltaTime);
		//Rotate the camera to look at its target
		transform.LookAt (target);
	}
}
