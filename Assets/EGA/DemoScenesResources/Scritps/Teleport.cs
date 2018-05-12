using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {


	public Transform teleportPoint;
	private GameObject player;
	public bool teleporting;
	public bool teleported;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		StartCoroutine ("TeleportPlayer");


}

	IEnumerator TeleportPlayer()
	{

		teleporting = true;
	

		yield return new WaitForSeconds(0.3f);


		player.transform.position = teleportPoint.transform.position;


	}

}
