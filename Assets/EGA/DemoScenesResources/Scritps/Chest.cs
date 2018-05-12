using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {
	public bool open;
	public float openDegrees = 90f;
	public float closeDegrees;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.O)){

			open = !open;

			
	}
		if (open) {
			Quaternion newRotation = Quaternion.AngleAxis(openDegrees, Vector3.right);
			transform.localRotation= Quaternion.Slerp(transform.localRotation, newRotation, .05f);
		}
		if (!open) {

			Quaternion newRotation = Quaternion.AngleAxis(closeDegrees, Vector3.left);
			transform.localRotation= Quaternion.Slerp(transform.localRotation, newRotation, .05f);
		}

}
}
