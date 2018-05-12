using UnityEngine;
using System.Collections;

public class SnowboardAnim : MonoBehaviour {

	private SuperCharacterController player;
	private PlayerInputController inputs;
	public bool isGrounded = true;
	private ColDetector collDetec;
	public float maxScale = 1.2f;
	public float minScale = 1.1f;
	public float scaleSpeed = 0.1f;
	private bool scaleDown;
	private Vector3 targetScale;


	void Start () {
		
		player = FindObjectOfType<SuperCharacterController> ();
		inputs = FindObjectOfType<PlayerInputController> ();
		collDetec = FindObjectOfType<ColDetector> ();

	}
	

	void Update () {

		if (scaleDown) {
			this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, scaleSpeed);
			targetScale.Set (minScale, minScale, minScale);
		} else {
			this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, scaleSpeed);
			targetScale.Set (maxScale, maxScale, maxScale);
		}
	

		//Prepare to jump

		if (Input.GetButton ("Jump") && isGrounded || collDetec.inPlatform == true) {
			scaleDown = true;
		
		} 


		//Jump

		if (Input.GetButtonUp ("Jump")&& !isGrounded || collDetec.inPlatform == false && !isGrounded) {
			
			scaleDown = false;

			}


		// Landing

		if (player.currentGround.IsGrounded(true, 0.8f) && collDetec.inPlatform == false) {

			isGrounded = true;

			inputs.stickMultiplier = new Vector2(1.5f, 1.5f);


		} else {
			isGrounded = false;

			inputs.stickMultiplier = new Vector2(5, 5);
		}



}
}