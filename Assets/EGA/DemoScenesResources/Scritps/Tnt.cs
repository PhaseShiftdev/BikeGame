using UnityEngine;
using System.Collections;

public class Tnt : MonoBehaviour {

	private CamShake shake;
	public GameObject explodeParticle;
	public GameObject objectCenter;


	void Start () {
		shake = FindObjectOfType <CamShake> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Fireball" || col.gameObject.tag == "Player" )
		{
			Instantiate(explodeParticle, objectCenter.transform.position, objectCenter.transform.rotation);
			shake.shake = 1;
			Destroy(this.gameObject);


		}

	}
}
