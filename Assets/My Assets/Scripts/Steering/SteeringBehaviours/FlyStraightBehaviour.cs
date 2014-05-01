using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FlyStraightBehaviour: SteeringBehaviour {
	
	private SeekBehaviour seek;

	public FlyStraightBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "FlyStraight";
		this.steeringWeight = 1.0f;
		seek = new SeekBehaviour (manager);
	}

	public override Vector3 CalculateForce( ){
		
		Vector3 targetPos = manager.transform.position + ( manager.transform.forward * manager.maxSpeed);

		Vector3 result = seek.Calc (targetPos);
		return result;
	}
}
