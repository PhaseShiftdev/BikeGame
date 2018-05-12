using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]

public class CityManager : MonoBehaviour {

	public bool insideCar;
	public bool insideBoat;

	public bool inCar01;
	public bool inCar02;
	public bool inCar03;
	public bool inCar04;
	public bool inCar05;
	public bool inCar06;
	public bool inCar07;
	public bool inCar08;
	public bool inCar09;
	public bool inCar10;
	public bool inCar11;
	public bool inCar12;
	public bool inCar13;
	public bool inCar14;
	public bool inCar15;
	public bool inCar16;
	public bool inCar17;
	public bool inCar18;
	public bool inBoat01;
	public bool inBoat02;


	public bool inArcadeShop;
	public GameObject playerCam;
	public GameObject player;
	public GameObject arcadeCam;
	public bool inArcadeGame;
	public bool aiFalse;

	private PlayerUiActivator activator;

	public GameObject carUiText;
	public GameObject boatUiText;



	public bool lights_Switcher = false;

	public GameObject sun;

	public string levelForLoad;
	public bool managerActive = false;

	public bool inRace;
	public GameObject raceObjects;






	void Start () {
		
		activator = FindObjectOfType<PlayerUiActivator> ();


	}

	// Update is called once per frame
	void Update () {


	
	



		if (Input.GetKeyDown(KeyCode.F5)){
			inRace = true;
		}
		if (Input.GetKeyDown(KeyCode.F6)){
			inRace = false;
		}



		if (inRace) {
			raceObjects.gameObject.SetActive (true);
			playerCam.gameObject.SetActive (false);
			player.gameObject.SetActive (false);



		} else {


		}



		if (inCar01 || inCar02 || inCar03 || inCar04 || inCar05 || inCar06 || inCar07 || inCar08 || inCar09 || inCar10 || inCar11 || inCar12 || inCar13 || inCar14 || inCar15 || inCar16 || inCar17 || inCar18) {
			insideCar = true;
		} else {

			insideCar = false;

		}

		if (inBoat01 || inBoat02) {
			insideBoat = true;

		} else {
			insideBoat = false;

		}



		if (managerActive) {

			if (lights_Switcher == true) {
				RenderSettings.ambientIntensity = 0.5f;
				sun.gameObject.SetActive (false);
			} else {
				RenderSettings.ambientIntensity = 1.4f;
				sun.gameObject.SetActive (true);


			}


			//Car Text UI
			if (activator.inCarRange) {

				carUiText.gameObject.SetActive (true);

			}
			if (insideCar == true || !activator.inCarRange) {

				carUiText.gameObject.SetActive (false);

			}

			//Boat Text UI
			if (activator.inBoatRange) {

				boatUiText.gameObject.SetActive (true);

			}
			if (insideBoat == true || !activator.inBoatRange) {

				boatUiText.gameObject.SetActive (false);

			}






			//Player Cam off when takes vehicles
			if (!insideCar || !inArcadeShop || !insideBoat || !inRace) {
				playerCam.gameObject.SetActive (true);


				//Play Arcade Game
				if (activator.inArcadeCabRange && Input.GetKeyDown (KeyCode.P)) {
					SceneManager.LoadScene (levelForLoad);
				}
			}




			//Player Off
			if (insideCar || insideBoat || inRace ) {

				player.gameObject.SetActive (false);
				playerCam.gameObject.SetActive (false);


			} else {
				player.gameObject.SetActive (true);
				playerCam.gameObject.SetActive (true);

			}



			//InArcadeShop
			if (inArcadeShop) {

				playerCam.gameObject.SetActive (false);
				arcadeCam.gameObject.SetActive (true);


			} 
			//OutsideArcadeShop
			if (!inArcadeShop && !insideCar && !insideBoat && !inRace) {

				playerCam.gameObject.SetActive (true);
				arcadeCam.gameObject.SetActive (false);


			} 





		}
	}
}



