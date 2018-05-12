using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour {

	public float moveSpeed = 20f;


	public Transform weaponFirePoint;
	public GameObject weaponFireBall;
	public float fireRate = 0;
	public float timeToFire = 0;
	public Transform firePointLeft;
	public Transform firePointRight;
	public GameObject leftFire;
	public GameObject rightFire;

	public float minY = 12f;
	public float maxY = 12.0f;

	public GameObject deathParticle;
	public GameObject playerCenter;
	private CamShake shake;

	public float maxScale = 1.0f;
	public float minScale = 0f;
	public float scaleSpeed = 10f;
	private Vector3 targetScale;



	void Start () {
		shake = FindObjectOfType <CamShake> ();

		this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, scaleSpeed);
		targetScale.Set (minScale, minScale, minScale);
	}
	
	// Update is called once per frame
	void Update () {

		//Spawn Scale from 0 to 1
		this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, Time.deltaTime * scaleSpeed);

		targetScale.Set (maxScale, maxScale, maxScale);
		
		//Airplane Bounds
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);
		transform.position = Camera.main.ViewportToWorldPoint(pos);

		//Force Y pos to 10


		Vector3 currentPosition = transform.position;
		currentPosition.y = Mathf.Clamp( currentPosition.y, minY, maxY);
        transform.position = currentPosition;
	



		//Movement

		transform.Translate (Vector3.right * Time.fixedDeltaTime * moveSpeed * Input.GetAxis ("Horizontal"));

		transform.Translate (Vector3.forward * Time.fixedDeltaTime * moveSpeed * Input.GetAxis ("Vertical"));




		//Shooting

		if (Input.GetButton("Fire1") && Time.time > timeToFire) {
	       Shoot ();
		timeToFire = Time.time + 1 / fireRate;

		}
		if (Input.GetButtonDown("Fire2") && Time.time > timeToFire) {
			DoubleShoot ();
			timeToFire = Time.time + 1 / fireRate;
			
		}
	}
	void Shoot(){
		
		Instantiate (weaponFireBall,weaponFirePoint.position,weaponFirePoint.rotation);
		
	}
	void DoubleShoot(){
		
		Instantiate (leftFire,firePointLeft.position,firePointLeft.rotation);
		Instantiate (rightFire,firePointRight.position,firePointRight.rotation);
	}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "EnemyFireball"  || col.gameObject.tag == "Enemy")
		{
			
			Instantiate(deathParticle, playerCenter.transform.position, playerCenter.transform.rotation);
			Destroy (this.gameObject);
			shake.shake = 1;
		}

	}
		}
	


