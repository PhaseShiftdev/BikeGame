using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour {


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.F9)){
			Cursor.visible = false;		}
		if (Input.GetKeyDown(KeyCode.F10)){
			Cursor.visible = true;		}
		}
	}

