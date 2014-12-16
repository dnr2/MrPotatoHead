using UnityEngine;
using System.Collections;

public class WheelsController : MonoBehaviour {
	public bool activated = false;
	public float speed = 40;

	private CharacterMotor motor;
	private float originalForwardSpeed = 10;
	private float originalBackwardSpeed = 10;

	void Awake () {
		motor = GetComponent<CharacterMotor> ();
	}

	// Use this for initialization
	void Start () {

		originalForwardSpeed = motor.GetForwardSpeed ();
		originalBackwardSpeed = motor.GetBackwardSpeed ();


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.X)){
			activated = !activated;
		}
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
