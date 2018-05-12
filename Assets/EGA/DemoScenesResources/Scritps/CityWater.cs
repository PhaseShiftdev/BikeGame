using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MeshCollider))]

public class CityWater : MonoBehaviour {

	public float waveFreq1 = 0.0f;
	public float waveXMotion1 = 0.08f;
	public float waveYMotion1 = 0.015f;
	public float waveFreq2 = 1.3f;
	public float waveXMotion2 = 0.025f;
	public float waveYMotion2 = 0.10f;
	public float waveFreq3 = 0.3f;
	public float waveXMotion3 = 0.125f;
	public float waveYMotion3 = 0.03f;
	public int waterDragFactor = 8;
	
	void Start(){
		GetComponent<Collider>().isTrigger = true;
	}
}
