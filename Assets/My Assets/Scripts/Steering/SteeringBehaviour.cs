using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class SteeringBehaviour {
	
	public SteeringManager manager;
	public bool isEnabled;
	public float steeringWeight;
	public string tag;

	public SteeringBehaviour( SteeringManager manager ){

		this.manager = manager;
		this.isEnabled = false;
		this.steeringWeight = 1.0f;
	}

	public abstract Vector3 CalculateForce();
}
