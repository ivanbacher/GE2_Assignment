using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ArriveBehaviour: SteeringBehaviour {

	private float slowingDist;
	const float decelerationTweaker = 10.3f;

	public ArriveBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "Arrive";
		this.slowingDist = 10.0f;
	}

	public Vector3 Calc( Vector3 target) {

		Vector3 toTarget = target - manager.transform.position;

		if (toTarget.magnitude <= 0.0f) {

			return Vector3.zero;
		}

		float ramped = manager.maxSpeed * (toTarget.magnitude / (slowingDist * decelerationTweaker));
		float clamped = Math.Min (ramped, manager.maxSpeed);

		Vector3 desired = clamped * (toTarget / toTarget.magnitude);

		return desired - manager.velocity;
	}
	
	public override Vector3 CalculateForce( ) {
		
		return Calc (manager.seekTarget);
	}
}

