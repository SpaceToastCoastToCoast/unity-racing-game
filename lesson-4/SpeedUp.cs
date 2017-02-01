using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")){
			MoveCarForce playerMovement = other.GetComponent<MoveCarForce> ();
			if (playerMovement != null) {
				playerMovement.maxSpeed += 10f;
				Debug.Log ("Player's max speed is: " + playerMovement.maxSpeed);
			}
			Destroy (gameObject);

		} else if(other.CompareTag("Enemy")) {
			AICarControl enemyMovement = other.GetComponent<AICarControl> ();
			if (enemyMovement != null) {
				enemyMovement.maxSpeed += 10f;
				Debug.Log ("Enemy's max speed is: " + enemyMovement.maxSpeed);
			}
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
