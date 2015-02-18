using UnityEngine;
using System.Collections;

public class WheelsController : PlayerAnimationInterface {

	public float speed = 40;

	public SkinnedMeshRenderer stationaryHat;

	private CharacterMotor motor;
	private Animator playerAnimator;
	
	private float originalForwardSpeed = 10;
	private float originalBackwardSpeed = 10;


	void Awake () {
		this.playerAnimator = gameObject.GetComponent<Animator> ();
	}

	// Update is called once per frame
	override public void update(bool activated) {

		gameObject.SetActive (activated);
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
	override public void setCharacterMotor(CharacterMotor motor) {
		this.motor = motor;
		originalForwardSpeed = motor.GetForwardSpeed ();
		originalBackwardSpeed = motor.GetBackwardSpeed ();
	}

	override public Animator getAnimator(){
		return this.playerAnimator;
	}
	
	override public SkinnedMeshRenderer getHatObj( ){
		return this.stationaryHat;
	}

}
