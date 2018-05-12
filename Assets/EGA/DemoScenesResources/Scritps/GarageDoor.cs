using UnityEngine;
using System.Collections;

public class GarageDoor : MonoBehaviour {
	public bool open;
	public bool enter;

	public float carRange = 5f ;
	public LayerMask carLayer;
	public bool carInRange;
	public float openDegrees;
	public float closeDegrees;





	void Start(){

	}

	//Main function
	void Update (){


		carInRange = Physics.OverlapSphere(transform.position, carRange, carLayer).Length >0f;


		if(open ){

			SwingOpen();

		}else{

			SwingClose();
		}



		if(Input.GetKeyDown(KeyCode.E) && enter){
			open = !open;
		}

		if (carInRange) {



			enter = true;


		} else {

			enter = false;


		}



	}
	void SwingOpen()
	{   
		Quaternion newRotation = Quaternion.AngleAxis(openDegrees, Vector3.forward);
		transform.localRotation= Quaternion.Slerp(transform.localRotation, newRotation, .05f);
	}
	void SwingClose()
	{   
		Quaternion newRotation = Quaternion.AngleAxis(closeDegrees, Vector3.forward);
		transform.localRotation= Quaternion.Slerp(transform.localRotation, newRotation, .05f);
	}



}