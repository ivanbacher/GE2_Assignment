using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SeekBehaviour: SteeringBehaviour {
	

	public SeekBehaviour( SteeringManager manager ):base(manager){

		this.tag = "Seek";
	}

	public Vector3 Calc( Vector3 targetPosition ) {

		Vector3 desired = Vector3.Normalize( targetPosition - manager.transform.position) * manager.maxSpeed;
		Vector3 result = desired - manager.velocity;
		
		return result;
	}
	
	public override Vector3 CalculateForce( ){

		return Calc (manager.seekTarget);
	}
}
