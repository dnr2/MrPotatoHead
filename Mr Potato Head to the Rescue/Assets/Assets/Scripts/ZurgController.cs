using UnityEngine;
using System.Collections;

public class ZurgController : MonoBehaviour {
	public GameObject tennisBall;
	public GameObject heatSeekingMissile;
	public GameObject flyingPurpleET;
	public GameObject shotSpawn;
	
	private float fireRate = 1F;
	private float nextFire;
	private Vector3 target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			target = new Vector3(this.shotSpawn.transform.position.x - 1, this.shotSpawn.transform.position.y, this.shotSpawn.transform.position.z);
			tennisBall.GetComponent<TennisBallController>().targetPos = target;
			Instantiate(tennisBall, shotSpawn.transform.position, shotSpawn.transform.rotation);
		}
	}
}
