using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvoidLockOnRightLeftBehaviour: SteeringBehaviour {

	private float timePassed;
	private float timeMax;
	private float radius;
	private float dist;
		
	private Vector3 pointOnSphere;

	private GameObject sphere;
	private SeekBehaviour seek;
	
	private bool left;
	
	public AvoidLockOnRightLeftBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "AvoidLockOnRightLeft";
		this.left = false;

		this.timeMax = 4.0f;

		this.radius = 200;
		this.dist = 400;

		this.pointOnSphere = Vector3.zero;
			
		this.sphere = new GameObject ();
		this.sphere.name = "AvoidLockOnSphere";

		seek = new SeekBehaviour (manager);
	}
	

	public override Vector3 CalculateForce( ){

		if ( manager.timePassedAvoid > timeMax) {

			manager.timePassedAvoid = 0.0f;

			pointOnSphere = Vector3.zero;

			if(left){
				pointOnSphere.x = Random.Range(-0.8f,-0.6f);
				left = false;
			} else {
				pointOnSphere.x = Random.Range(0.8f,0.6f);
				left = true;
			}

			pointOnSphere.Normalize();
			pointOnSphere *= radius;
		}

		sphere.transform.position = manager.transform.position + (Vector3.forward * dist);
		sphere.transform.forward = Vector3.forward;

		Vector3 targetPos = sphere.transform.TransformPoint (pointOnSphere);

		Debug.DrawLine (manager.transform.position, targetPos, Color.red);
		Debug.DrawLine (manager.transform.position, sphere.transform.position, Color.green);
		Debug.DrawLine (sphere.transform.position, sphere.transform.position + (sphere.transform.forward * 10), Color.blue);

		return seek.Calc ( targetPos );
	}
}

/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvoidLockOnRightLeftBehaviour: SteeringBehaviour {

	private float timePassed;
	private float timeMax;
	private float radius;
	private float dist;
		
	private Vector3 pointOnSphere;

	private GameObject sphere;
	private SeekBehaviour seek;
	
	private bool left;
	
	public AvoidLockOnRightLeftBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "AvoidLockOnRightLeft";
		this.left = false;
		
		this.timePassed = 20.0f;
		this.timeMax = 3.0f;

		this.radius = 200;
		this.dist = 400;

		this.pointOnSphere = Vector3.zero;
			
		this.sphere = new GameObject ();
		this.sphere.name = "AvoidLockOnSphere";

		seek = new SeekBehaviour (manager);
	}
	

	public override Vector3 CalculateForce( ){
		
		timePassed += Time.deltaTime;

		if (timePassed > timeMax) {

			timePassed = 0.0f;

			pointOnSphere = Vector3.zero;

			if(left){

				pointOnSphere.x = Random.Range (-0.8f,0.0f);
				left = false;
			} else {
				pointOnSphere.x = Random.Range (0.8f,0.0f);
				left = true;
			}

			pointOnSphere.Normalize();
			pointOnSphere *= radius;
		}

		if (left) {

			float turnAmount

		}

		sphere.transform.position = manager.transform.position + (Vector3.forward * dist);
		sphere.transform.forward = Vector3.forward;

		Vector3 targetPos = sphere.transform.TransformPoint (pointOnSphere);

		Debug.DrawLine (manager.transform.position, targetPos, Color.red);
		Debug.DrawLine (manager.transform.position, sphere.transform.position, Color.green);
		Debug.DrawLine (sphere.transform.position, sphere.transform.position + (sphere.transform.forward * 10), Color.blue);

		return seek.Calc ( targetPos );
	}
}


 */

