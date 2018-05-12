using UnityEngine;
using System.Collections;

public class Enemy_04 : MonoBehaviour {

	//Animation Frames

	public GameObject frame1;
	public GameObject frame2;
	public GameObject frame3;
	public GameObject frame4;
	public float animTime;

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

	public float amplitude;          
	public float speed;              
	private float tempVal;

	public float minZ = -7f;
	public float maxZ = -7f;

	private float lockPos = 20f;


	void Start () {

		tempVal = transform.position.y;


		this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, scaleSpeed);
		targetScale.Set (minScale, minScale, minScale);

		shake = FindObjectOfType <CamShake> ();
		StartCoroutine("Spawn");
		StartCoroutine("Animated");
		StartCoroutine("LifeTime");




		manager = FindObjectOfType<ShootExampleManager> ();
	}

	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.left * Time.deltaTime * speed);


		//Bounce movement
		transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

		Vector3 currentPosition = transform.position;
		currentPosition.z = Mathf.Clamp( currentPosition.z, minZ, maxZ);
		currentPosition.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
		transform.position = currentPosition;




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
	IEnumerator LifeTime ()
	{

		yield return new WaitForSeconds (5f);

		Destroy (this.gameObject);
		manager.enemyCounter = manager.enemyCounter - 1;


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