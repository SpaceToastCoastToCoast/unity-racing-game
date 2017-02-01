using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int currentHealth, startingHealth;
	bool isDead;
	AICarControl enemyMovement;
	Rigidbody thisRb;
	Rigidbody[] childRBs;

	// Use this for initialization
	void Awake () {
		currentHealth = startingHealth;
		enemyMovement = GetComponent<AICarControl> ();
		thisRb = GetComponent<Rigidbody> ();
		childRBs = GetComponentsInChildren<Rigidbody> ();
		foreach (Rigidbody rb in childRBs) {
			if (rb != thisRb) {
				rb.isKinematic = true;
				rb.detectCollisions = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0 && !isDead) {
			Die ();
		}
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;
	}

	void Die() {
		isDead = true;
		enemyMovement.enabled = false;
		foreach (Rigidbody rb in childRBs) {
			rb.isKinematic = false;
			rb.detectCollisions = true;
		}
		Destroy (thisRb);
		Destroy (gameObject, 2f);
	}
}
