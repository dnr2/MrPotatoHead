using UnityEngine;
using System.Collections;

public class LaserController : PlayerAnimationInterface {

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
	}
	
	override public void setCharacterMotor( CharacterMotor motor){
		this.motor = motor;	
	}
	
	override public Animator getAnimator(){
		return this.playerAnimator;
	}
	
	override public SkinnedMeshRenderer getHatObj( ){
		return this.stationaryHat;
	}
}
