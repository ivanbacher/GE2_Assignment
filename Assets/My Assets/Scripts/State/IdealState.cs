using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IdealState : State {

	public IdealState( GameObject entity ):base( entity ) {
	
	}

	public override void Enter() {

		entity.GetComponent<SteeringManager> ().TurnAllOff ();
		entity.GetComponent<SteeringManager>().TurnOn("FlyStraight");
	}

	public override void Exit() {
	
	}
	
	public override void Update() {

	
	}
}
