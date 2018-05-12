using UnityEngine;
using System.Collections;

public class ForestMovement : MonoBehaviour {

	public float speed = 5.0f;
	public bool goAhead;
	public bool goLeft;
	public bool goRight;
	private float posY;
	private float posX;
	//public Transform start;
	public float startPos = 22;

	void Start () {
		posY = this.transform.position.y;
		posX = this.transform.position.x;
	}

	// Update is called once per frame
	void Update () {

		if (goAhead) {
			transform.Translate(Vector3.back * Time.deltaTime * speed);

		}
		if (goLeft) {
			transform.Translate(Vector3.left * Time.deltaTime * speed);

		}
		if (goRight) {
			transform.Translate(Vector3.right * Time.deltaTime * speed);

		}

	



	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Finish") {
			this.transform.position = new Vector3 (posX, posY, startPos-0.05f );


		}
	}
}