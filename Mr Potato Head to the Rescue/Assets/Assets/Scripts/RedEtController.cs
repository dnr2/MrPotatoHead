using UnityEngine;
using System.Collections;

public class RedEtController : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 1F;
	
	private Vector3 YAxis = new Vector3(0,1,0);
	private float nextFire;
	private GameObject mrPotatoHead;
	private float maxDistance = 40f;
	
	// Use this for initialization
	void Start () {
		if(mrPotatoHead == null)
			mrPotatoHead = GameObject.Find("MrPotatoHead");
	}
	
	// Update is called once per frame
	void Update () {
		if(mrPotatoHead == null)
			mrPotatoHead = GameObject.Find("MrPotatoHead");
		if(Time.time > nextFire && distance (mrPotatoHead.transform.position, this.transform.position) < maxDistance)
		{
			nextFire = Time.time + fireRate;
			shot.GetComponent<RedProjectileController>().targetPos = mrPotatoHead.transform.position;
			Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
		}
	}
	
	private float distance(Vector3 a, Vector3 b)
	{
		return Mathf.Sqrt (Mathf.Pow (a.x - b.x, 2) + Mathf.Pow (a.y - b.y, 2) + Mathf.Pow (a.z - b.z, 2));
	}
}
