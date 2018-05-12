using UnityEngine;
using System.Collections;

public class Boat01Activator : MonoBehaviour {

	public GameObject player;
	public Transform exitPoint;
	private CityManager manager;


	public LayerMask playerLayer;
	public float playerRange ;
	public bool inPlayerRange = false;


	public GameObject boatCam01;


	void Start () {


		manager = FindObjectOfType<CityManager> ();

	}

	// Update is called once per frame
	void Update () {

		//Player Range

		inPlayerRange = Physics.OverlapSphere(transform.position, playerRange, playerLayer).Length >0f;


		//Manager Call for Cam Activation
		if (manager.inBoat01) {

			boatCam01.gameObject.SetActive (true);
		} else {
			boatCam01.gameObject.SetActive (false);

		}
		////////////////////////
		// Get in/out Boat

		if (inPlayerRange && Input.GetKeyDown (KeyCode.G)) {
			manager.inBoat01= true;
		} 
		if (manager.insideBoat && Input.GetKeyDown (KeyCode.G)) {
			manager.inBoat01 = false;
		} 


		//Activate Boat Motor if inside 

		if (manager.inBoat01) {


			this.gameObject.GetComponent<Boat> ().canControl = true;

			player.transform.position = exitPoint.transform.position;

		} else {


			this.gameObject.GetComponent<Boat> ().canControl = false;


		}

	}
}
