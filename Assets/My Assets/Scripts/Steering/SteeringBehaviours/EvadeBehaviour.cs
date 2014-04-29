using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EvadeBehaviour: SteeringBehaviour {
	
	private FleeBehaviour flee;
	
	public EvadeBehaviour( SteeringManager manager ):base(manager){
		
		this.tag = "Evade";
		flee = new FleeBehaviour (manager);
	}
	
	public override Vector3 CalculateForce( ) {

		Vector3 distance = manager.target.transform.position - manager.transform.position;

		float updatesAhead = distance.magnitude / manager.maxSpeed;

		Vector3 futurePos = manager.target.transform.position + (manager.target.GetComponent<SteeringManager> ().velocity * updatesAhead);

		return flee.Calc (futurePos);
	}
}

