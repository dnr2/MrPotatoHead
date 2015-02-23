using UnityEngine;
using System.Collections;

public class StealthSpaceshipController : MonoBehaviour {


	public GameObject[] enemiesToEnable;
	private float minDistToVanish = 100f;
	public float speedUP = 200f;

	private bool found = false;
	private bool flyingUp = false;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if( found ){
			if( !flyingUp) {
				MovingPlatformController movingScript = gameObject.GetComponent<MovingPlatformController>();
				if( movingScript != null ){
					this.rigidbody.velocity = new Vector3( 0, 0 ,0 );
				}
				movingScript.enabled = false;
				flyingUp = true;
			}
			if( flyingUp){
				this.rigidbody.AddForce( new Vector3(0,speedUP,0) );
				GameObject player = GameObject.FindGameObjectWithTag( "Player" );
				Debug.Log( "distance = " + Vector3.Distance( this.transform.position, player.transform.position ) );
				if( Vector3.Distance( this.transform.position, player.transform.position )  >  minDistToVanish){
					Debug.Log( "destruido...");
					GameObject.Destroy(this.gameObject);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.tag);
		if (!found && (other.tag == "Player" || other.tag == "weapon")) {
			AudioSource.PlayClipAtPoint (audio.clip, this.gameObject.transform.position);
			found = true;
			foreach( GameObject enemy in enemiesToEnable ){
				enemy.SetActive( true );
			}
		}
	}

}
