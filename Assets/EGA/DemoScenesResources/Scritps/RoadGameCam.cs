using UnityEngine;
using System.Collections;

public class RoadGameCam : MonoBehaviour {

	public Transform Player;
	public float offset;
	void Update()
	{
		transform.position = new Vector3( transform.position.x, transform.position.y, Player.position.z - offset);
	}
}