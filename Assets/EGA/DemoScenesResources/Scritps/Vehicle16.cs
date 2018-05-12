using UnityEngine;
using System.Collections;

public class Vehicle16 : MonoBehaviour {


	public GameObject player;
	public Transform exitPoint;
	private CityManager manager;


	public LayerMask playerLayer;
	public float playerRange ;
	public bool inPlayerRange = false;


	public GameObject carCam16;


	void Start () {


		manager = FindObjectOfType<CityManager> ();

	}

	// Update is called once per frame
	void Update () {

		//Player Range

		inPlayerRange = Physics.OverlapSphere(transform.position, playerRange, playerLayer).Length >0f;


		//Manager Call for Cam Activation
		if (manager.inCar16) {

			carCam16.gameObject.SetActive (true);
		} else {
			carCam16.gameObject.SetActive (false);

		}
		////////////////////////
		// Get in/out Car

		if (inPlayerRange && Input.GetKeyDown (KeyCode.G)) {
			manager.inCar16 = true;
		} 
		if (manager.insideCar && Input.GetKeyDown (KeyCode.G)) {
			manager.inCar16 = false;
		} 


	//Activate Car Motor if inside 

		if (manager.inCar16) {


			this.gameObject.GetComponent<CarController> ().enabled = true;
			this.gameObject.GetComponent<CarUserControl> ().enabled = true;

			player.transform.position = exitPoint.transform.position;

		} 
		if (!manager.inCar16) {

			this.gameObject.GetComponent<CarController> ().enabled = false;
			this.gameObject.GetComponent<CarUserControl> ().enabled = false;
		}



	}
}
