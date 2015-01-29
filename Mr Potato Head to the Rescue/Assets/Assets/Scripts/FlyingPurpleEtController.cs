﻿using UnityEngine;
using System.Collections;

public class FlyingPurpleEtController : MonoBehaviour {

	public bool moves = true; // se o objeto vai se mover
	public int maxIncrementPos = 10; // quantidade maxima que vai andar
	public float stepSpeed = 1; // valor a se mover
	public bool initialyFacingForward = true;
	public GameObject shot;
	public Transform shotSpawn;
	
	private float fireRate = 3F;
	private float originalXScale;
	private float originalXPos;
	private bool movingfForward;
	private float nextFire;
	private GameObject mrPotatoHead;
	
	private Vector3 center = new Vector3(59,30,0);
	private float radius = 5f;
	private float wanderRefreshRate = 1f;
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
		if(distance (mrPotatoHead.transform.position, this.transform.position) <= 15)
		{
			Vector3 direction = new Vector3(this.transform.position.x - mrPotatoHead.transform.position.x, 0, 0);
			rigidbody.velocity = direction * stepSpeed;
		}
		else if(distance (mrPotatoHead.transform.position, this.transform.position) >= 25)
		{
			Vector3 direction = new Vector3(mrPotatoHead.transform.position.x - this.transform.position.x, 0, 0);
			rigidbody.velocity = direction * stepSpeed;
		}
		else
		{
			if(Time.time > nextWanderRefresh)
			{
				nextWanderRefresh = Time.time + wanderRefreshRate;
				rigidbody.velocity = (center - nextVelocity());
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
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
	
	private Vector3 nextVelocity()
	{
		return new Vector3(Random.Range(center.x - radius, center.x + radius), Random.Range(center.y - radius, center.y + radius), 0);
	}

}