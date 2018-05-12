using UnityEngine;
using System.Collections;

public class ShootExampleManager : MonoBehaviour {



	public Transform WavePoint01;
	public Transform WavePoint02;
	public Transform WavePoint03;
	public Transform WavePoint04;
	public Transform WavePoint05;
	public Transform WavePoint06;

	public GameObject enemyOne;
	public GameObject enemyTwo;
	public GameObject enemyThree;
	public GameObject enemyFour;
	public GameObject enemyFive;
	public GameObject enemySix;
	public GameObject enemySeven;
	public GameObject enemyEight;
	public GameObject enemyNine;
	public GameObject enemyTen;


	public int enemyCounter;

	public bool wave1;
	public bool wave2;
	public bool wave3;
	public bool wave4;


	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		

		if (enemyCounter <= 0 && wave1 == false && wave2 == false) {
			wave3 = false;
			wave1 = true;
			WaveManager ();
		}
		if (enemyCounter <= 0 && wave2 == false && wave3 == false) {
			wave1 = false;
			wave2 = true;
			WaveManager ();
		}
		if (enemyCounter <= 0 && wave3 == false && wave1 == false) {
			wave2 = false;
			wave3 = true;
			WaveManager ();
		}






	}
	void WaveManager (){

		if (wave1 == true) {

			StartCoroutine ("WaveOne");
		}
		if (wave2 == true ) {

			StartCoroutine ("WaveTwo");
		}
		if (wave3 == true ) {

			StartCoroutine ("WaveThree");
		}

	}

	IEnumerator WaveOne (){

		if (enemyCounter <= 0) {



			enemyCounter = 3;


			yield return new WaitForSeconds (0.3f);

			Instantiate (enemyOne, WavePoint01.position, WavePoint01.rotation);

			yield return new WaitForSeconds (0.3f);

			Instantiate (enemyTwo, WavePoint02.position, WavePoint02.rotation);

			yield return new WaitForSeconds (0.3f);

			Instantiate (enemyThree, WavePoint03.position, WavePoint03.rotation);

		}
	}

	IEnumerator WaveTwo (){

		if (enemyCounter <= 0) {

			enemyCounter = 6;


			yield return new WaitForSeconds (0.3f);


			Instantiate (enemyFour, WavePoint04.position, WavePoint04.rotation);


			yield return new WaitForSeconds (0.5f);

			Instantiate (enemySix, WavePoint06.position, WavePoint06.rotation);

			yield return new WaitForSeconds (0.5f);

			Instantiate (enemySeven, WavePoint06.position, WavePoint06.rotation);

			yield return new WaitForSeconds (0.5f);

			Instantiate (enemyEight, WavePoint06.position, WavePoint06.rotation);

			yield return new WaitForSeconds (0.5f);

			Instantiate (enemyNine, WavePoint06.position, WavePoint06.rotation);

			yield return new WaitForSeconds (0.5f);

			Instantiate (enemyTen, WavePoint06.position, WavePoint06.rotation);
		}
	}
	IEnumerator WaveThree (){

		if (enemyCounter <= 0) {

			enemyCounter = 1;


			yield return new WaitForSeconds (0.2f);


			Instantiate (enemyFive, WavePoint05.position, WavePoint05.rotation);



		}
	}


}
	

