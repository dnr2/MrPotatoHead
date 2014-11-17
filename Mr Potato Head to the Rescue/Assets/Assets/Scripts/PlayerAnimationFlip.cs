using UnityEngine;
using System.Collections;

public class PlayerAnimationFlip : MonoBehaviour {

	private bool movingforward = true;
	private Vector3 originalPlayerScale;

	// Use this for initialization
	void Start () {
		originalPlayerScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newScale = originalPlayerScale;
		newScale.z *= (movingforward ? 1 : -1);
		transform.localScale = newScale;

		if (Input.GetAxis("Horizontal") > 0) {
			movingforward = true;
		}
		if( Input.GetAxis("Horizontal") < 0){
			movingforward = false;
		}
	}
}
