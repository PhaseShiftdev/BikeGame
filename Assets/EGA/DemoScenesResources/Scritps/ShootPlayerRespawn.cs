using UnityEngine;
using System.Collections;

public class ShootPlayerRespawn : MonoBehaviour {

	public GameObject player;
	private Airplane airplane;
	public Transform playerRespawnPos;


	void Update(){

		if (Input.GetKeyDown( KeyCode.R)) {
			Instantiate (player, playerRespawnPos.transform.position, playerRespawnPos.transform.rotation);

		}
	}

	public void Respawn(){

	
		Instantiate (player, playerRespawnPos.transform.position, playerRespawnPos.transform.rotation);
	

	}
}
