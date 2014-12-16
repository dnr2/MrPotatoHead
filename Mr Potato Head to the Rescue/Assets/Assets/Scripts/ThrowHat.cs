using UnityEngine;
using System.Collections;

public class ThrowHat : MonoBehaviour {

	private Animator animator;
	private bool attacking;
	private int attackingState;
	private Animator throwingHatAnimator;

	public GameObject throwingHat;
	public SkinnedMeshRenderer stationaryHatMesh;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		if( throwingHat != null ) throwingHatAnimator = throwingHat.GetComponent<Animator> ();
		animator.SetBool("isAttack", false);
		throwingHatAnimator.SetBool ("throwing", false);
		attacking = false;
		attackingState = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//TODO ugly code! =)
		bool runningInitialAnimation = animator.GetCurrentAnimatorStateInfo (0).IsName ("AttackHat");
		bool runningThrowingAnimation = throwingHatAnimator.GetCurrentAnimatorStateInfo (0).IsName ("ThrowingHatAnimation");


		if (attacking) {
				animator.SetBool ("Jump", false);
				if (attackingState == 0 && runningInitialAnimation ) {
					animator.SetBool ("isAttack", false);
					attackingState = 1;
				}
				if (attackingState == 1 && !runningInitialAnimation ) {
					stationaryHatMesh.enabled = false;
					throwingHatAnimator.SetBool ("throwing", true);
					attackingState = 2;
				}
				if (attackingState == 2 && runningThrowingAnimation ) {
					Debug.Log("seting throwing false");
					throwingHatAnimator.SetBool("throwing", false);
					attackingState = 3;
				}
				if( attackingState == 3 && !runningThrowingAnimation){
					stationaryHatMesh.enabled = true;
					attacking = false;
					attackingState = 4;
				}
		} else {
			if( Input.GetKeyDown(KeyCode.Z) && throwingHat != null && stationaryHatMesh != null) { //TODO setar para "fire1"
				animator.SetBool("isAttack", true);
				attacking = true;
				attackingState = 0;
			}
		}
	}
}
