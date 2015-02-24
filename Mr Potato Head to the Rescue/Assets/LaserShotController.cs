using UnityEngine;
using System.Collections;

public class LaserShotController : MonoBehaviour {

	public GameObject shot;
	public GameObject potatoObject;
	public Transform shotSpawn;
	public Transform potatoPosition;
	public float fireRate = 3F;
	public int mpCost = 5;

	private float nextFire;
	private PotatoLifeController PotatoLifeScript;

	// Use this for initialization
	void Start () {
		PotatoLifeScript = potatoObject.GetComponent<PotatoLifeController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if ( PotatoLifeScript.getMP() > mpCost && Time.time > nextFire && Input.GetKey( KeyCode.B ) ) {
			PotatoLifeScript.updateManaPointsAndBar(-mpCost);
			nextFire = Time.time + fireRate;
			Vector3 target = shotSpawn.transform.position;
			target.x += (shotSpawn.position.x - potatoPosition.position.x);
			shot.GetComponent<BuzzProjectileController> ().targetPos = target;
			//Debug.Log( "criando buzz lasebean target =  " + target.x);
			Instantiate (shot, shotSpawn.transform.position, Quaternion.identity);
			
		}

	}
}
