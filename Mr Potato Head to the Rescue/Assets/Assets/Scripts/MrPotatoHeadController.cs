using UnityEngine;
using System.Collections;

public class Boundary{
	
}

public class MrPotatoHeadController : MonoBehaviour 
{
	public float speed;

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = 0.0f; // so vai ser alterado ao pular

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		rigidbody.velocity = movement * speed;

	}

}
