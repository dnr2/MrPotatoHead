using UnityEngine;
using System.Collections;

public class ThrowHat : MonoBehaviour {

	public Animator animator;
	private bool attacking;
	private int attackingState;
	private Animator throwingHatAnimator;
	private GameObject throwingHatClone;
	private Vector3 offset;
	public GameObject throwingHatPrefab;  // the prefab that will be instantiated 
	public SkinnedMeshRenderer stationaryHatMesh;  // The hat on the model head

	// Use this for initialization
	void Start () {
		if (animator == null) {
			animator = GetComponent<Animator> ();
		}
		animator.SetBool("isAttack", false);
		attacking = false;
		throwingHatClone = null;
		attackingState = 0;

	}
	
	// Update is called once per frame
	void Update () {


		//TODO ugly code! =)
		bool runningInitialAnimation = animator.GetCurrentAnimatorStateInfo (0).IsName ("AttackHat");
		bool runningThrowingAnimation = false;
		if( throwingHatAnimator != null ) runningThrowingAnimation = throwingHatAnimator.GetCurrentAnimatorStateInfo (0).IsName("ThrowingHatAnimation");

		if (attacking) {
				
				animator.SetBool ("Jump", false);	
				
				throwingHatClone.transform.position = transform.position;
				throwingHatClone.transform.position += offset;
				
				if (attackingState == 0 && runningInitialAnimation ) {
					animator.SetBool ("isAttack", false);
					attackingState = 1;
				}		
				if (attackingState == 1 && !runningInitialAnimation ) {
					stationaryHatMesh.enabled = false;					
					
					//TODO talvez fazer isso depois de um delay
					if( this.transform.localScale.z < 0){
						Vector3 newRotation = new Vector3(0f,180f,0f);
						throwingHatClone.transform.eulerAngles = newRotation;
						offset = new Vector3( -4.35f, 2.48f, 0);
					} else {
						offset = new Vector3( 4.35f, 2.48f, 0);
					}
					attackingState = 2;
					throwingHatAnimator.SetBool ("throwing", true);
				}
		
				if (attackingState == 2 && runningThrowingAnimation ) {					
					throwingHatAnimator.SetBool("throwing", false);
					attackingState = 3;
				}
				
				if( attackingState == 3 && !runningThrowingAnimation){
					stationaryHatMesh.enabled = true;
					attacking = false;
					attackingState = 4;
					Destroy( throwingHatClone );	
					throwingHatClone = null;
					throwingHatAnimator = null;
				}
				

		} else {

			if( Input.GetKeyDown(KeyCode.Z) && throwingHatPrefab != null && stationaryHatMesh != null) { //TODO setar para "fire1"
							
				throwingHatClone =  Instantiate(throwingHatPrefab, throwingHatPrefab.transform.position, throwingHatPrefab.transform.rotation) as GameObject;	
				throwingHatAnimator =  GameObject.Find("ThrowingHatPhysics").GetComponent<Animator>();
				throwingHatAnimator.SetBool ("throwing", false);

				animator.SetBool("isAttack", true);
				attacking = true;
				attackingState = 0;
			}
		}
		

	}

	public void setAnimator( Animator newAnim ){
		this.animator = newAnim;
	}

	public void setStationaryHatMesh( SkinnedMeshRenderer stationaryHatMesh){ 
		this.stationaryHatMesh = stationaryHatMesh;
	}

}
