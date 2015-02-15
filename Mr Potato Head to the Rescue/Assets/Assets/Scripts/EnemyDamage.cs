using UnityEngine;
using System.Collections;

/*
 * Usar esse script em um objeto com collider e trigger ativado
 * Como esse script pode estar acoplado a um objeto que e filho do objeto real, 
 * entao colocar a referencia do Objeto raiz do inimigo em enemyReference
 */


public class EnemyDamage : MonoBehaviour {

	public int life = 1; // Vida do inimigo
	public int playerDamage = 1; // dano causado TODO: isso deve mudar pois cada arma causa dano diferente
	public GameObject enemyMeshObject = null; // coloque o mesh do inimigo para que ele desaparece assim que morrer
	private GameObject enemyReference; //Referencia do inimigo (apontar para objeto dentro da cena)
	private bool isDead = false;

	void Start(){
		enemyReference = this.transform.parent.gameObject;
	}

	void Update(){
		if (isDead) {
			if ( audio == null || !audio.isPlaying ) {
				Destroy(enemyReference);
			}
			if( enemyMeshObject != null ){
				enemyMeshObject.SetActive( false );
			}
		}
	}

	//TODO inportar o script com as informacoes das armas, para saber quanto de dano elas infligem.
	void OnTriggerEnter( Collider collider )
	{	

		if (collider.gameObject.tag == "Player") {
			if( !isDead ){
				life -= playerDamage;
				runHitAnimation();			

				if( life <= 0 ){
					runDeathAnimation();
					isDead = true;
				}
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
