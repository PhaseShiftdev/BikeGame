using UnityEngine;
using System.Collections;

public class ColDetector : MonoBehaviour {

	private PlayerMachine machine;
	public bool inPlatform = false;
	public ParticleSystem snowParticles;


	void Start () {
		machine = FindObjectOfType<PlayerMachine> ();

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "JumpPlatform") {
			inPlatform = true;
			machine.Jump_EnterState ();

		}

	}
	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.tag == "JumpPlatform") {
			inPlatform = true;
		}
		if (col.gameObject.tag == "Snow") {

			GameObject go = snowParticles.gameObject;
			go.SetActive (true);

		
		} 

	}
		

	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.tag == "JumpPlatform") {
			inPlatform = false;
		}
		if (col.gameObject.tag == "Snow") {

			GameObject go = snowParticles.gameObject;
			go.SetActive (false);

		} 
	}


}
