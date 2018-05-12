using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {


	private Vector3 CamPosition;
	public GameObject target; 
	public float camHeight = 2f;
	public float camRadius = 6f;
	public float targetHeight = 1.5f;

	private RaycastHit rayHit;
	private float tempRadius;

	public float damp = 3f;


	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var MainPosition=new Vector3(target.transform.position.x,target.transform.position.y+camHeight,target.transform.position.z);
		var hit = Physics.Raycast (MainPosition, target.transform.forward * (-1f), out rayHit, camRadius);
		tempRadius = hit ? rayHit.distance - 0.25f : camRadius;

		CamPosition=new Vector3(target.transform.position.x,target.transform.position.y+camHeight,
			target.transform.position.z)+target.transform.forward*(-1f)*tempRadius;



		transform.LookAt (new Vector3(target.transform.position.x,target.transform.position.y+targetHeight,
			target.transform.position.z));

		transform.position = Vector3.Slerp (transform.position, CamPosition, Time.deltaTime * damp);

	}

}
