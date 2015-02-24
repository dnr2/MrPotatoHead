using UnityEngine;
using System.Collections;

public class TennisBallController : MonoBehaviour {
	public Vector3 targetPos;
	private Vector3 startPos;
	public float speed = 30f;
	private Vector3 direction;
	private float maxDistance = 200;
	
	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		direction = targetPos - this.transform.position;
		direction = Vector3.Normalize(direction);
		this.rigidbody.velocity = direction * speed;
	}
	
	void OnTriggerEnter(Collider other)
	{
		print(other.gameObject.name);
		if(other.gameObject.GetComponent<HeatSeekingMissileController>() == null || other.gameObject.GetComponent<TennisBallController>() == null
		   || other.gameObject.GetComponent<ProjectileController>() == null || other.gameObject.GetComponent<RedProjectileController>() == null
		   || other.gameObject.GetComponent<ZurgController>() == null)
			Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(this.transform.position, startPos) > maxDistance)
			Destroy(gameObject);
	}
}
