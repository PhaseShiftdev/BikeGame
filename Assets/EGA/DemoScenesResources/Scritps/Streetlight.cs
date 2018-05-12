using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class Streetlight : MonoBehaviour {


	private CityManager manager;


	void Start () {
		manager = FindObjectOfType<CityManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	

		if(manager.managerActive){


		if (manager.lights_Switcher == true) {

			this.gameObject.GetComponent<Light> ().enabled = true;
		
		} else {
			this.gameObject.GetComponent<Light> ().enabled = false;

		}
	}
			}

}
