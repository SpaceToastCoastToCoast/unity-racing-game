using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet, thisBullet;
	public Transform[] targets;
	public int ammo = 0;
	Vector3 pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("z") && ammo > 0) {
			ammo--;
			Shoot ();
		}
	}

	void Shoot() {
		pos = transform.position;
		pos.y += 3f;
		thisBullet = Instantiate (bullet, pos, transform.rotation) as GameObject;
		thisBullet.layer = gameObject.layer;
		thisBullet.GetComponent<Bullet> ().SetTarget (targets[Random.Range(0, targets.Length - 1)]);
	}
}
