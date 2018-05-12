using UnityEngine;
using System.Collections;

public class SnowBoardCam : MonoBehaviour {

	public float Distance = 5.0f;
	public float Height = 2.0f;

	public GameObject PlayerTarget;    

	private Transform target;
	private PlayerMachine machine;
	public  float yRotation;

	private SuperCharacterController controller;

	// Use this for initialization
	void Start () {
		machine = PlayerTarget.GetComponent<PlayerMachine>();
		controller = PlayerTarget.GetComponent<SuperCharacterController>();
		target = PlayerTarget.transform;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = target.position;


		Vector3 left = Vector3.Cross(machine.lookDirection, controller.up);

		transform.rotation = Quaternion.LookRotation(machine.lookDirection, controller.up);
		transform.rotation = Quaternion.AngleAxis(yRotation, left) * transform.rotation;

		transform.position -= transform.forward * Distance;
		transform.position += controller.up * Height;
	}
}
