using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IceManChaseSceneOne : State {
	
	public Director director;

	public IceManChaseSceneOne( GameObject entity ):base( entity ) {

		director = entity.GetComponent<Director>();
	}

	public override void Enter() {


		director.maverick = entity.GetComponent<Director> ().maverick;
		director.iceman = entity.GetComponent<Director>().iceman;
		director.mig = entity.GetComponent<Director>().mig;

		//maverick.GetComponent<StateManager>().SwitchState ( new IdealState (maverick) );
		//iceman.GetComponent<StateManager>().SwitchState ( new IdealState (iceman) );
		//mig.GetComponent<StateManager>().SwitchState ( new IdealStateEM (mig) );

		director.iceman.GetComponent<SteeringManager> ().TurnAllOff ();
		director.iceman.GetComponent<SteeringManager> ().target = director.mig;
		director.iceman.GetComponent<SteeringManager>().TurnOn("FlyStraight");
		director.iceman.GetComponent<SteeringManager>().TurnOn("AvoidLockOn");

		director.mig.GetComponent<SteeringManager> ().TurnAllOff ();
		director.mig.GetComponent<SteeringManager> ().leader = director.iceman;
		director.iceman.GetComponent<SteeringManager>().TurnOn("FlyStraight");
		director.mig.GetComponent<SteeringManager>().TurnOn("OffsetPursue");

		director.maverick.GetComponent<SteeringManager> ().TurnAllOff ();
		director.maverick.GetComponent<SteeringManager> ().leader = director.mig;
		director.iceman.GetComponent<SteeringManager>().TurnOn("FlyStraight");
		director.maverick.GetComponent<SteeringManager>().TurnOn("OffsetPursue");
	}
	
	public override void Exit() {
		
	}
	
	public override void Update() {
		
		
	}
}

