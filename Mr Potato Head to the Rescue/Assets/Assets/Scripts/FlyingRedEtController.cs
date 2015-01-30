using UnityEngine;
using System.Collections;

public class FlyingRedEtController : MonoBehaviour {
	public bool moves = true; // se o objeto vai se mover
	public int maxIncrementPos = 10; // quantidade maxima que vai andar
	public bool initialyFacingForward = true;
	public GameObject shot;
	public Transform shotSpawn;
	private float fireRate = 4F;
	
	private float originalXScale;
	private float originalXPos;
	private bool movingfForward;
	private float nextFire;
	private float nextBurstFire;
	private bool shooting = false;
	private int shots = 3;
	private GameObject mrPotatoHead;
	
	private bool turnAround = false;
	private float sweepSpeed = 10f;
	private bool seek = false;
	private float maxDistance = 40f;
	
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
		if(distance(mrPotatoHead.transform.position, this.transform.position) <= maxDistance && !seek)
		{
			this.rigidbody.velocity = new Vector3(-1,0,0) * sweepSpeed;
			seek = true;
		}
		else if(distance(mrPotatoHead.transform.position, this.transform.position) > maxDistance && !turnAround && seek)
		{
			turnAround = true;
		}
		else if(turnAround)
		{
			if(distance(mrPotatoHead.transform.position, this.transform.position) <= maxDistance + 1)
				this.rigidbody.velocity = new Vector3(1,0,0) * sweepSpeed;
			else
				Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!shooting && Time.time > nextFire && distance (mrPotatoHead.transform.position, this.transform.position) <= maxDistance)
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
	
	private float distance(Vector3 a, Vector3 b)
	{
		return Mathf.Sqrt (Mathf.Pow (a.x - b.x, 2) + Mathf.Pow (a.y - b.y, 2) + Mathf.Pow (a.z - b.z, 2));
	}

}
