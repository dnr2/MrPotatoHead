using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour {
	private float moveSpeed = 5f;
	private float maxDistance = 7f;
	private Vector3 origin;
	// Use this for initialization
	void Start () {
		origin = this.transform.position;
		this.rigidbody.velocity = new Vector3(1,0,0) * moveSpeed;
	}
	
	void Update () {
		if(Vector3.Distance(origin, this.transform.position) > maxDistance)
		{
			if(this.transform.position.x < origin.x)
			{
				this.rigidbody.velocity = new Vector3(1,0,0) * moveSpeed;
			}
			else if(this.transform.position.x > origin.x)
			{
				this.rigidbody.velocity = new Vector3(-1,0,0) * moveSpeed;
			}
		}
	}
}
