using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MavOne : State {
	
	public Director director;
	
	public GameObject mav;
	public GameObject ice;
	public GameObject mig;
	
	private int passed;
	
	public MavOne( GameObject entity ):base( entity ) {
		
		director = entity.GetComponent<Director>();
		passed = 0;
	}
	
	public override void Enter() {
		
		mav = director.maverick;
		ice = director.iceman;
		mig = director.mig;
		

	}
	
	public override void Exit() {
		
	}
	
	public override void Update() {
		
		if (passed == 0) {

			if (director.timePassed >= 55.0f) {
				
				Component[] l = mig.GetComponentsInChildren<Renderer>();
				
				foreach( Renderer r in l){
					r.enabled = true;
				}

				director.cameraManager.EnableCam("maverickRear");

				passed++;
			}
		}

		if (passed == 1) {
			
			if (director.timePassed >= 58.0f) {

				mig.GetComponent<SteeringManager>().offset = new Vector3(0,0,-100);
				
				passed++;
			}
		}

		if (passed == 2) {
			
			if (director.timePassed >= 58.0f) {
				
				mig.GetComponent<SteeringManager>().offset = new Vector3(0,0,-70);
				
				passed++;
			}
		}

		if (passed == 3) {
			
			if (director.timePassed >= 65.0f) {
				
				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().TurnOn("AvoidLockOnRightLeft");
				
				passed++;
			}
		}

		if (passed == 4) {
			
			if (director.timePassed >= 67.5f) {

				mig.GetComponent<MaGun>().shoot = true;

				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
				mav.GetComponent<SteeringManager> ().TurnOn("TurnLeft");

				mig.GetComponent<SteeringManager>().offset = new Vector3(0,0,-80);
				
				passed++;
			}
		}

		if (passed == 5) {
			
			if (director.timePassed >= 71.5f) {
				
				mig.GetComponent<MaGun>().shoot = false;
				
				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().TurnOn("FlyStraight");

				mig.GetComponent<SteeringManager>().offset = new Vector3(20,0,-90);

				passed++;
			}
		}

		if (passed == 6) {
			
			if (director.timePassed >= 75.5f) {
				
				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
				mav.GetComponent<SteeringManager> ().TurnOn("TurnRight");

				mig.GetComponent<SteeringManager>().offset = new Vector3(50,0,-100);

				passed++;
			}
		}

		if (passed == 7) {
			
			if (director.timePassed >= 76.0f) {
				
				mig.GetComponent<MaGun>().shoot = false;
				mig.GetComponent<SteeringManager>().offset = new Vector3(-20,0,-90);
				
				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
				
				passed++;
			}
		}

		if (passed == 8) {
			
			if (director.timePassed >= 83.0f) {

				mig.GetComponent<SteeringManager>().offset = new Vector3(0,0,-30);
				
				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().maxForce = 120;
				mav.GetComponent<SteeringManager> ().maxSpeed = 120;
				mav.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
				
				passed++;
			}
		}

		if (passed == 9) {
			
			if (director.timePassed >= 98.0f) {

				Vector3 upPos = director.maverick.transform.position + ( director.maverick.transform.forward * 500 );
				upPos.y += 300;
				
				mig.GetComponent<SteeringManager> ().TurnAllOff();
				mig.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
				
				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().seekTarget = upPos;
				mav.GetComponent<SteeringManager> ().TurnOn("Seek");

				passed++;
			}
		}

		if (passed == 10) {
			
			if (director.timePassed >= 99.4f) {
				
				mav.GetComponent<SteeringManager> ().maxForce = 20;
				mav.GetComponent<SteeringManager> ().maxSpeed = 20;
				
				passed++;
			}
		}

		if (passed == 11) {
			
			if (director.timePassed >= 99.8f) {

				mav.GetComponent<SteeringManager> ().maxForce = 180;
				mav.GetComponent<SteeringManager> ().maxSpeed = 180;

				director.cameraManager.EnableCam("maverickFront");

				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().leader = director.mig;
				mav.GetComponent<SteeringManager> ().TurnOn("Follow");
				
				passed++;
			}
		}

		if (passed == 12) {
			
			if (director.timePassed >= 100.8f) {
				
				passed++;
			}
		}

		if (passed == 13) {
			
			if (director.timePassed >= 105.0f) {

				director.cameraManager.EnableCam("followerOne");

				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().offset = new Vector3(-30, 30, 0);
				mav.GetComponent<SteeringManager> ().TurnOn("OffsetPursue");
				
				mav.GetComponent<MiLauncher>().ShootMissile(mig);
				passed++;
			}
		}

		if (passed == 14) {
			
			if (director.timePassed >= 109.5f) {
				
				director.maverick.GetComponent<SteeringManager>().TurnAllOff();
				director.maverick.GetComponent<SteeringManager>().TurnOn("FlyStraight");
				
				GameObject.Destroy(director.mig);

				passed++;
			}
		}

	}
}

