using UnityEngine;
using System.Collections;

public class AirplaneFireball : MonoBehaviour {

	public float speed;

	
	// Lo siguiente hace que el player dispare para los lados y se vea 
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			Destroy(this.gameObject);

		}
		if(col.gameObject.tag == "EnemyFireball")
		{
			Destroy(this.gameObject);
		
		}
	}

	}
