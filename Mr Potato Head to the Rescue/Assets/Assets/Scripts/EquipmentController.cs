using UnityEngine;
using UnityEngine.UI;
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
	
	private RawImage direcional;
	private RawImage roda;
	private RawImage mola;
	private RawImage laser;
	private RawImage caudaTrex;
	
	public Texture2D roda1;
	public Texture2D mola1;
	public Texture2D laser1;
	public Texture2D caudaTrex1;
	public Texture2D roda2;
	public Texture2D mola2;
	public Texture2D laser2;
	public Texture2D caudaTrex2;



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
		direcional = GameObject.FindGameObjectWithTag("direcional").GetComponent <RawImage>();
		roda = GameObject.FindGameObjectWithTag("roda").GetComponent <RawImage>();
		mola = GameObject.FindGameObjectWithTag("mola").GetComponent <RawImage>();
		laser = GameObject.FindGameObjectWithTag("laser").GetComponent <RawImage>();
		caudaTrex = GameObject.FindGameObjectWithTag("caudaTrex").GetComponent <RawImage>();

	}
	
	// Update is called once per frame
	void Update () {

		int oldEquipID = equipID;
		
		/*
		X = Nada
		C = Mola
		V = Roda
		*/
		if (Input.GetKey (KeyCode.X) && animSize > 0) {
			equipID = 0;
		}
		if (Input.GetKey (KeyCode.C) && animSize > 1) {
			equipID = 1;
		}
		if (Input.GetKey (KeyCode.V) && animSize > 2) {
			equipID = 2;
		}
		if (Input.GetKey (KeyCode.B) && animSize > 3) {
			equipID = 3;
		}

		if (oldEquipID != equipID) {		
			this.animations[oldEquipID].update( false );
			this.animations[equipID].update( true );

			motor.setAnimator( this.animations[equipID].getAnimator() );
			hat.setAnimator( this.animations[equipID].getAnimator() );
			hat.setStationaryHatMesh( this.animations[equipID].getHatObj() );
			
			//Setando a imagem para a nao selecionada
			switch(oldEquipID){
				case 1:
				mola.texture =  mola1;
					break;
				case 2:
				roda.texture =  roda1;
					break;
				case 3:
				laser.texture =  laser1;
					break;
				case 4:
				caudaTrex.texture =  caudaTrex1;
					break;
			}
			
			switch(equipID){
				case 1:
				mola.texture =  mola2;
					break;
				case 2:
				roda.texture =  roda2;
					break;
				case 3:
				laser.texture =  laser2;
					break;
				case 4:
				caudaTrex.texture =  caudaTrex2;
					break;
			}
		}

	}
}

