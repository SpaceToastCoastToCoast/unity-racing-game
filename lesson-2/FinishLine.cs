using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {
	int laps = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player") || other.CompareTag ("Enemy")) {
			laps++;
			Debug.Log (other.name + " is now driving lap " + laps + ".");
		}
	}
}
