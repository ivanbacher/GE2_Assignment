using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyLeftRightBehaviour: SteeringBehaviour {
	

	private float timePassed;
	private float timeMax;
	
	private float radius;
	private float dist;
	private bool debug;
	private bool leftOrRight;

	private Vector3 pointOnSphere;
	private Vector3 targetPos;
	private GameObject sphere;
	
	public FlyLeftRightBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "FlyLeftRight";
		this.debug = true;
		this.leftOrRight = true;

		this.timePassed = 6.0f;
		this.timeMax = 5.0f;

		this.radius = 50;
		this.dist = 50;

		this.sphere = new GameObject ();
		this.sphere.name = "FlyLeftRightSphere";
	}      

	public override Vector3 CalculateForce( ){

		timePassed += Time.deltaTime;

		if (timePassed > timeMax) {

			timePassed = 0.0f;

			if(leftOrRight) {

				pointOnSphere = new Vector3 ( Random.Range(1.0f,0.0f), Random.Range(0.1f,-0.1f), 0);
			}
			else {
				pointOnSphere = new Vector3 ( Random.Range(-1.0f,0.0f), Random.Range(0.1f,-0.1f), 0);
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
	
}

