using UnityEngine;
using System.Collections;

public class EquipmentController : MonoBehaviour {

	// os equipamentos vao ficar numa lista circular duplamenteligada. para trocar de equipamento
	// usa um dos dois botoes X ou Y, onde X troca para o equipamento na posicao anterior e Y
	// para a posicao posterior.
	// equipID = 0 para nenhum equipamento

	private CharacterMotor motor;
	private int equipID = 0;
	private int numEquip = 2; //numero de equipamentos diferentes;

	// === MOLA === //
	// equipID = 1

	private MolaController mola;

	// === RODAS === //
	// equipID = 2
	private WheelsController rodas;

	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor> ();
		mola = new MolaController(motor);
		rodas = new WheelsController(motor);
	}
	
	// Update is called once per frame
	void Update () {

		int oldEquipID = equipID;

		if (Input.GetKey (KeyCode.X)) {
			equipID--;
			if( equipID < 0) equipID = numEquip;
		}
		if (Input.GetKey (KeyCode.Y)) {
			equipID++;
			if( equipID > numEquip ) equipID = 0;
		}

		if (oldEquipID != equipID) {

			if( oldEquipID == 1 ){
			
			}
			else if( oldEquipID == 2 ){
			
			}

			if( equipID == 1 ){
			
			}
			else if( equipID == 2 ){
				
			}

		}

	}
}
