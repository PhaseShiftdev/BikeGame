using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

	public Animator anim;
	public bool jump = false;
	private SuperCharacterController player;
	public bool isGrounded = false;
	public bool walking = false;
	void Start () {

		player = FindObjectOfType<SuperCharacterController> ();

	}


	void Update () {


	

		//Jump

		if (Input.GetButtonUp ("Jump")&& !isGrounded ) {

			anim.SetBool ("jump", true);
			jump = true;
		} else {
			jump = false;
			anim.SetBool ("jump", false);
		}


		// Landing

		if (player.currentGround.IsGrounded(true, 0.5f) ) {

			isGrounded = true;
			anim.SetBool ("jump", false);


		} else {
			isGrounded = false;
			jump = true;
			anim.SetBool ("jump", true);
		}



	}
}