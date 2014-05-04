using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IceManChaseSceneOne : State {
	
	public Director director;

	private int passed;

	public IceManChaseSceneOne( GameObject entity ):base( entity ) {

		director = entity.GetComponent<Director>();
		passed = 0;
	}

	public override void Enter() {

		director.iceman.GetComponent<SteeringManager> ().TurnAllOff ();
		director.iceman.GetComponent<SteeringManager>().TurnOn("FlyStraight");

		director.mig.GetComponent<SteeringManager> ().TurnAllOff ();
		director.mig.GetComponent<SteeringManager>().TurnOn("FlyStraight");

		director.maverick.GetComponent<SteeringManager> ().TurnAllOff ();
		director.maverick.GetComponent<SteeringManager>().TurnOn("FlyStraight");

		director.audioManager.PlayCurrent();
	}
	
	public override void Exit() {
		
	}
	
	public override void Update() {

		if (director.timePassed > 1.4f) {

			if( passed == 0) {
			
				director.mig.GetComponent<SteeringManager> ().TurnAllOff ();
				director.mig.GetComponent<SteeringManager> ().leader = director.iceman;
				director.mig.GetComponent<SteeringManager>().TurnOn("Pursue");

				director.maverick.GetComponent<SteeringManager> ().TurnAllOff ();
				director.maverick.GetComponent<SteeringManager> ().leader = director.iceman;
				director.maverick.GetComponent<SteeringManager>().TurnOn("Pursue");

				passed ++;
			}
		}

		if (director.timePassed > 5.0f) {

			if(passed == 1){

				director.iceman.GetComponent<SteeringManager>().TurnOn("AvoidLockOnRightLeft");

				passed++;
			}
		}

		//mav for shot mav
		if (director.timePassed > 7.0f) {

			if(passed == 2) {
				director.maverick.GetComponent<SteeringManager> ().TurnAllOff ();
				director.maverick.GetComponent<SteeringManager> ().leader = director.mig;
				director.maverick.GetComponent<SteeringManager>().TurnOn("Pursue");

				passed ++;
			}
		}

		//shoot m gun from mig
		if( director.timePassed > 18.0f ){

			if(passed == 3) {

				director.mig.GetComponent<MaGun>().shoot = true;

				passed++;
			}
		}

		if( director.timePassed > 20.0f ){
			
			if(passed == 4) {
				
				director.mig.GetComponent<MaGun>().shoot = false;
							
				passed++;
			}
		}

		if( director.timePassed > 24.2f ){
			
			if(passed == 5) {
				
				director.nextScene();
				
				passed++;
			}
		}
	}
}

