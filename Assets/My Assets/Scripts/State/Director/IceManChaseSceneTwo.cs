using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IceManChaseSceneTwo : State {
	
	public Director director;
	
	private int passed;
	
	public IceManChaseSceneTwo( GameObject entity ):base( entity ) {
		
		director = entity.GetComponent<Director>();
		passed = 0;
	}
	
	public override void Enter() {
		

		director.audioManager.Next();
	}
	
	public override void Exit() {
		
	}
	
	public override void Update() {
		
		if (director.timePassed > 28.0f) {
			
			if( passed == 0) {

				director.iceman.GetComponent<SteeringManager> ().TurnAllOff ();
				director.iceman.GetComponent<SteeringManager> ().TurnOn("FlyStraight");

				passed ++;
			}
		}

		if (director.timePassed > 29.5f) {
			
			if( passed == 1) {

				director.iceman.GetComponent<SteeringManager> ().TurnAllOff ();
				director.iceman.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
				director.iceman.GetComponent<SteeringManager> ().TurnOn("BankHardRight");

				passed ++;
			}
		}

		if (director.timePassed > 32.5f) {
			
			if( passed == 1) {
				
				director.iceman.GetComponent<SteeringManager> ().TurnAllOff ();
				director.iceman.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
				
				passed ++;
			}
		}

	}
}


