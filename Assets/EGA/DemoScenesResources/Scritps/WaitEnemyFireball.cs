using UnityEngine;
using System.Collections;

public class WaitEnemyFireball : MonoBehaviour {


	public float poseSpeed;
	public float turboSpeed;

	public GameObject destroyParticle;
	public bool firePositioning;
	public bool fireLaunch;

	void Start (){

		firePositioning = true;
	}

	void Update () {

		if (firePositioning) {
			StartCoroutine ("Positioning");
		} else {
			StopCoroutine ("Positioning");
		}
		if (fireLaunch) {
			StartCoroutine ("Launch");
		} else {
			StopCoroutine ("Launch");

		}

	}


	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
		}

		if(col.gameObject.tag == "Fireball")
		{
			Instantiate(destroyParticle, this.transform.position, this.transform.rotation);
			Destroy(this.gameObject);

		}
	}
	IEnumerator Positioning ()
	{
		
	

			transform.Translate (Vector3.back * Time.deltaTime * poseSpeed);

			yield return new WaitForSeconds (0.8f);

			firePositioning = false;
			fireLaunch = true;


			yield return null;




	}
	IEnumerator Launch (){


		
			yield return new WaitForSeconds (0.5f);

			transform.Translate (Vector3.back * Time.deltaTime * turboSpeed);

		yield return new WaitForSeconds (1.5f);


		Destroy(this.gameObject);

	}


}