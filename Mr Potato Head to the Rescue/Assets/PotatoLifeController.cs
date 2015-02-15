using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotatoLifeController : MonoBehaviour {

	public int initialLifePoints = 1;
	public int lives = 1;
	public static int continues = 1;
	public Transform spawnPoint;
	public Text textoVida;
	
	private bool isDead = false;
	private int lifePoints ;
	private bool invincible = false;


	// Use this for initialization
	void Start () {	
		textoVida = GameObject.FindGameObjectWithTag("PotatoLifeText").GetComponent <Text>();
		textoVida.text = "x"+lives;
		Debug.Log("Texto = "+textoVida.text);
		lifePoints = initialLifePoints;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void updateLives(int vidas){
		textoVida.text = "x"+vidas;
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
	
			updateLives (--lives);
			
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
		Debug.Log ("INVICIBLE IS " + invincible + " TAG is "  + other.tag);
		if (!invincible) {
			if (other.tag == "laserbean") {
				causeDamage (1);
				playSound();
				StartCoroutine (myWait (2));
				Destroy (other.gameObject);
			} else if (other.tag == "enemy") {
				causeDamage (1);
				Destroy (other.gameObject);
			}
			else if (other.tag == "hpItem") {
				causeDamage (1);
				lifePoints++;
				Destroy (other.gameObject);
			}
			else if (other.tag == "lifeItem") {
				causeDamage (1);
				updateLives(++lives);
				Destroy (other.gameObject);
			}
			else if (other.tag == "continueItem") {
				causeDamage (1);
				continues++;
				Destroy (other.gameObject);
			}
		}
	}

	void playSound(){

		//ira tentar tocar Audio Source componente (ver documentacao do Unity)
		if (audio != null) {
			AudioSource.PlayClipAtPoint(audio.clip, this.gameObject.transform.position );
		}
	}
	
	IEnumerator myWait(int seconds) {
		Debug.Log("IVUNERAVIU");
		invincible = true;
		yield return new WaitForSeconds(seconds);
		invincible = false;
		Debug.Log("VUNERAVIU");
	}

	void PlayDeathAnimation(){
		
	}

	void playGameOverAnimation(){
		
	}

}
