using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BankHardRightBehaviour: SteeringBehaviour {
	
	private float timePassed;
	private float timeMax;
	private float radius;
	private float dist;
	
	private Vector3 pointOnSphere;
	
	private GameObject sphere;
	private SeekBehaviour seek;

	public BankHardRightBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "BankHardRight";
			
		this.radius = 400;
		this.dist = 600;
		
		this.pointOnSphere = Vector3.zero;

		this.sphere = new GameObject ();
		this.sphere.name = "BankHardRight";
		
		seek = new SeekBehaviour (manager);
	}
	
	
	public override Vector3 CalculateForce(){

		pointOnSphere = Vector3.zero;
		pointOnSphere.y = 1.0f;
		pointOnSphere *= radius;

		sphere.transform.position = manager.transform.position + (Vector3.forward * dist);
		sphere.transform.forward = Vector3.forward;
		
		Vector3 targetPos = sphere.transform.TransformPoint (pointOnSphere);
		
		Debug.DrawLine (manager.transform.position, targetPos, Color.yellow);
		Debug.DrawLine (manager.transform.position, sphere.transform.position, Color.yellow);
		Debug.DrawLine (sphere.transform.position, sphere.transform.position + (sphere.transform.forward * 10), Color.yellow);
		
		return seek.Calc ( targetPos );
	}
}

