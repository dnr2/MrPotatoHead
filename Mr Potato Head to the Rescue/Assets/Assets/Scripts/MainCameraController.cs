using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	public Transform target;
	public float distance = 155.0f;
	public float height = 3.0f;
	public float width = 3.0f;
	public float damping = 5.0f;
	public bool smoothRotation = true;
	public float rotationDamping = 10.0f;
	public float thresholdYtop = 5.0f;
	public float thresholdYbot = 10.0f;
	public float thresholdX = 85.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = target.position;

		if (newPosition.y - transform.position.y > thresholdYtop) {
			newPosition.y = newPosition.y - thresholdYtop;
		} else if (newPosition.y - transform.position.y < (-1)*thresholdYbot){
			newPosition.y = newPosition.y + thresholdYbot;
		}
		else {
			newPosition.y = transform.position.y;
		}


		if (newPosition.x - transform.position.x > thresholdX) {
			newPosition.x = newPosition.x - thresholdX;
		} else if (newPosition.x - transform.position.x < (-1)*thresholdX){
			newPosition.x = newPosition.x + thresholdX;
		}
		else {
			newPosition.x = transform.position.x;
		}


		//newPosition.x = transform.position.x;

		newPosition.z -= distance;

		transform.position = newPosition;
	}
}
