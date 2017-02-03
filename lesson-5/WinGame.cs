using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {

	Text text;
	float timeToNext = 5f;
	float timer = 0f;
	string winner;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (FinishLine.playerLaps.ContainsValue (3) && !text.enabled) {

			foreach(KeyValuePair<Collider, int> p in FinishLine.playerLaps) {
				if (p.Value == 3) {
					winner = p.Key.name;
					break;
				}
			}

			text.enabled = true;

			text.text = (winner + " has won!");
		}
		if (text.enabled) {
			timer += Time.deltaTime;
			if (timer >= timeToNext) {
				timer = 0f;
				SceneManager.LoadScene (0);
			}
		}
	}
}
