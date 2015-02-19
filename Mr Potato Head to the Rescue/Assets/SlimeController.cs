using UnityEngine;
using System.Collections;

public class SlimeController : MonoBehaviour {

	private float nextFire;
	public float fireRate = 5f;
	public GameObject slimeShot;

	// Use this for initialization
	void Start () {
		nextFire = Time.time + fireRate;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire ) {
			Debug.Log( "atirando slime" );
			Instantiate( slimeShot, gameObject.transform.position,  Quaternion.identity );
			nextFire = Time.time + fireRate;
		}
	}
}
