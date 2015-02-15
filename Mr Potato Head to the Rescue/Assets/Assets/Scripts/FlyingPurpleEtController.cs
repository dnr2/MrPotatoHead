using UnityEngine;
using System.Collections;

public class FlyingPurpleEtController : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	
	private float fireRate = 3F;
	private float nextFire;
	private GameObject mrPotatoHead;
	private float flyingSpeed = 0.5f;
	
	private Vector3 center = new Vector3(59,30,0);
	private float radius = 3f;
	private float wanderRefreshRate = 2f;
	private float nextWanderRefresh;
	private float minDistance = 15f;
	private float maxDistance = 25f;
	
	// Use this for initialization
	void Start () {
		if(mrPotatoHead == null)
			mrPotatoHead = GameObject.FindWithTag("Player");
		center = new Vector3(mrPotatoHead.transform.position.x,mrPotatoHead.transform.position.y+15,0);
	}
	
	void FixedUpdate()
	{
		flipScale ();

		if(mrPotatoHead == null)
			mrPotatoHead = GameObject.FindWithTag("Player");
		
		if(distance (mrPotatoHead.transform.position, this.transform.position) <= minDistance)
		{
			Vector3 direction = new Vector3(this.transform.position.x - mrPotatoHead.transform.position.x, this.transform.position.y - mrPotatoHead.transform.position.y, 0);
			rigidbody.velocity = direction * flyingSpeed;
		}
		else if(distance (mrPotatoHead.transform.position, this.transform.position) >= maxDistance)
		{
			Vector3 direction = new Vector3(mrPotatoHead.transform.position.x - this.transform.position.x, mrPotatoHead.transform.position.y - this.transform.position.y, 0);
			rigidbody.velocity = direction * flyingSpeed;
		}
		else
		{
			if(Time.time > nextWanderRefresh)
			{
				nextWanderRefresh = Time.time + wanderRefreshRate;
				rigidbody.velocity = (center - nextVelocity());
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(mrPotatoHead == null)
			mrPotatoHead = GameObject.FindWithTag("Player");
		if(Time.time > nextFire && distance (mrPotatoHead.transform.position, this.transform.position) <= 40)
		{
			nextFire = Time.time + fireRate;
			shot.GetComponent<ProjectileController>().targetPos = new Vector3(mrPotatoHead.transform.position.x - 15, mrPotatoHead.transform.position.y, 0);
			Instantiate(shot, new Vector3(shotSpawn.transform.position.x-1,shotSpawn.transform.position.y,shotSpawn.transform.position.z), shotSpawn.transform.rotation);
			shot.GetComponent<ProjectileController>().targetPos = mrPotatoHead.transform.position;
			Instantiate(shot, new Vector3(shotSpawn.transform.position.x,shotSpawn.transform.position.y,shotSpawn.transform.position.z), shotSpawn.transform.rotation);
			shot.GetComponent<ProjectileController>().targetPos = new Vector3(mrPotatoHead.transform.position.x + 15, mrPotatoHead.transform.position.y, 0);;
			Instantiate(shot, new Vector3(shotSpawn.transform.position.x+1,shotSpawn.transform.position.y,shotSpawn.transform.position.z), shotSpawn.transform.rotation);
		}
	}

	private float distance(Vector3 a, Vector3 b)
	{
		return Mathf.Sqrt (Mathf.Pow (a.x - b.x, 2) + Mathf.Pow (a.y - b.y, 2) + Mathf.Pow (a.z - b.z, 2));
	}
	
	private Vector3 nextVelocity()
	{
		center = new Vector3(mrPotatoHead.transform.position.x,mrPotatoHead.transform.position.y+15,0);
		Vector3 randomPoint = new Vector3(Random.Range(center.x - radius, center.x + radius), Random.Range(center.y - radius, center.y + radius), 0);
		//print (randomPoint);
		return randomPoint;
	}

	private void flipScale(){
		Vector3 newScale;
		newScale = this.transform.localScale;
		if(this.transform.position.x < mrPotatoHead.transform.position.x){
			newScale.x = -Mathf.Abs(newScale.x);
		} else {
			newScale.x = Mathf.Abs(newScale.x);
		}
		this.transform.localScale = newScale;
	}

}
