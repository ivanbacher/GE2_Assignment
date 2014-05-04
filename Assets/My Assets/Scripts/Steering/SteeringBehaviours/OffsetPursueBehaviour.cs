using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class OffsetPursueBehaviour: SteeringBehaviour {

	private ArriveBehaviour arrive;

	public OffsetPursueBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "OffsetPursue";
		this.arrive = new ArriveBehaviour (manager);
	}
	
	public Vector3 Calc( Vector3 offset) {

		Vector3 target = manager.leader.transform.TransformPoint (offset);

		float dist = (target - manager.transform.position).magnitude;
		float lookAhead = dist / manager.maxSpeed;
		target = target + (lookAhead * manager.leader.GetComponent<SteeringManager> ().velocity);

		return arrive.Calc ( target );
	
	}
	
	public override Vector3 CalculateForce( ) {
		
		return Calc (manager.offset);
	}
}


