﻿using UnityEngine;
using System.Collections;

public class PotatoLifeController : MonoBehaviour {

	public int initialLifePoints = 1;
	public int lives = 1;
	public static int continues = 1;
	public Transform spawnPoint;

	private bool isDead = false;
	private int lifePoints ;


	// Use this for initialization
	void Start () {
		lifePoints = initialLifePoints;
	}
	
	// Update is called once per frame
	void Update () {

	}


	void causeDamage(int val){
		if (!isDead) {
			Debug.Log( "atingido" );
			lifePoints -= val;
			if( lifePoints <= 0){
				PlayDeathAnimation();
				isDead = true;
				playerRespawn();
			}
		}
	}

	void playerRespawn(){
		//if still has lives.
		if (lives > 0) {

			Debug.Log( "morreu.." );

			lives--;

			lifePoints = initialLifePoints;
			isDead = false;

			this.transform.position = spawnPoint.position;


		} else if (PotatoLifeController.continues > 0) {

			Debug.Log( "usando coninue.." );

			//restart the level;
			PotatoLifeController.continues--;

			Debug.Log(Application.loadedLevelName);

			Application.LoadLevel(Application.loadedLevelName);
		} else {
			//game over, restart the game

			Debug.Log( "Game OVERR" );
			playGameOverAnimation();

			Application.LoadLevel("StartMenu");

		}
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "laserbean") {
			causeDamage(1);
			Destroy(other.gameObject);
		}
	}

	void PlayDeathAnimation(){
		
	}

	void playGameOverAnimation(){
		
	}

}
