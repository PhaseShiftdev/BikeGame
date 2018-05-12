using UnityEngine;
using System.Collections;

public class Enemy_07 : MonoBehaviour {

	//Animation Frames

	public GameObject frame1;
	public GameObject frame2;
	public GameObject frame3;
	public GameObject frame4;
	public float animTime;
	//Fire points transforms and Prefabs
	public Transform firePoint;
	public GameObject fireball;
	public float shootTime = 1f;


	//Movement


	//The enemy Center for particle Spawn
	public GameObject enemyCenter;
	//Particle Prefabs
	public GameObject deathParticle;
	//Camera Shake when is dead
	private CamShake shake;

	//Spawn Scale

	public bool enemyActivated;
	public float maxScale = 1.0f;
	public float minScale = 0f;
	public float scaleSpeed = 5f;
	private Vector3 targetScale;

	private ShootExampleManager manager;

	void Start () {


		this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, scaleSpeed);
		targetScale.Set (minScale, minScale, minScale);

		shake = FindObjectOfType <CamShake> ();
		StartCoroutine("Spawn");
		StartCoroutine("Animated");
		StartCoroutine("Shooting");


		manager = FindObjectOfType<ShootExampleManager> ();
	}

	// Update is called once per frame
	void Update () {


		//Spawn Scale from 0 to 1
		this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, Time.deltaTime * scaleSpeed);

			targetScale.Set (maxScale, maxScale, maxScale);
	
	}
	//Spawn
	IEnumerator Spawn ()
	{

		yield return new WaitForSeconds (0.3f);

		enemyActivated = true;

		}



	//Animator
	IEnumerator Animated ()
	{
		while(true){
			//1
			yield return new WaitForSeconds (animTime);
			frame1.gameObject.SetActive (false);
			frame2.gameObject.SetActive (true);
			//2
			yield return new WaitForSeconds (animTime);
			frame2.gameObject.SetActive (false);
			frame3.gameObject.SetActive (true);
			//3
			yield return new WaitForSeconds (animTime);
			frame3.gameObject.SetActive (false);
			frame4.gameObject.SetActive (true);
			//4
			frame4.gameObject.SetActive (false);
			frame1.gameObject.SetActive (true);
		}
	}

	//Shooting
	IEnumerator Shooting ()
	{
		while(true){
			yield return new WaitForSeconds (shootTime);
			Shoot();
		}
	}
	//Fireball Spawn
	void Shoot(){
		if (enemyActivated) {
			Instantiate (fireball, firePoint.position, firePoint.rotation);
		}
	}
	//Collision
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Fireball")
		{
			manager.enemyCounter = manager.enemyCounter - 1;
			Instantiate(deathParticle, enemyCenter.transform.position, enemyCenter.transform.rotation);
			shake.shake = 1;
			Destroy(this.gameObject);


		}

	}
}