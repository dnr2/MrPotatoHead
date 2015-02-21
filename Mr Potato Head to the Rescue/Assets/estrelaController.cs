using UnityEngine;
using System.Collections;

public class estrelaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("GOLOU");
		Destroy(gameObject);
	}
}
