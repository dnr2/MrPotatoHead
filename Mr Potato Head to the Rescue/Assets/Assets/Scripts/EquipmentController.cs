using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EquipmentController : MonoBehaviour {

	// os equipamentos vao ficar numa lista(array).


	public int equipID = 0; //Initial iquipment to be used
	public List<Animator> playerAnimator; //List of Player Animators
	public List<GameObject> playerAnimatorObj; 
	public List<SkinnedMeshRenderer> stationaryHatObj; //The hat on the top of the model to be used

	private PlayerAnimationInterface[] animations;
	private int animSize;
	private CharacterMotor motor;
	private ThrowHat hat;


	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor> ();
		hat = GetComponent<ThrowHat> ();
		PlayerAnimationInterface whellsController = new WheelsController();
		PlayerAnimationInterface molaController = new MolaController();

		animSize = Math.Min( this.playerAnimator.Count, Math.Min(
		                     this.playerAnimatorObj.Count, 
		                     this.stationaryHatObj.Count ));

		if( this.playerAnimator.Count != this.playerAnimatorObj.Count ){
			Debug.LogWarning( "Animators and Objects list should have the same size!!!");
		}

		this.animations = new PlayerAnimationInterface[10];

		if( animSize > 0) this.animations[0] = whellsController;
		if( animSize > 1) this.animations[1] = molaController;

		int pos = 0;
		foreach(Animator anim in this.playerAnimator ){
			this.animations[pos].setAnimator( anim );
			this.animations[pos].setCharacterMotor( motor );
			pos++;
		}

		pos = 0;
		foreach (GameObject obj in this.playerAnimatorObj) {
			this.animations[pos].setAnimatorObj( obj );	
			pos++;
		}

		pos = 0;
		foreach (SkinnedMeshRenderer obj in this.stationaryHatObj) {
			this.animations[pos].setHatObj( obj );	
			pos++;
		}

		//initialize
		this.animations[equipID].update( true );
		
		motor.setAnimator( this.animations[equipID].getAnimator() );
		hat.setAnimator( this.animations[equipID].getAnimator() );

	}
	
	// Update is called once per frame
	void Update () {

		int oldEquipID = equipID;

		if (Input.GetKey (KeyCode.X) && animSize > 0) {
			equipID = 0;
		}
		if (Input.GetKey (KeyCode.C) && animSize > 1) {
			equipID = 1;
		}



		if (oldEquipID != equipID) {

			Debug.Log (oldEquipID);
			Debug.Log( equipID );

			this.animations[oldEquipID].update( false );
			this.animations[equipID].update( true );

			motor.setAnimator( this.animations[equipID].getAnimator() );
			hat.setAnimator( this.animations[equipID].getAnimator() );
			hat.setStationaryHatMesh( this.animations[equipID].getHatObj() );
		}

	}
}

