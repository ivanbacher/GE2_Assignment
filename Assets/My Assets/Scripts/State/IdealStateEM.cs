using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IdealStateEM : State {
		
	public IdealStateEM( GameObject entity ):base( entity ) {
		
	}
	
	public override void Enter() {

		entity.GetComponent<SteeringManager> ().TurnOffAll ();

		entity.GetComponent<SteeringManager> ().FlyStraightEnabled = true;
	}
	
	public override void Exit() {
		
	}
	
	public override void Update() {

	}
}
