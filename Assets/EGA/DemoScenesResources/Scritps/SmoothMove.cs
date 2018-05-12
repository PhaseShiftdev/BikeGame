using UnityEngine;
using System.Collections;

public class SmoothMove : MonoBehaviour {

	public float speed;
	public bool goUp;
	public bool goDown;
	public bool goLeft;
	public bool goRight;
	public bool goForward;
	public bool goBack;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (goUp) {
			transform.Translate(Vector3.up* speed * Time.smoothDeltaTime,Space.World); 	
		}
		if (goDown) {
			transform.Translate(Vector3.down* speed * Time.smoothDeltaTime,Space.World); 	
		}
		if (goLeft) {
			transform.Translate(Vector3.left* speed * Time.smoothDeltaTime,Space.World); 	
		}
		if (goRight) {
			transform.Translate(Vector3.right* speed * Time.smoothDeltaTime,Space.World); 	
		}
		if (goForward) {
			transform.Translate(Vector3.forward* speed * Time.smoothDeltaTime,Space.World); 	
		}
		if (goBack) {
			transform.Translate(Vector3.back* speed * Time.smoothDeltaTime,Space.World); 	
		}

	}
}
