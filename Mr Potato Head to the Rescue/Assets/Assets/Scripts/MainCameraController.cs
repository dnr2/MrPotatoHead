using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	public Transform target;
	public float distance = 3.0f;
	public float height = 3.0f;
	public float damping = 5.0f;
	public bool smoothRotation = true;
	public float rotationDamping = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = target.position;
		newPosition.z -= distance;
		newPosition.y += height;
		transform.position = newPosition;
	}
}
