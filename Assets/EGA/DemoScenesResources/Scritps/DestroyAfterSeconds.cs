using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour
{
	public float lifetime;
	
	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}