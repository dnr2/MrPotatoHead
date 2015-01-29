using UnityEngine;
using System.Collections;

public class FlyingRedEtController : MonoBehaviour {
	public bool moves = true; // se o objeto vai se mover
	public int maxIncrementPos = 10; // quantidade maxima que vai andar
	public float stepSpeed = 1; // valor a se mover
	public bool initialyFacingForward = true;
	public GameObject shot;
	public Transform shotSpawn;
	private float fireRate = 6F;
	
	private float originalXScale;
	private float originalXPos;
	private bool movingfForward;
	private float nextFire;
	private float nextBurstFire;
	private bool shooting = false;
	private int shots = 3;
	private GameObject mrPotatoHead;
	
	private Vector3 center = new Vector3(59,17,0);
	private float radius = 1.5f;
	private float wanderRefreshRate = 2f;
	private float nextWanderRefresh;
	
	// Use this for initialization
	void Start () {
		//originalXScale = modelTransform.localScale.x;
		originalXPos = transform.localPosition.x;
		movingfForward = initialyFacingForward;
		if(mrPotatoHead == null)
			mrPotatoHead = GameObject.Find("MrPotatoHead");
	}
	
	void FixedUpdate()
	{
		if(distance (mrPotatoHead.transform.position, this.transform.position) <= 10)
		{
			Vector3 direction = new Vector3(this.transform.position.x - mrPotatoHead.transform.position.x, 0, 0);
			rigidbody.velocity = direction * stepSpeed;
		}
		else if(distance (mrPotatoHead.transform.position, this.transform.position) >= 20)
		{
			Vector3 direction = new Vector3(mrPotatoHead.transform.position.x - this.transform.position.x, 0, 0);
			rigidbody.velocity = direction * stepSpeed;
		}
		else
		{
			rigidbody.velocity = new Vector3(0,0,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!shooting && Time.time > nextFire && distance (mrPotatoHead.transform.position, this.transform.position) <= 40)
		{
			nextFire = Time.time + fireRate;
			Vector3 target = new Vector3(mrPotatoHead.transform.position.x, mrPotatoHead.transform.position.y, mrPotatoHead.transform.position.z);
			shot.GetComponent<ProjectileController>().targetPos = target;
			shooting = true;
		}
		else if(shooting)
		{
			if(shots == 0)
			{
				shots = 3;
				shooting = false;
			}
			else if(Time.time > nextBurstFire)
			{
				nextBurstFire = Time.time + 0.2F;
				Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
				--shots;
			}
			print (shot.GetComponent<ProjectileController>().targetPos);
		}
	}
	
	private Vector3 nextVelocity()
	{
		return new Vector3(Random.Range(center.x - radius, center.x + radius), Random.Range(center.y - radius, center.y + radius), 0);
	}
	
	private float distance(Vector3 a, Vector3 b)
	{
		return Mathf.Sqrt (Mathf.Pow (a.x - b.x, 2) + Mathf.Pow (a.y - b.y, 2) + Mathf.Pow (a.z - b.z, 2));
	}

}
