using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public Transform spawnPoint;
	public AudioClip checkpointAudio;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			//audio.Play();

			spawnPoint.position = new Vector3(transform.position.x, spawnPoint.position.y, spawnPoint.position.z);
			Object.Destroy(this);

			}
		}
	}
