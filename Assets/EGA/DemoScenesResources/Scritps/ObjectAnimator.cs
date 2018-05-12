using UnityEngine;
using System.Collections;

public class ObjectAnimator : MonoBehaviour {

	//Animation Frames

	public GameObject frame01;
	public GameObject frame02;
	public GameObject frame03;
	public GameObject frame04;
	public float animTime;


	void Start () {


		StartCoroutine("Animated");
	

	}






	//Animator
	IEnumerator Animated ()
	{
		while(true){
			//1
			yield return new WaitForSeconds (animTime);
			frame01.gameObject.SetActive (false);
			frame02.gameObject.SetActive (true);
			//2
			yield return new WaitForSeconds (animTime);
			frame02.gameObject.SetActive (false);
			frame03.gameObject.SetActive (true);
			//3
			yield return new WaitForSeconds (animTime);
			frame03.gameObject.SetActive (false);
			frame04.gameObject.SetActive (true);
			//4
			frame04.gameObject.SetActive (false);
			frame01.gameObject.SetActive (true);
		}
	}



}