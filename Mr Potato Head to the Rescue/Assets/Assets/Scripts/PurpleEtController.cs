﻿using UnityEngine;
using System.Collections;

public class PurpleEtController : MonoBehaviour {

	public bool moves = true; // se o objeto vai se mover
	public int maxIncrementPos = 10; // quantidade maxima que vai andar
	public float stepSpeed = 1; // valor a se mover
	//public Transform modelTransform;
	public bool initialyFacingForward = true;
	public GameObject shot;
	public Transform shotSpawn;
	
	private float originalXScale;
	private float originalXPos;
	private bool movingfForward;
	public float fireRate = 1F;
	private float nextFire;

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
			GameObject obj = Instantiate (shot, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
		}

		if (moves) { // se o objeto se move
			if( originalXPos + maxIncrementPos < transform.localPosition.x ) movingfForward = false;
			if( originalXPos > transform.localPosition.x ) movingfForward = true;
			
			//int factor = 1;
			//if( !initialyFacingForward ) factor = -1;
			
			//Vector3 newLocalScale = modelTransform.localScale;
			//newLocalScale.x = (movingfForward? factor : -factor) * Mathf.Abs( originalXScale );
			//modelTransform.localScale = newLocalScale;
			
			Vector3 newPosition = transform.position;
			newPosition.x += (movingfForward? 1 : -1) * stepSpeed;
			transform.position = newPosition;
		}
	}
}
