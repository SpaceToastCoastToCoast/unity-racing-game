using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Transform target;
	public float speed = 4000f;
	Rigidbody rb, otherRb;
	Vector3 pos, vel;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

	public void SetTarget(Transform go) {
		target = go;
	}

	void OnTriggerEnter(Collider other) {
		//Check if this collider is part of the target object.
		if (target != null) {
			if (other.CompareTag (target.tag)) {
				//Stop it
				other.attachedRigidbody.velocity = Vector3.zero;
				//Simulate explosion
				other.attachedRigidbody.AddExplosionForce (800000f, transform.position, 40f);
				//Find the enemy health so we can do damage
				EnemyHealth eH = other.GetComponent<EnemyHealth> ();
				if (eH != null) {
					eH.TakeDamage (10);
				}
			} else if (other.transform.parent != null && other.transform.parent.CompareTag (target.tag)) {
				//Stop it
				otherRb = other.GetComponentInParent<Rigidbody> ();
				otherRb.velocity = Vector3.zero;
				//Simulate explosion
				otherRb.AddExplosionForce (800000f, transform.position, 40f);
				//Find the enemy health so we can do damage
				EnemyHealth eH = other.GetComponentInParent<EnemyHealth> ();
				if (eH != null) {
					eH.TakeDamage (10);
				}
			}
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			pos = target.position;
			pos.y += 2f;
			rb.MoveRotation (Quaternion.LookRotation (pos - transform.position));
			rb.AddRelativeForce (Vector3.forward * speed);
		}
	}
}
