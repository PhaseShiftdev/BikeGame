﻿using UnityEngine;
using System.Collections;

public class Vehicle11 : MonoBehaviour {


	public GameObject player;
	public Transform exitPoint;
	private CityManager manager;


	public LayerMask playerLayer;
	public float playerRange ;
	public bool inPlayerRange = false;


	public GameObject carCam11;


	void Start () {


		manager = FindObjectOfType<CityManager> ();

	}

	// Update is called once per frame
	void Update () {

		//Player Range

		inPlayerRange = Physics.OverlapSphere(transform.position, playerRange, playerLayer).Length >0f;


		//Manager Call for Cam Activation
		if (manager.inCar11) {

			carCam11.gameObject.SetActive (true);
		} else {
			carCam11.gameObject.SetActive (false);

		}
		////////////////////////
		// Get in/out Car

		if (inPlayerRange && Input.GetKeyDown (KeyCode.G)) {
			manager.inCar11 = true;
		} 
		if (manager.insideCar && Input.GetKeyDown (KeyCode.G)) {
			manager.inCar11 = false;
		} 


	//Activate Car Motor if inside 

		if (manager.inCar11) {


			this.gameObject.GetComponent<CarController> ().enabled = true;
			this.gameObject.GetComponent<CarUserControl> ().enabled = true;

			player.transform.position = exitPoint.transform.position;

		} 
		if (!manager.inCar11) {

			this.gameObject.GetComponent<CarController> ().enabled = false;
			this.gameObject.GetComponent<CarUserControl> ().enabled = false;
		}



	}
}
