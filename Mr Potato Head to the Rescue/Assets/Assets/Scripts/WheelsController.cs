using UnityEngine;
using System.Collections;

public class WheelsController {

	public float speed = 40;

	private CharacterMotor motor;
	private float originalForwardSpeed = 10;
	private float originalBackwardSpeed = 10;

	void Awake (CharacterMotor motor) {
		this.motor = motor;
	}

	// Use this for initialization
	public WheelsController(CharacterMotor motor) {
		this.motor = motor;
		originalForwardSpeed = motor.GetForwardSpeed ();
		originalBackwardSpeed = motor.GetBackwardSpeed ();
	}
	
	// Update is called once per frame
	void Update (bool activated) {

		if (activated) {			
			motor.SetForwardSpeed (speed);
			motor.SetBackwardSpeed (speed);
		}
		else {
			motor.SetForwardSpeed(originalForwardSpeed);
			motor.SetBackwardSpeed(originalBackwardSpeed);
		}
	
	}
}
