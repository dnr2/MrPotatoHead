using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	public Vector3 targetPos;
	public int type;
	
	private float speed = 30f;
	private Vector3 startPos;
	private Vector3 XAxis = new Vector3(1,0,0);
	private Vector3 ZAxis = new Vector3(0,0,1);
	// Use this for initialization
	void Start () {
		this.calculateProjectileRotation();
		startPos = this.transform.position;
	}

	void OnTriggerEnter(Collider other) {
		if(other.GetComponent<ProjectileController>() == null || other.GetComponent<RedProjectileController>() == null)
		{
			/*if(other.gameObject.tag == "Player")
			{
				Object.Destroy (other.gameObject);
				//GameObject P = (GameObject)GameObject.Instantiate (player, spawnPoint.position, player.transform.rotation);
				MainCameraController c = Camera.main.GetComponent <MainCameraController>();
				//c.target = P.transform;
			}*/
			Destroy(gameObject);
		}
	}
	
	void Update()
	{
		if(distance(startPos, transform.position) > 200)
			Destroy(gameObject);
	}
	
	private void calculateProjectileRotation()
	{
		Vector3 direction = new Vector3(targetPos.x - this.transform.position.x, targetPos.y - this.transform.position.y, 0);
		direction = Vector3.Normalize(direction);
		float cos = scalarProduct(direction, XAxis/(norm(direction)*norm(XAxis)));
		if (targetPos.y - this.transform.position.y < 0) {
			this.transform.Rotate (ZAxis, 90 - toEulerDegrees (Mathf.Acos (cos)));
		} else {
			this.transform.Rotate (ZAxis, toEulerDegrees (Mathf.Acos (cos))-90);
		}
		this.rigidbody.velocity = direction * speed;
	}

	private float toEulerDegrees(float radians)
	{
		return radians * (180 / Mathf.PI);
	}

	private float scalarProduct(Vector3 a, Vector3 b)
	{
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}
	
	private float norm(Vector3 a)
	{
		return Mathf.Sqrt(scalarProduct(a,a));
	}
	
	private float distance(Vector3 a, Vector3 b)
	{
		return Mathf.Sqrt (Mathf.Pow (a.x - b.x, 2) + Mathf.Pow (a.y - b.y, 2) + Mathf.Pow (a.z - b.z, 2));
	}
}
