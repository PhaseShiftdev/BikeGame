using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	public float timeOn;
	public float timeOff;
	private float changeTime = 0;
	void Update() {
		if (Time.time > changeTime) {
			GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
			if (GetComponent<Light>().enabled) {
				changeTime = Time.time + timeOn;
			} else {
				changeTime = Time.time + timeOff;
			}
		}
	}
}