using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EquipmentController : MonoBehaviour {

	// os equipamentos vao ficar numa lista(array). O equipamento que ja vem equipado deve ficar habilitado e os demais desabilitado 
	// (habilitar / desabilitar) o checkbox no canto superior esquerdo na aba inspector dos objetos 


	public int equipID = 0; //Initial iquipment to be used

	public PlayerAnimationInterface[] animations;
	private int animSize;
	private CharacterMotor motor; //script motor que controla movimento
	private ThrowHat hat; //script que controla o ataque do chapeu


	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor> ();
		hat = GetComponent<ThrowHat> ();
		animSize = animations.Length;

		foreach(PlayerAnimationInterface anim in animations ){
			anim.setCharacterMotor( motor );
		}
		
		if( this.animations[equipID].getAnimator() != null ) motor.setAnimator( this.animations[equipID].getAnimator() );
		if( this.animations[equipID].getAnimator() != null ) hat.setAnimator( this.animations[equipID].getAnimator() );

		//initialize
		this.animations[equipID].update( true );

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
		if (Input.GetKey (KeyCode.V) && animSize > 2) {
			equipID = 2;
		}

		if (oldEquipID != equipID) {		

			this.animations[oldEquipID].update( false );
			this.animations[equipID].update( true );

			motor.setAnimator( this.animations[equipID].getAnimator() );
			hat.setAnimator( this.animations[equipID].getAnimator() );
			hat.setStationaryHatMesh( this.animations[equipID].getHatObj() );
		}

	}
}

