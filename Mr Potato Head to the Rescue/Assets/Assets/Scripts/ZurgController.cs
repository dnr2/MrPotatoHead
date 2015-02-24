using UnityEngine;
using System.Collections;

public class ZurgController : MonoBehaviour {
	public GameObject tennisBall;
	public GameObject heatSeekingMissile;
	public GameObject tennisShotSpawn;
	public GameObject missileShotSpawn;
	public GameObject Minion;
	public Transform[] tenisBallPositions;


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
	private float LastTimeHit;


	private Vector3 target;

	public int zurgHPPoints = 50;
	public float timeToNextDamage = 1;

	// Use this for initialization
	void Start () {
		mrPotato = GameObject.FindWithTag("Player");
		state = 0;
		side = 1;
		bullets = 3;
		missiles = 5;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "weapon" && (Time.time - LastTimeHit) > timeToNextDamage) {
			zurgHPPoints -= 1;
			AudioSource.PlayClipAtPoint(audio.clip, this.gameObject.transform.position );
			if( zurgHPPoints <= 0){
				playDeathAnimation();
			}
			LastTimeHit = Time.time;
		}
	}

	void playDeathAnimation(){
		Application.LoadLevel("StartMenu");
	}

	// Update is called once per frame
	void Update () {

		if(mrPotato == null)
			mrPotato = GameObject.FindWithTag("Player");


		if(state == 0)
		{//bolas de tenis

			if(Time.time > nextTennisBallFire)
			{
				if(bullets == 3)
				{
					int pos = Random.Range(0,tenisBallPositions.Length);
					this.transform.position = tenisBallPositions[pos].position;
					target = new Vector3(mrPotato.transform.position.x, this.tennisShotSpawn.transform.position.y, this.tennisShotSpawn.transform.position.z);
					 
					if( this.tennisShotSpawn.transform.position.x - mrPotato.transform.position.x > 0 )
					{
						transform.localEulerAngles = new Vector3(0,270,0);
					}
					else
					{
						transform.localEulerAngles = new Vector3(0,90,0);
					}
					tennisBall.GetComponent<TennisBallController>().targetPos = target;
					Instantiate(tennisBall, tennisShotSpawn.transform.position, tennisShotSpawn.transform.rotation);
					nextTennisBallFire = Time.time + tennisBallFireRate;
					bullets -= 1;
				}
				else if(bullets < 3 && bullets > 0)
				{
					Instantiate(tennisBall, tennisShotSpawn.transform.position, tennisShotSpawn.transform.rotation);
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
			if(Time.time > nextMissileFire)
			{
				if(missiles == 5)
				{
					transform.localEulerAngles = new Vector3(0,180,0);
					this.transform.position = new Vector3(this.mrPotato.transform.position.x, this.transform.position.y + Random.Range(20,30), this.transform.position.z);
					target = new Vector3(this.missileShotSpawn.transform.position.x, mrPotato.transform.position.y - 1, this.missileShotSpawn.transform.position.z);
					heatSeekingMissile.GetComponent<HeatSeekingMissileController>().targetPos = target;
					Instantiate(heatSeekingMissile, missileShotSpawn.transform.position, missileShotSpawn.transform.rotation);
					nextMissileFire = Time.time + missileFireRate;
					missiles -= 1;
				}
				else if(missiles == 4)
				{
					this.transform.position = new Vector3(this.transform.position.x + (missiles*5), this.transform.position.y, this.transform.position.z);
					target = new Vector3(this.missileShotSpawn.transform.position.x, mrPotato.transform.position.y - 1, this.missileShotSpawn.transform.position.z);
					Instantiate(heatSeekingMissile, missileShotSpawn.transform.position, missileShotSpawn.transform.rotation);
					nextMissileFire = Time.time + missileFireRate;
					missiles -= 1;
				}
				else if(missiles == 3)
				{
					this.transform.position = new Vector3(this.transform.position.x - (missiles*5), this.transform.position.y, this.transform.position.z);
					target = new Vector3(this.missileShotSpawn.transform.position.x, mrPotato.transform.position.y - 1, this.missileShotSpawn.transform.position.z);
					Instantiate(heatSeekingMissile, missileShotSpawn.transform.position, missileShotSpawn.transform.rotation);
					nextMissileFire = Time.time + missileFireRate;
					missiles -= 1;
				}
				else if(missiles == 2)
				{
					this.transform.position = new Vector3(this.transform.position.x + (missiles*5), this.transform.position.y, this.transform.position.z);
					target = new Vector3(this.missileShotSpawn.transform.position.x, mrPotato.transform.position.y - 1, this.missileShotSpawn.transform.position.z);
					Instantiate(heatSeekingMissile, missileShotSpawn.transform.position, missileShotSpawn.transform.rotation);
					nextMissileFire = Time.time + missileFireRate;
					missiles -= 1;
				}
				else if(missiles == 1)
				{
					this.transform.position = new Vector3(this.transform.position.x - (missiles*5), this.transform.position.y, this.transform.position.z);
					target = new Vector3(this.missileShotSpawn.transform.position.x, mrPotato.transform.position.y - 1, this.missileShotSpawn.transform.position.z);
					Instantiate(heatSeekingMissile, missileShotSpawn.transform.position, missileShotSpawn.transform.rotation);
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
				Instantiate(Minion, new Vector3(missileShotSpawn.transform.position.x-20, missileShotSpawn.transform.position.y+10, missileShotSpawn.transform.position.z), missileShotSpawn.transform.rotation);
				Instantiate(Minion, new Vector3(missileShotSpawn.transform.position.x-10, missileShotSpawn.transform.position.y+10, missileShotSpawn.transform.position.z), missileShotSpawn.transform.rotation);
				Instantiate(Minion, new Vector3(missileShotSpawn.transform.position.x+10, missileShotSpawn.transform.position.y+10, missileShotSpawn.transform.position.z), missileShotSpawn.transform.rotation);
				Instantiate(Minion, new Vector3(missileShotSpawn.transform.position.x+20, missileShotSpawn.transform.position.y+10, missileShotSpawn.transform.position.z), missileShotSpawn.transform.rotation);
				nextMinionSpawn = Time.time + minionSpawnReload;
			}
			else
			{
				state = 0;
			}
		}
	}
}
