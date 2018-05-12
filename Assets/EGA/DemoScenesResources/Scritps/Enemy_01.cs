using UnityEngine;
using System.Collections;

public class Enemy_01 : MonoBehaviour {

	//Animation Frames
	public GameObject frame1;
	public GameObject frame2;
	public GameObject frame3;
	public GameObject frame4;
	public float animTime;
	//Fire points transforms and Prefabs
	public Transform firePointLeft;
	public Transform firePointRight;
	public GameObject leftFire;
	public GameObject rightFire;
	public float shootTime = 1f;
	//Movement
	float timeCounter = 0;
	public float speed;
	public float widht;
	public float height;

	//The enemy Center for particle Spawn
	public GameObject enemyCenter;

	//Particle Prefabs
	public GameObject deathParticle;
	public GameObject explodeParticle;

	//Camera Shake when is dead
	private CamShake shake;

	//Spawn Scale

	public bool enemyActivated;
	public float maxScale = 1.0f;
	public float minScale = 0f;
	public float scaleSpeed = 10f;
	private Vector3 targetScale;


    private ShootExampleManager manager;


	void Start () {
		
		this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, scaleSpeed);
		targetScale.Set (minScale, minScale, minScale);

		shake = FindObjectOfType <CamShake> ();


		manager = FindObjectOfType <ShootExampleManager> ();


		StartCoroutine("Spawn");
	    StartCoroutine ("Shooting");
	    StartCoroutine ("Animated");

	}

	// Update is called once per frame
	void Update () {
		
		//Movement
        timeCounter += Time.deltaTime * speed;
		float x = Mathf.Cos (timeCounter) * widht;
		float y =10;
		float z = Mathf.Sin (timeCounter) * height +2 ;
		transform.position = new Vector3 (x, y, z);



		//Spawn Scale from 0 to 1
		this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, Time.deltaTime * scaleSpeed);

		targetScale.Set (maxScale, maxScale, maxScale);
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
	//Spawn
	IEnumerator Spawn ()
	{

		yield return new WaitForSeconds (0.3f);

		enemyActivated = true;

	}

	//Shooting
	IEnumerator Shooting ()
	{
		while(true){
			
			yield return new WaitForSeconds (shootTime);
			DoubleShoot ();

			yield return new WaitForSeconds (shootTime);
			DoubleShoot ();

		}
	}
	//Fireball Spawn
	void DoubleShoot(){

		if (enemyActivated) {
			Instantiate (leftFire, firePointLeft.position, firePointLeft.rotation);
			Instantiate (rightFire, firePointRight.position, firePointRight.rotation);
		}
	}

	//Collision
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Fireball")
		{
			manager.enemyCounter = manager.enemyCounter - 1;
			Instantiate(deathParticle, enemyCenter.transform.position, enemyCenter.transform.rotation);
			Instantiate(explodeParticle, enemyCenter.transform.position, enemyCenter.transform.rotation);
			shake.shake = 1;
			Destroy(this.gameObject);


		}

}
}