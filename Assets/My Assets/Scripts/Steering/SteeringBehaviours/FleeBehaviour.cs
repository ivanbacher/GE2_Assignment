using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FleeBehaviour: SteeringBehaviour {

	public float panicDist;

	public FleeBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "Flee";
		this.panicDist = 500.0f;
	}

	public Vector3 Calc( Vector3 targetPos ) {

		Vector3 desVel = manager.transform.position - targetPos;

		if (desVel.magnitude > this.panicDist) {

			return Vector3.zero;
		}

		desVel.Normalize();
		desVel *= manager.maxSpeed;
		return desVel - manager.velocity;
	}
	
	public override Vector3 CalculateForce( ){

		return Calc (manager.target.transform.position);
	}
}


