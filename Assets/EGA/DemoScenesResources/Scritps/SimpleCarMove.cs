using UnityEngine;
using System.Collections;

public class SimpleCarMove : MonoBehaviour {

	public float speed = 5.0f;
	public bool goLeft;
	public bool goRight;
	private float posY;
	private float posZ;
	//public Transform start;
	public float startPos = -25;

	void Awake () {
		posY = this.transform.position.y;
		posZ = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (goLeft) {
			transform.Translate(Vector3.left * Time.deltaTime * speed,Space.World);

		}
		if (goRight) {
			transform.Translate(Vector3.right * Time.deltaTime * speed,Space.World);

		}
	

			
		}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Finish") {
			this.transform.position = new Vector3 (startPos, posY, posZ);


	}
}
}