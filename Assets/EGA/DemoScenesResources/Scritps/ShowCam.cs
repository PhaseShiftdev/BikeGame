using UnityEngine;
using System.Collections;

public class ShowCam : MonoBehaviour {

	public float speed;
	public bool goUp;
	public bool goForward;
	public Vector3 newPosition;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (goUp) {

			transform.Translate(Vector3.up* speed * Time.smoothDeltaTime,Space.World); 	
		
		}
		if (goForward) {

			transform.Translate(Vector3.forward* speed * Time.smoothDeltaTime,Space.World); 	

		}
		if(Input.GetKeyDown(KeyCode.Space)){
			this.transform.position = Vector3.Lerp (this.transform.position, newPosition, speed * Time.deltaTime);
		}

	}
}
