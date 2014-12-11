using UnityEngine;
using System.Collections;

public class ThrowHat : MonoBehaviour {

	private Animator animator;
	private bool attacking;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool("isAttack", false);
		attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(! attacking && Input.GetKeyDown(KeyCode.Z)) {
			animator.SetBool("isAttack", true);
			attacking = true;
		}
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("AttackHat")) {
			animator.SetBool("isAttack", false);
			attacking = false;
		}
	}
}
