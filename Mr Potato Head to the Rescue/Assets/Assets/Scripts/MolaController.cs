using UnityEngine;
using System.Collections;

public class MolaController : PlayerAnimationInterface  {
	
	public float jumpHeight = 12;
	public float extraJumpEHeight = 16;

	public SkinnedMeshRenderer stationaryHat;

	private CharacterMotor motor;
	private float originalJumpHeight;
	private float originalExtraJumpEHeight;
	private Animator playerAnimator;

	void Awake () {
		this.playerAnimator = gameObject.GetComponent<Animator> ();
	}


	// Update is called once per frame
	override public void update(bool activated) {
		gameObject.SetActive (activated);
		if (activated) {			
			motor.SetBaseHeight(jumpHeight);
			motor.SetExtraHeight(extraJumpEHeight);
		}
		else {
			motor.SetBaseHeight(originalJumpHeight);
			motor.SetExtraHeight(originalExtraJumpEHeight);
		}
	}

	override public void setCharacterMotor( CharacterMotor motor){
		this.motor = motor;
		originalJumpHeight = motor.GetBaseHeight();
		originalExtraJumpEHeight = motor.GetExtraHeight();
	}

	override public Animator getAnimator(){
		return this.playerAnimator;
	}

	override public SkinnedMeshRenderer getHatObj( ){
		return this.stationaryHat;
	}

}
