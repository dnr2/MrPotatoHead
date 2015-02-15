using UnityEngine;
using System.Collections;

public class MolaController : MonoBehaviour {

	public bool activated = false;
	public float jumpHeight = 6;
	public float extraJumpEHeight = 6;
	
	private CharacterMotor motor;
	private float originalJumpHeight = 6;
	private float originalExtraJumpEHeight = 0;

	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C)){
			activated = !activated;
		}

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
