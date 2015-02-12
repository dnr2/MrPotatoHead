using UnityEngine;
using System.Collections;

/*
 * Usar esse script em um objeto com collider e trigger ativado
 * Colocar a referencia do Objeto raiz do inimigo em enemyReference
 */


public class EnemyDamage : MonoBehaviour {

	public int life = 1; // Vida do inimigo
	public int playerDamage = 1; // dano causado TODO: isso deve mudar pois cada arma causa dano diferente
	public GameObject enemyReference; //Referencia do inimigo (apontar para objeto dentro da cena)
	private bool isDead = false;

	void Start(){

	}

	void Update(){
		if (isDead && audio != null && !audio.isPlaying) {
			Destroy(enemyReference);
		}
	}

	//TODO inportar o script com as informacoes das armas, para saber quanto de dano elas infligem.
	void OnTriggerEnter( Collider collider )
	{
		Debug.Log ("aqui");
		Debug.Log (collider.gameObject.tag);
		if (collider.gameObject.tag == "Player") {
			life -= playerDamage;
			runHitAnimation();			

			if( life <= 0 ){
				runDeathAnimation();
				isDead = true;
			}
		}
	}

	void runHitAnimation(){

		//ira tentar tocar Audio Source componente (ver documentacao do Unity)
		if (audio != null) {
			audio.Play();		
		}
	}

	void runDeathAnimation(){

		//TODO adicionar alguma forma para animar o personagem e deleta-lo depois que ele morrer
	}

}
