using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {
	
	public bool canControl = true;

	public float mass = 3000.0f;
	public float motorForce = 10000.0f;
	public int rudderSensivity = 45;
	public float angularDrag = 0.8f;
	public float cogY = -0.5f;
	public int volume = 9000;
	public Vector3 size = new Vector3(3,3,6);
	private Vector3 drag = new Vector3(6.0f,4.0f,0.2f);
	private CityWater water;

	void Start () {
		if(!GetComponent<Rigidbody>()){
			gameObject.AddComponent<Rigidbody>();
		}
		GetComponent<Rigidbody>().mass = mass;
		GetComponent<Rigidbody>().drag = 0.1f;
		GetComponent<Rigidbody>().angularDrag = angularDrag;
		GetComponent<Rigidbody>().centerOfMass = new Vector3(0, cogY, 0);
		GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
		
	
	}
	
	void  FixedUpdate (){
		if(water==null)
			return;
	
		float motor = 0.0f;
		float steer = 0.0f;
		
		if(canControl){
			motor = Input.GetAxis("Vertical");
			steer = Input.GetAxis("Horizontal");
		}
	
		float waterLevel = water.GetComponent<Collider>().bounds.max.y;
		float distanceFromWaterLevel = transform.position.y-waterLevel;
		float percentUnderWater = Mathf.Clamp01((-distanceFromWaterLevel + 0.5f*size.y)/size.y);
	
	
		
		//Buoyancy 

		Vector3 buoyancyPos = new Vector3();
		buoyancyPos = transform.TransformPoint(-new Vector3(transform.right.y*size.x*0.5f,0,transform.forward.y*size.z*0.5f));
		
		buoyancyPos.x += water.waveXMotion1 * Mathf.Sin(water.waveFreq1 * Time.time)
					+water.waveXMotion2 * Mathf.Sin(water.waveFreq2 * Time.time)
					+water.waveXMotion3 * Mathf.Sin(water.waveFreq3 * Time.time);
		buoyancyPos.z += water.waveYMotion1 * Mathf.Sin(water.waveFreq1 * Time.time)
					+water.waveYMotion2 * Mathf.Sin(water.waveFreq2 * Time.time)
					+water.waveYMotion3 * Mathf.Sin(water.waveFreq3 * Time.time);
		
		GetComponent<Rigidbody>().AddForceAtPosition(- volume * percentUnderWater * Physics.gravity, buoyancyPos);
		
	
		Vector3 propellerPos = new Vector3(0,-size.y*0.5f,-size.z*0.5f);
		Vector3 propellerPosGlobal = transform.TransformPoint(propellerPos);
		
		if(propellerPosGlobal.y<waterLevel)
		{
			float steeringAngle = steer * rudderSensivity/100 * Mathf.Deg2Rad;
			Vector3 propellerDir = transform.forward*Mathf.Cos(steeringAngle) - transform.right*Mathf.Sin(steeringAngle);
						GetComponent<Rigidbody>().AddForceAtPosition(propellerDir * motorForce * motor , propellerPosGlobal);
	
		}
		

		Vector3 dragDirection = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
		Vector3 dragForces = - Vector3.Scale(dragDirection,drag);
		
		float depth = Mathf.Abs(transform.forward.y)*size.z*0.5f+Mathf.Abs(transform.up.y)*size.y*0.5f;
		
		Vector3 dragAttackPosition = new Vector3(transform.position.x,waterLevel-depth,transform.position.z);
		GetComponent<Rigidbody>().AddForceAtPosition(transform.TransformDirection(dragForces)*GetComponent<Rigidbody>().velocity.magnitude*(1+percentUnderWater*(water.waterDragFactor-1)),dragAttackPosition);
		
		GetComponent<Rigidbody>().AddForce(transform.TransformDirection(dragForces)*500);
		
		float forwardVelo = Vector3.Dot(GetComponent<Rigidbody>().velocity,transform.forward);
		GetComponent<Rigidbody>().AddTorque(transform.up*forwardVelo*forwardVelo*rudderSensivity*steer);	
		

	}
	
	void OnTriggerStay(Collider col){
		if(col.GetComponent<CityWater>()!=null)
			water=col.GetComponent<CityWater>();
	}

}
