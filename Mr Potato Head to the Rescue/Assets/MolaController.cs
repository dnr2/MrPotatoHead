using UnityEngine;
using System.Collections;

public class MolaController : MonoBehaviour {
	
	public float jumpHeight = 6;
	public float extraJumpEHeight = 6;
	
	private CharacterMotor motor;
	private float originalJumpHeight;
	private float originalExtraJumpEHeight;

	// Use this for initialization
	public MolaController(CharacterMotor motor) {
		this.motor = motor;
		originalJumpHeight = motor.GetBaseHeight();
		originalExtraJumpEHeight = motor.GetExtraHeight();
	}
	
	// Update is called once per frame
	public void update(bool activated) {

		if (activated) {			
			motor.SetBaseHeight(jumpHeight);
			motor.SetExtraHeight(extraJumpEHeight);
		}
		else {
			motor.SetBaseHeight(originalJumpHeight);
			motor.SetExtraHeight(originalExtraJumpEHeight);
		}

	}
}
