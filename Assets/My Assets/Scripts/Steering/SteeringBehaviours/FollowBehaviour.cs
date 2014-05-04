using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FollowBehaviour: SteeringBehaviour {
	
	private SeekBehaviour seek;
	
	public FollowBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "Follow";
		seek = new SeekBehaviour (manager);
	}
	
	public override Vector3 CalculateForce( ){

		Vector3 target = manager.leader.transform.position;

		return seek.Calc (target);
	}
}
