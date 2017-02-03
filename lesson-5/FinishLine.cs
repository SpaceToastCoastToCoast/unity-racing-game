using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {
	Hashtable positions;
	public static Dictionary<Collider, int> playerLaps;
	// Use this for initialization
	void Start () {
		positions = new Hashtable ();
		playerLaps = new Dictionary<Collider, int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player") || other.CompareTag ("Enemy")) {
			//We want to save the position at which this object came in, and compare it to its position in the next frame.
			if (!positions.ContainsKey(other)) {
				positions.Add (other, other.transform.position);
				Debug.Log (other.name + " has entered the finish line.");
			}
		}
	}

	void OnTriggerStay(Collider other) {
		
	}

	void OnTriggerExit(Collider other) {
		if (positions.ContainsKey(other)) {
			Vector3 prevPos = (Vector3)positions[other];
			if (prevPos.z - other.transform.position.z < 0f) {
				if (!playerLaps.ContainsKey (other)) {
					playerLaps.Add (other, 0);
				} else {
					playerLaps [other] = (int)playerLaps [other] + 1;
				}
				Debug.Log (other.name + " has completed " + playerLaps [other] + " laps.");
			} else {
				//Take away when they cross in a negative direction
				playerLaps [other] = (int)playerLaps [other] - 1;
			}
			positions.Remove (other);
		}
	}
}
