using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AttackingStateUS : State {
	
	
	public AttackingStateUS( GameObject entity ):base( entity ) {
		
	}
	
	public override void Enter() {

		entity.GetComponent<SteeringManager> ().TurnOffAll ();

		entity.GetComponent<SteeringManager> ().PursuitEnabled = true;

	}
	
	public override void Exit() {
		
	}
	
	public override void Update() {
		
	}
}

