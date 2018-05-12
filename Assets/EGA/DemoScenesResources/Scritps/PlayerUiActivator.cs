using UnityEngine;
using System.Collections;

public class PlayerUiActivator : MonoBehaviour {

	public float doorRange ;
	public LayerMask doorLayer;
	public bool inDoorRange = false;
	public GameObject doorUiText;

	public bool inCarRange = false;
	public LayerMask carLayer;
	public float carRange ;

	public float arcadeCabRange ;
	public LayerMask arcadeCabLayer;
	public bool inArcadeCabRange = false;
	public GameObject arcadeUiText;

	public bool inBoatRange = false;
	public LayerMask boatLayer;
	public float boatRange ;

	public float carDoorRange ;
	public LayerMask carDoorLayer;
	public bool inCarDoorRange = false;
	public GameObject carDoorUiText;



	private CityManager manager;

	void Start () {
		

		manager = FindObjectOfType<CityManager> ();


	}


	
	// Update is called once per frame
	void Update () {

		//For UI Activator only
		inCarRange = Physics.OverlapSphere(transform.position, carRange, carLayer).Length >0f;
		inBoatRange = Physics.OverlapSphere(transform.position, boatRange, boatLayer).Length >0f;
        inArcadeCabRange = Physics.OverlapSphere(transform.position, arcadeCabRange, arcadeCabLayer).Length >0f;
		inDoorRange = Physics.OverlapSphere(transform.position, doorRange, doorLayer).Length >0f;
		inCarDoorRange = Physics.OverlapSphere(transform.position, carDoorRange, carDoorLayer).Length >0f;


		if (inArcadeCabRange) {

			arcadeUiText.gameObject.SetActive (true);


		} else {

			arcadeUiText.gameObject.SetActive (false);


		}





		if (inDoorRange) {

			doorUiText.gameObject.SetActive (true);


		} else {

			doorUiText.gameObject.SetActive (false);


		}

		if (inCarDoorRange) {

			carDoorUiText.gameObject.SetActive (true);


		} else {

			carDoorUiText.gameObject.SetActive (false);


		}






        





	
	
	}

	//Arcade Shop Camera Changer
	void OnTriggerEnter (Collider other)
	{
		if (other.transform.name == "CamChanger")
			manager.inArcadeShop = true;
	}
	void OnTriggerExit (Collider other)
	{
		if (other.transform.name == "CamChanger")
			manager.inArcadeShop = false;
	}
}
