using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour {
	public float moveSpeed = 5f;
	public float maxDistance = 7f;

	public bool flipAfterChangeDir = false;


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

			if( flipAfterChangeDir ){
				Vector3 newScale = this.transform.localScale;
				int mult = (this.rigidbody.velocity.x > 0)? 1: -1;
				newScale.x = mult * Mathf.Abs(newScale.x);
				this.transform.localScale = newScale;
			}

		}
	}
}
