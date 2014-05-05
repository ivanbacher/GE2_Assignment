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
		
		if (director.timePassed > 27.0f) {
			
			if( passed == 0) {

				director.iceman.GetComponent<SteeringManager> ().TurnAllOff ();
				director.iceman.GetComponent<SteeringManager> ().TurnOn("FlyStraight");

				director.mig.GetComponent<SteeringManager> ().TurnAllOff ();
				director.mig.GetComponent<SteeringManager>().TurnOn("Follow");

				director.maverick.GetComponent<SteeringManager> ().TurnAllOff ();
				director.maverick.GetComponent<SteeringManager>().TurnOn("Follow");

				passed ++;
			}
		}

		if (director.timePassed > 30.2f) {
			
			if( passed == 1) {

				director.iceman.GetComponent<SteeringManager> ().TurnOn("BankHardRight");

				passed ++;
			}
		}

		if (director.timePassed > 32.5f) {
			
			if( passed == 2) {
				
				director.iceman.GetComponent<SteeringManager> ().TurnAllOff ();
				director.iceman.GetComponent<SteeringManager> ().TurnOn("FlyStraight");

				director.mig.GetComponent<SteeringManager> ().TurnAllOff ();
				director.mig.GetComponent<SteeringManager> ().offset = new Vector3(0,0,350);
				director.mig.GetComponent<SteeringManager>().TurnOn("OffsetPursue");
				
				director.maverick.GetComponent<SteeringManager> ().TurnAllOff ();
				director.maverick.GetComponent<SteeringManager> ().offset = new Vector3(0,0,350);
				director.maverick.GetComponent<SteeringManager>().TurnOn("OffsetPursue");
				
				passed ++;
			}
		}

		if (director.timePassed > 35.0f) {
			
			if(passed == 3){

				GameObject blablablba = new GameObject ();
				blablablba.transform.position = director.iceman.transform.position + (director.iceman.transform.forward * 800);
				GameObject.Destroy(blablablba, 20.0f);

				director.maverick.GetComponent<MiLauncher>().ShootMissile(blablablba);
				passed ++;
			}
		}


		if (director.timePassed > 38.0f) {

			if(passed == 4){
				director.maverick.GetComponent<SteeringManager> ().offset = new Vector3(50,0,700);
				director.iceman.GetComponent<SteeringManager>().TurnOn("AvoidLockOnRightLeft");
				passed ++;
			}
		}

		if (director.timePassed > 46.0f) {
			
			if(passed == 5){
				
				director.iceman.GetComponent<SteeringManager>().TurnOff("AvoidLockOnRightLeft");
				passed ++;
			}
		}

		if (director.timePassed > 48.0f) {
			
			if(passed == 6){

				director.maverick.GetComponent<MiLauncher>().ShootMissile(director.mig );
				director.maverick.GetComponent<SteeringManager>().TurnAllOff();
				director.iceman.GetComponent<SteeringManager>().maxForce = 100;
				director.iceman.GetComponent<SteeringManager>().maxSpeed = 100;
				director.maverick.GetComponent<SteeringManager>().leader = director.iceman;
				director.maverick.GetComponent<SteeringManager> ().offset = new Vector3(100,-100,0);
				director.maverick.GetComponent<SteeringManager>().TurnOn("OffsetPursue");
				passed ++;
			}
		}

		if (director.timePassed > 51.5f) {
		
			director.mig.GetComponent<SteeringManager>().leader = director.maverick;
			director.mig.GetComponent<SteeringManager> ().offset = new Vector3(100,-100,0);

			Component[] l = director.mig.GetComponentsInChildren<Renderer>();

			foreach( Renderer r in l){
				r.enabled = false;
			}

			director.nextScene();
		}
		
	}
}


