using UnityEngine;
using System.Collections;

public class SlimeShotController : MonoBehaviour {

	public float speed = 30f;

	// Use this for initialization
	void Start () {
		Vector3 direction = new Vector3 (0, -1, 0);
		this.rigidbody.velocity =  direction * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
	}

}
