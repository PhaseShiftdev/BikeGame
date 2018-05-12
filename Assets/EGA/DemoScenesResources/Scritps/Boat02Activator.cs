using UnityEngine;
using System.Collections;

public class Boat02Activator : MonoBehaviour {

	public GameObject player;
	public Transform exitPoint;
	private CityManager manager;


	public LayerMask playerLayer;
	public float playerRange ;
	public bool inPlayerRange = false;


	public GameObject boatCam02;


	void Start () {


		manager = FindObjectOfType<CityManager> ();

	}

	// Update is called once per frame
	void Update () {

		//Player Range

		inPlayerRange = Physics.OverlapSphere(transform.position, playerRange, playerLayer).Length >0f;


		//Manager Call for Cam Activation
		if (manager.inBoat02) {

			boatCam02.gameObject.SetActive (true);
		} else {
			boatCam02.gameObject.SetActive (false);

		}
		////////////////////////
		// Get in/out Boat

		if (inPlayerRange && Input.GetKeyDown (KeyCode.G)) {
			manager.inBoat02= true;
		} 
		if (manager.insideBoat && Input.GetKeyDown (KeyCode.G)) {
			manager.inBoat02 = false;
		} 


		//Activate Boat Motor if inside 

		if (manager.inBoat02) {


			this.gameObject.GetComponent<Boat> ().canControl = true;

			player.transform.position = exitPoint.transform.position;

		} else {


			this.gameObject.GetComponent<Boat> ().canControl = false;


		}

	}
}
