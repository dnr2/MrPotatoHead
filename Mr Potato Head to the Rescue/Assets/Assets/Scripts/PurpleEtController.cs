using UnityEngine;
using System.Collections;

public class PurpleEtController : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 1F;
	private Animator anim;
	
	private Vector3 YAxis = new Vector3(0,1,0);
	private float nextFire;
	private GameObject mrPotatoHead;
	private float maxDistance = 40f;

	// Use this for initialization
	void Start () {
		if(mrPotatoHead == null)
			mrPotatoHead = GameObject.FindWithTag("Player");
		anim = GetComponent<Animator>();
		anim.SetBool("IsAttacking", false);
	}
	
	// Update is called once per frame
	void Update () {
		if(mrPotatoHead == null)
			mrPotatoHead = GameObject.FindWithTag("Player");
		if (Time.time > nextFire && distance (mrPotatoHead.transform.position, this.transform.position) < maxDistance) {
			anim.SetBool ("IsAttacking", true);			
			flipScale();
			nextFire = Time.time + fireRate;
			shot.GetComponent<ProjectileController> ().targetPos = mrPotatoHead.transform.position;
			
			Instantiate (shot, shotSpawn.transform.position, shotSpawn.transform.rotation);

		} else {
			anim.SetBool("IsAttacking", false);
		}
	}
	
	private float distance(Vector3 a, Vector3 b)
	{
		return Mathf.Sqrt (Mathf.Pow (a.x - b.x, 2) + Mathf.Pow (a.y - b.y, 2) + Mathf.Pow (a.z - b.z, 2));
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
