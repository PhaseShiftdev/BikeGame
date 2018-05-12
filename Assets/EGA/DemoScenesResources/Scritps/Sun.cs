using UnityEngine;
using System.Collections;
public class Sun : MonoBehaviour {

	public float speed;
	public bool rotate;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (rotate) {
			
			transform.Rotate (Vector3.up * speed * Time.fixedDeltaTime, Space.World);
			transform.Rotate (Vector3.left * speed * Time.fixedDeltaTime, Space.World);


		}
	}
}
