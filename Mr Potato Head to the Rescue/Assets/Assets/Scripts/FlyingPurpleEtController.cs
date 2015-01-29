using UnityEngine;
using System.Collections;

public class FlyingPurpleEtController : MonoBehaviour {

	public bool moves = true; // se o objeto vai se mover
	public int maxIncrementPos = 10; // quantidade maxima que vai andar
	public float stepSpeed = 1; // valor a se mover
	public bool initialyFacingForward = true;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 3F;
	
	private float originalXScale;
	private float originalXPos;
	private bool movingfForward;
	private float nextFire;
	private GameObject mrPotatoHead;
	
	// Use this for initialization
	void Start () {
		//originalXScale = modelTransform.localScale.x;
		originalXPos = transform.localPosition.x;
		movingfForward = initialyFacingForward;
	}
	
	// Update is called once per frame
	void Update () {
		if(mrPotatoHead == null)
			mrPotatoHead = GameObject.Find("MrPotatoHead");
		if(Time.time > nextFire && distance (mrPotatoHead.transform.position, this.transform.position) <= 40)
		{
			nextFire = Time.time + fireRate;
			shot.GetComponent<ProjectileController>().targetPos = new Vector3(mrPotatoHead.transform.position.x - 15, mrPotatoHead.transform.position.y, 0);
			Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
			shot.GetComponent<ProjectileController>().targetPos = mrPotatoHead.transform.position;
			Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
			shot.GetComponent<ProjectileController>().targetPos = new Vector3(mrPotatoHead.transform.position.x + 15, mrPotatoHead.transform.position.y, 0);;
			Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
		}
	}

	private float distance(Vector3 a, Vector3 b)
	{
		return Mathf.Sqrt (Mathf.Pow (a.x - b.x, 2) + Mathf.Pow (a.y - b.y, 2) + Mathf.Pow (a.z - b.z, 2));
	}

}
