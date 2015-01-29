﻿using UnityEngine;
using System.Collections;

public class RedEtController : MonoBehaviour {
	public bool moves = true; // se o objeto vai se mover
	public int maxIncrementPos = 10; // quantidade maxima que vai andar
	public float stepSpeed = 1; // valor a se mover
	public bool initialyFacingForward = true;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 5F;
	
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
		if(Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			if(mrPotatoHead == null)
				mrPotatoHead = GameObject.Find("MrPotatoHead");
			shot.GetComponent<RedProjectileController>().targetPos = mrPotatoHead.transform.position;
			shot.GetComponent<RedProjectileController>().speed = 20F;
			Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
		}
	}
}
