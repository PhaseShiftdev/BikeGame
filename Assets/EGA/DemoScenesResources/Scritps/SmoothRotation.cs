using UnityEngine;
using System.Collections;

public class SmoothRotation : MonoBehaviour {


	public float speed;
	public bool rotUp;
	public bool rotDown;
	public bool rotLeft;
	public bool rotRight;
	public bool rotForward;
	public bool rotBack;

	void Start () {
		
	}


	void FixedUpdate () {

		if (rotUp) {
			transform.Rotate (Vector3.up * speed * Time.fixedDeltaTime, Space.World);
		}
		if (rotDown) {
			transform.Rotate (Vector3.down * speed * Time.fixedDeltaTime, Space.World);
		}
		if (rotLeft) {
			transform.Rotate (Vector3.left * speed * Time.fixedDeltaTime, Space.World);
		}
		if (rotRight) {
			transform.Rotate (Vector3.right * speed * Time.fixedDeltaTime, Space.World);
		}
		if (rotForward) {
			transform.Rotate (Vector3.forward * speed * Time.fixedDeltaTime, Space.World);
		}
		if (rotBack) {
			transform.Rotate (Vector3.back * speed * Time.fixedDeltaTime, Space.World);
		}




	}
}
