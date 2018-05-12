using UnityEngine;
using System.Collections;

public class RightDoor : MonoBehaviour {

	public bool open;
	public bool enter;

	public float playerRange;
	public LayerMask playerLayer;
	public bool playerInRange;
	public float openDegrees;
	public float closeDegrees;
	void Start(){

	}

	//Main function
	void Update (){


		playerInRange = Physics.OverlapSphere(transform.position, playerRange, playerLayer).Length >0f;

		if(open){

			SwingOpen();

		}else{

			SwingClose();
		}

		if(Input.GetKeyDown(KeyCode.E) && enter){
			open = !open;
		}


		if (playerInRange) {

			enter = true;


		} else {

			enter = false;


		}
	}
	void SwingOpen()
	{   
		Quaternion newRotation = Quaternion.AngleAxis(openDegrees, Vector3.up);
		transform.localRotation= Quaternion.Slerp(transform.localRotation, newRotation, .05f);
	}
	void SwingClose()
	{   
		Quaternion newRotation = Quaternion.AngleAxis(closeDegrees, Vector3.up);
		transform.localRotation= Quaternion.Slerp(transform.localRotation, newRotation, .05f);
	}


}