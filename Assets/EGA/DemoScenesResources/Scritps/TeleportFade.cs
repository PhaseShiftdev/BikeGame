﻿using UnityEngine;
using System.Collections;

public class TeleportFade : MonoBehaviour {
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	private Teleport teleport;
	void Start () {
		teleport = FindObjectOfType<Teleport> ();

	}
	
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}


	void Update ()
	{
		// If the scene is starting...
		if(teleport.teleporting == false)
			// ... call the StartScene function.
			StartScene();
		

		if (teleport.teleporting) {
			EndScene();

		}

	}


	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
	}


	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
	}


	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();

		// If the texture is almost clear...
		if(GetComponent<GUITexture>().color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			GetComponent<GUITexture>().color = Color.clear;
			GetComponent<GUITexture>().enabled = false;

			// The scene is no longer starting.
			teleport.teleported = false;
		}
	}


	public void EndScene ()
	{
		// Make sure the texture is enabled.
		GetComponent<GUITexture>().enabled = true;

		// Start fading towards black.
		FadeToBlack();

		// If the screen is almost black...
		if (GetComponent<GUITexture> ().color.a >= 0.95f)
			teleport.teleporting = false;

	
	}
}