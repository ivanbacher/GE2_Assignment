using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FinalScene : State {
	
	public Director director;
	
	private int passed;
	
	public FinalScene( GameObject entity ):base( entity ) {
		
		director = entity.GetComponent<Director>();
		passed = 0;
	}
	
	public override void Enter() {

		Debug.Log (director.timePassed);
		director.audioManager.Next();
	}
	
	public override void Exit() {
		
	}
	
	public override void Update() {
		
		if (director.timePassed > 53.5f) {

			if(passed == 0) {

				Component[] l = director.mig.GetComponentsInChildren<Renderer>();
				
				foreach( Renderer r in l){
					r.enabled = true;
				}
				
				director.mig.GetComponent<SteeringManager>().leader = director.maverick;
				director.mig.GetComponent<SteeringManager> ().offset = new Vector3(0,20,-100);
				director.mig.GetComponent<SteeringManager>().TurnOn("OffsetPursue");
				passed++;
			}
		}

		//mig shoot
		if (director.timePassed > 66.0f) {

			if(passed == 1) {

				director.maverick.GetComponent<SteeringManager>().TurnAllOff();
				director.maverick.GetComponent<SteeringManager>().TurnOn("FlyStraight");
				director.maverick.GetComponent<SteeringManager>().TurnOn("BankHardRight");

				director.mig.GetComponent<MaGun>().shoot = true;
				passed++;
			}
		}


		if (director.timePassed > 70.0f) {

			if(passed == 2) {
				director.maverick.GetComponent<SteeringManager>().TurnOn("AvoidLockOnRightLeft");
				director.mig.GetComponent<MaGun>().shoot = false;
			
				passed++;
			}
		}

		if( director.timePassed > 76.0f ){
			if(passed == 3){
				director.maverick.GetComponent<SteeringManager>().TurnOff("AvoidLockOnRightLeft");
				director.maverick.GetComponent<SteeringManager>().maxForce = 150;
				director.maverick.GetComponent<SteeringManager>().maxSpeed = 150;
				passed++;
			}
		}

		//slow down
		if( director.timePassed > 81.0f ){
			if(passed == 4){
				director.maverick.GetComponent<SteeringManager>().maxForce = 90;
				director.maverick.GetComponent<SteeringManager>().maxSpeed = 90;
				director.mig.GetComponent<SteeringManager> ().offset = new Vector3(0,0,-40);
				passed++;
			}
		}

		//topGun
		if (director.timePassed > 97.5f) {
			
			if(passed == 5) {

				director.mig.GetComponent<SteeringManager> ().TurnAllOff();
				//director.mig.GetComponent<SteeringManager> ().maxForce = 250;
				//director.mig.GetComponent<SteeringManager> ().maxSpeed = 250;
				director.mig.GetComponent<SteeringManager>().TurnOn("FlyStraight");

				Vector3 upPos = director.maverick.transform.position + ( director.maverick.transform.forward * 500 );
				upPos.y += 300;

				director.maverick.GetComponent<SteeringManager> ().TurnAllOff();
				director.maverick.GetComponent<SteeringManager> ().seekTarget = upPos;
				director.maverick.GetComponent<SteeringManager> ().TurnOn("Seek");

				passed++;
			}
		}

		if (director.timePassed > 99.5f) {
			
			if(passed == 6) {

				director.maverick.GetComponent<SteeringManager> ().TurnAllOff();
				director.maverick.GetComponent<SteeringManager> ().leader = director.mig;
				director.maverick.GetComponent<SteeringManager> ().TurnOn("Follow");
				
				passed++;
			}
		}

		//FireMissile
		if (director.timePassed > 104.0f) {
			
			if(passed == 7) {

				director.maverick.GetComponent<SteeringManager> ().TurnAllOff();
				director.maverick.GetComponent<SteeringManager> ().offset = new Vector3(-30, 30, 0);
				director.maverick.GetComponent<SteeringManager> ().TurnOn("OffsetPursue");

				director.maverick.GetComponent<MiLauncher>().ShootMissile(director.mig);
				passed++;
			}
		}

		if (director.timePassed > 108.0f) {
			
			if(passed == 8) {
				director.maverick.GetComponent<SteeringManager>().TurnAllOff();
				director.maverick.GetComponent<SteeringManager>().TurnOn("FlyStraight");

				GameObject.Destroy(director.mig);

				passed++;
			}
		}
		
	}
}

