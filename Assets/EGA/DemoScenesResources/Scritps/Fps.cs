using UnityEngine;
using System.Collections;

public class Fps : MonoBehaviour {

	void Awake() {
		Application.targetFrameRate = 60;
	}

}