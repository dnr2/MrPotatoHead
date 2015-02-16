using UnityEngine;
using System.Collections;

public class MolaController : PlayerAnimationInterface  {
	
	public float jumpHeight = 6;
	public float extraJumpEHeight = 10;
	
	private CharacterMotor motor;
	private Animator playerAnimator;
	private float originalJumpHeight;
	private float originalExtraJumpEHeight;
	private GameObject animatorObj;
	private SkinnedMeshRenderer stationaryHat;


	// Update is called once per frame
	public void update(bool activated) {
		this.animatorObj.SetActive (activated);
		if (activated) {			
			motor.SetBaseHeight(jumpHeight);
			motor.SetExtraHeight(extraJumpEHeight);
		}
		else {
			motor.SetBaseHeight(originalJumpHeight);
			motor.SetExtraHeight(originalExtraJumpEHeight);
		}
	}

	public void setCharacterMotor( CharacterMotor motor){
		this.motor = motor;
		originalJumpHeight = motor.GetBaseHeight();
		originalExtraJumpEHeight = motor.GetExtraHeight();
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
