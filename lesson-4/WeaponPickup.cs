using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")){
			PlayerShoot playerShoot = other.GetComponent<PlayerShoot> ();
			if (playerShoot != null) {
				playerShoot.enabled = true;
				playerShoot.ammo = 10;
			}
			Destroy (gameObject);
		} 
	}

	// Update is called once per frame
	void Update () {
		
	}
}
