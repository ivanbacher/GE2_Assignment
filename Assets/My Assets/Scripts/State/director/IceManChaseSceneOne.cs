using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IceManChaseSceneOne : State {

	public GameObject maverick;
	public GameObject iceman;
	public GameObject mig;

	public IceManChaseSceneOne( GameObject entity ):base( entity ) {
		
	}
	
	public override void Enter() {


		maverick = entity.GetComponent<Director> ().maverick;
		iceman = entity.GetComponent<Director>().iceman;
		mig = entity.GetComponent<Director>().mig;

		//maverick.GetComponent<StateManager>().SwitchState ( new IdealState (maverick) );
		//iceman.GetComponent<StateManager>().SwitchState ( new IdealState (iceman) );
		//mig.GetComponent<StateManager>().SwitchState ( new IdealStateEM (mig) );

		iceman.GetComponent<SteeringManager> ().TurnAllOff ();
		iceman.GetComponent<SteeringManager> ().target = mig;
		iceman.GetComponent<SteeringManager>().TurnOn("Evade");
		iceman.GetComponent<SteeringManager>().TurnOn("FlyLeftRight");

		mig.GetComponent<SteeringManager> ().TurnAllOff ();
		mig.GetComponent<SteeringManager> ().leader = iceman;
		mig.GetComponent<SteeringManager>().TurnOn("OffsetPursue");

		maverick.GetComponent<SteeringManager> ().TurnAllOff ();
		maverick.GetComponent<SteeringManager> ().leader = mig;
		maverick.GetComponent<SteeringManager>().TurnOn("OffsetPursue");
	}
	
	public override void Exit() {
		
	}
	
	public override void Update() {
		
		
	}
}

