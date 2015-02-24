using UnityEngine;
using System.Collections;

public class ZurgController : MonoBehaviour {
	public GameObject tennisBall;
	public GameObject heatSeekingMissile;
	public GameObject flyingPurpleET;
	public GameObject shotSpawn;
	public GameObject Minion;
	
	private GameObject mrPotato;
	
	private float tennisBallFireRate = 0.1f;
	private float tennisBallReload = 4f;
	private float minionSpawnReload = 30f;
	private float nextMinionSpawn;
	private float missileFireRate = 1f;
	private float missileReload = 10f;
	private float nextTennisBallFire;
	private float nextMissileFire;
	private int bullets;
	private int missiles;
	private int state;
	private int side;
	
	private Vector3 target;
	// Use this for initialization
	void Start () {
		mrPotato = GameObject.FindWithTag("Player");
		state = 0;
		side = 1;
		bullets = 3;
		missiles = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if(state == 0)
		{//bolas de tenis
			shotSpawn.transform.position = new Vector3(this.transform.position.x,this.transform.position.y + 2f, this.transform.position.z + 2.07f);
			if(Time.time > nextTennisBallFire)
			{
				if(bullets == 3)
				{
					side = Random.Range(2,6)/2;
					if(side == 1)
					{
						this.transform.position = new Vector3(mrPotato.transform.position.x + Random.Range(15,25), mrPotato.transform.position.y, mrPotato.transform.position.z);
						target = new Vector3(this.shotSpawn.transform.position.x - 1, this.shotSpawn.transform.position.y, this.shotSpawn.transform.position.z);
						this.transform.rotation = new Quaternion(0,270,0,0);
					}
					else
					{
						this.transform.position = new Vector3(mrPotato.transform.position.x - Random.Range(15,25), mrPotato.transform.position.y, mrPotato.transform.position.z);
						target = new Vector3(this.shotSpawn.transform.position.x + 1, this.shotSpawn.transform.position.y, this.shotSpawn.transform.position.z);
						this.transform.rotation = new Quaternion(0,90,0,0);
					}
					tennisBall.GetComponent<TennisBallController>().targetPos = target;
					Instantiate(tennisBall, shotSpawn.transform.position, shotSpawn.transform.rotation);
					nextTennisBallFire = Time.time + tennisBallFireRate;
					bullets -= 1;
				}
				else if(bullets < 3 && bullets > 0)
				{
					Instantiate(tennisBall, shotSpawn.transform.position, shotSpawn.transform.rotation);
					nextTennisBallFire = Time.time + tennisBallFireRate;
					bullets -= 1;
				}
				else if(bullets == 0)
				{
					bullets = 3;
					nextTennisBallFire = Time.time + tennisBallReload;
					state = 1;
				}
			}
			else if(bullets == 3 && Time.time <= nextTennisBallFire)
			{
				state = 1;
			}
		}
		else if(state == 1)
		{//missil
			shotSpawn.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-4f,this.transform.position.z);
			if(Time.time > nextMissileFire)
			{
				if(missiles == 5)
				{
					this.transform.position = new Vector3(this.mrPotato.transform.position.x, this.transform.position.y + Random.Range(25,30), this.transform.position.z);
					target = new Vector3(this.shotSpawn.transform.position.x, this.shotSpawn.transform.position.y - 1, this.shotSpawn.transform.position.z);
					heatSeekingMissile.GetComponent<HeatSeekingMissileController>().targetPos = target;
					Instantiate(heatSeekingMissile, shotSpawn.transform.position, shotSpawn.transform.rotation);
					nextMissileFire = Time.time + missileFireRate;
					missiles -= 1;
				}
				else if(missiles == 4)
				{
					this.transform.position = new Vector3(this.transform.position.x + (missiles*5), this.transform.position.y, this.transform.position.z);
					target = new Vector3(this.shotSpawn.transform.position.x, this.shotSpawn.transform.position.y - 1, this.shotSpawn.transform.position.z);
					Instantiate(heatSeekingMissile, shotSpawn.transform.position, shotSpawn.transform.rotation);
					nextMissileFire = Time.time + missileFireRate;
					missiles -= 1;
				}
				else if(missiles == 3)
				{
					this.transform.position = new Vector3(this.transform.position.x - (missiles*5), this.transform.position.y, this.transform.position.z);
					target = new Vector3(this.shotSpawn.transform.position.x, this.shotSpawn.transform.position.y - 1, this.shotSpawn.transform.position.z);
					Instantiate(heatSeekingMissile, shotSpawn.transform.position, shotSpawn.transform.rotation);
					nextMissileFire = Time.time + missileFireRate;
					missiles -= 1;
				}
				else if(missiles == 2)
				{
					this.transform.position = new Vector3(this.transform.position.x + (missiles*5), this.transform.position.y, this.transform.position.z);
					target = new Vector3(this.shotSpawn.transform.position.x, this.shotSpawn.transform.position.y - 1, this.shotSpawn.transform.position.z);
					Instantiate(heatSeekingMissile, shotSpawn.transform.position, shotSpawn.transform.rotation);
					nextMissileFire = Time.time + missileFireRate;
					missiles -= 1;
				}
				else if(missiles == 1)
				{
					this.transform.position = new Vector3(this.transform.position.x - (missiles*5), this.transform.position.y, this.transform.position.z);
					target = new Vector3(this.shotSpawn.transform.position.x, this.shotSpawn.transform.position.y - 1, this.shotSpawn.transform.position.z);
					Instantiate(heatSeekingMissile, shotSpawn.transform.position, shotSpawn.transform.rotation);
					nextMissileFire = Time.time + missileFireRate;
					missiles -= 1;
				}
				else if(missiles == 0)
				{
					missiles = 5;
					nextMissileFire = Time.time + missileReload;
					state = 2;
				}
			}
			else if(missiles == 5 && Time.time <= nextMissileFire)
			{
				state = 2;
			}
		}
		else if(state == 2)
		{// 4 ets
			if(Time.time > nextMinionSpawn)
			{
				Instantiate(Minion, new Vector3(shotSpawn.transform.position.x-20, shotSpawn.transform.position.y, shotSpawn.transform.position.z), shotSpawn.transform.rotation);
				Instantiate(Minion, new Vector3(shotSpawn.transform.position.x-10, shotSpawn.transform.position.y, shotSpawn.transform.position.z), shotSpawn.transform.rotation);
				Instantiate(Minion, new Vector3(shotSpawn.transform.position.x+10, shotSpawn.transform.position.y, shotSpawn.transform.position.z), shotSpawn.transform.rotation);
				Instantiate(Minion, new Vector3(shotSpawn.transform.position.x+20, shotSpawn.transform.position.y, shotSpawn.transform.position.z), shotSpawn.transform.rotation);
				nextMinionSpawn = Time.time + minionSpawnReload;
			}
			else
			{
				state = 0;
			}
		}
	}
}
