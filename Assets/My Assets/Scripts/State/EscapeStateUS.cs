using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EscapeStateUS : State {
		
	public EscapeStateUS( GameObject entity ):base( entity ) {
		
	}
	
	public override void Enter() {
		
		entity.GetComponent<SteeringManager> ().TurnOffAll ();

		entity.GetComponent<SteeringManager> ().FlyStraightEnabled = true;
		entity.GetComponent<SteeringManager> ().WanderEnabled = true;
	}
	
	public override void Exit() {
		
	}

	public override void Update() {

	}
}
