using UnityEngine;
using System.Collections;

public class EnemyFireball : MonoBehaviour {

	public float speed;
	public GameObject destroyParticle;


	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.back * Time.deltaTime * speed);
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

}
