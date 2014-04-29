using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PursueBehaviour: SteeringBehaviour {
	
	private SeekBehaviour seek;
	
	public PursueBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "Pursue";
		seek = new SeekBehaviour (manager);
	}
	
	public override Vector3 CalculateForce( ){
		
		Vector3 toTarget = manager.leader.transform.position - manager.transform.position;

		float dist = toTarget.magnitude;
		float time = dist / manager.maxSpeed;

		Vector3 targetPos = manager.leader.transform.position + (time * manager.leader.GetComponent<SteeringManager> ().velocity);
		return seek.Calc (targetPos);
	}
}
