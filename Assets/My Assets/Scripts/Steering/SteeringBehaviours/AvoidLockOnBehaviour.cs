using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class AvoidLockOnBehaviour: SteeringBehaviour {
	

	private float timePassed;
	private float timeMax;
	
	private float range;
	private float radius;
	private float dist;
	private float FOV;
	private bool debug;
	private bool firstTime;

	private Vector3 pointOnSphere;
	private Vector3 targetPos;
	private GameObject sphere;

	private float maxUp;
	
	public AvoidLockOnBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "AvoidLockOn";
		this.firstTime = true;

		this.timePassed = 0.0f;
		this.timeMax = 10.0f;

		this.radius = 100;
		this.dist = 200;
		this.range = 300;
		this.FOV = 60.0f;
		this.pointOnSphere = new Vector3 (0, 0, 0);
		this.targetPos = manager.transform.position + (Vector3.forward * manager.maxSpeed);

		this.maxUp = 0.0f;

		this.sphere = new GameObject ();
		this.sphere.name = "AvoidLockOnSphere";
	}

	private void DebugFOV() {
		Vector3 newDir1 = Quaternion.Euler(0, (FOV/2), 0) * -manager.transform.forward;
		Vector3 newDir2 = Quaternion.Euler(0, -(FOV/2), 0) * -manager.transform.forward;
		Vector3 newDir3 = Quaternion.Euler((FOV/2), 0, 0 ) * -manager.transform.forward;
		Vector3 newDir4 = Quaternion.Euler(-(FOV/2), 0, 0 ) * -manager.transform.forward;
		
		Vector3 One = manager.transform.position + (newDir1 * range);
		Vector3 Two = manager.transform.position + (newDir2 * range);
		Vector3 Three = manager.transform.position + (newDir3 * range);
		Vector3 Four = manager.transform.position + (newDir4 * range);
		
		Debug.DrawLine (manager.transform.position, One, Color.green);
		Debug.DrawLine (manager.transform.position, Two, Color.green);
		Debug.DrawLine (manager.transform.position, Three, Color.green);
		Debug.DrawLine (manager.transform.position, Four, Color.green);
	}

	private void DebugSphereInFront() {

		Debug.DrawLine (manager.transform.position, sphere.transform.position, Color.yellow);
		Debug.DrawLine (sphere.transform.position, targetPos, Color.red);
		Debug.DrawLine (manager.transform.position, targetPos, Color.blue);
	}



	public override Vector3 CalculateForce( ){

		timePassed += Time.deltaTime;

		//1 check if in range
		Vector3 toEn = manager.target.transform.position - manager.transform.position;

		if (toEn.magnitude < range) {

			//2 check if behind
			toEn = toEn.normalized;
			float dot = Vector3.Dot (toEn, -manager.transform.forward);

			//we are using - forward so if dot > 0 enemy is behind
			if( dot > 0) {

				//3 calc FOV
				float angle = Mathf.Acos (dot);
				float halfOf = (Mathf.Deg2Rad * FOV) / 2.0f;

				//if enemy is behind and in FOV then we should panic and try to avoid getting locked on.
				if (angle < halfOf) {



					if( firstTime == true ){
						firstTime = false;

						pointOnSphere = new Vector3 ( Random.Range(0.8f,-0.8f), Random.Range(0.2f,-0.2f), 0);
					
						pointOnSphere.Normalize();
						pointOnSphere *= radius;

						maxUp += pointOnSphere.y;
					}

					if( timePassed > timeMax) {

						firstTime = false;
						timePassed = 0.0f;

						pointOnSphere = new Vector3 ( Random.Range(0.8f,-0.8f), Random.Range(0.2f,-0.2f), 0 );

						pointOnSphere.Normalize();
						pointOnSphere *= radius;
						maxUp += pointOnSphere.y;
					}

					if(maxUp > 300){

						pointOnSphere.y = -0.2f * radius;
						maxUp+= pointOnSphere.y;
					} else if(maxUp < -300) {

						pointOnSphere.y = 0.2f * radius;
						maxUp+= pointOnSphere.y;
					}

					sphere.transform.position = manager.transform.position + (manager.transform.forward * dist);
					sphere.transform.forward = manager.transform.forward;

					targetPos = sphere.transform.TransformPoint (pointOnSphere);

					DebugSphereInFront();
					DebugFOV();


					Vector3 desired = Vector3.Normalize( targetPos - manager.transform.position) * manager.maxSpeed;
					desired -= manager.velocity;

					return desired;
				}
				firstTime = true;
			}
		}


		if (timePassed > timeMax) {

			timePassed = 0.0f;
			targetPos = manager.transform.position + (Vector3.forward * manager.maxSpeed);
		}

		Vector3 d = Vector3.Normalize( targetPos - manager.transform.position) * manager.maxSpeed;
		d -= manager.velocity;
		return d;
	}

	/*

public override Vector3 CalculateForce( ){

		timePassed += Time.deltaTime;

		if (timePassed > timeMax) {

			timePassed = 0.0f;

			if(leftOrRight) {

				pointOnSphere = new Vector3 ( Random.Range(1.0f,0.0f), 1, 0);
			}
			else {
				pointOnSphere = new Vector3 ( Random.Range(-1.0f,0.0f), 0, 0);
			}

			leftOrRight = !leftOrRight;
			timePassed = Random.Range(2.0f,5.0f);
			radius = Random.Range(20.0f,60.0f);
			dist = Random.Range(10.0f,50.0f);
			pointOnSphere.Normalize();
			pointOnSphere *= radius;
		}

		sphere.transform.position = manager.transform.position + (manager.transform.forward * dist);
		sphere.transform.forward = manager.transform.forward;

		targetPos = sphere.transform.TransformPoint (pointOnSphere);

		if (debug == true) {

			Debug.DrawLine (manager.transform.position, sphere.transform.position, Color.yellow);
			Debug.DrawLine (sphere.transform.position, targetPos, Color.red);
			Debug.DrawLine (manager.transform.position, targetPos, Color.blue);
			Debug.DrawLine (sphere.transform.position, sphere.transform.position + (sphere.transform.forward * 10), Color.green);
		}

		return targetPos - manager.transform.position;
	}
	 */
	
}

