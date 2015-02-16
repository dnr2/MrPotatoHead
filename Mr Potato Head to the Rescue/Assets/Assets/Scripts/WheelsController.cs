﻿using UnityEngine;
using System.Collections;

public class WheelsController : PlayerAnimationInterface {

	public float speed = 40;

	private CharacterMotor motor;
	private Animator playerAnimator;
	private float originalForwardSpeed = 10;
	private float originalBackwardSpeed = 10;
	private GameObject animatorObj;
	private SkinnedMeshRenderer stationaryHat;

	// Update is called once per frame
	public void update(bool activated) {
		this.animatorObj.SetActive (activated);
		if (activated) {			
			motor.SetForwardSpeed (speed);
			motor.SetBackwardSpeed (speed);
		}
		else {
			motor.SetForwardSpeed(originalForwardSpeed);
			motor.SetBackwardSpeed(originalBackwardSpeed);
		}
	
	}

	// Use this for initialization
	public void setCharacterMotor(CharacterMotor motor) {
		this.motor = motor;
		originalForwardSpeed = motor.GetForwardSpeed ();
		originalBackwardSpeed = motor.GetBackwardSpeed ();
	}

	public Animator getAnimator(){
		return this.playerAnimator;
	}
	public void setAnimator(Animator anim){
		this.playerAnimator = anim;
	}
	public void setAnimatorObj( GameObject obj ){
		this.animatorObj = obj;
	}
	public void setHatObj( SkinnedMeshRenderer obj ){
		this.stationaryHat = obj;
	}
	
	public SkinnedMeshRenderer getHatObj( ){
		return this.stationaryHat;
	}

}
