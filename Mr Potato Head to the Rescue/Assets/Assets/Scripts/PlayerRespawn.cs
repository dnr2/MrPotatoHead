using UnityEngine;
using System.Collections;

	public class PlayerRespawn : MonoBehaviour{

	public GameObject player;
	public Transform spawnPoint;

	public PlayerRespawn (){}

	void OnTriggerEnter(Collider other){
		bool replace = (other.gameObject.GetComponent<CharacterController>() != null);
		Object.Destroy (other.gameObject);
		if(replace)
		{
			GameObject P = (GameObject)GameObject.Instantiate (player, spawnPoint.position, player.transform.rotation);
			MainCameraController c = Camera.main.GetComponent <MainCameraController>();
			c.target = P.transform;
		}
	}

}


