using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverFall: MonoBehaviour {

	public GameObject gameOver;
	public AudioSource gameOverS;

	public void OnTriggerEnter2D(Collider2D other){
        if ((other.gameObject.tag == "Player") || (other.gameObject.tag=="Player2")) {
			gameOver.SetActive (true);
			other.gameObject.SetActive (false);
			gameOverS.Play ();
		}
	}
}
