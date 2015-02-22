using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour {
	private bool turnAround = false;
	private float moveSpeed = 5f;
	private float maxDistance = 18f;
	private Vector3 origin;
	// Use this for initialization
	void Start () {
		origin = this.transform.position;
		this.rigidbody.velocity = new Vector3(1,0,0) * moveSpeed;
	}
	
	void Update () {
		if(!turnAround)
		{
			if(origin.x + maxDistance < this.transform.position.x)
			{
				turnAround = true;
			}
		}
		else
		{
			this.rigidbody.velocity *= -1;
			turnAround = false;
		}
	}
}
