using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IceOne : State {
	
	public Director director;

	public GameObject mav;
	public GameObject ice;
	public GameObject mig;

	private int passed;
	
	public IceOne( GameObject entity ):base( entity ) {
		
		director = entity.GetComponent<Director>();
		passed = 0;
	}
	
	public override void Enter() {

		mav = director.maverick;
		ice = director.iceman;
		mig = director.mig;

		ice.GetComponent<SteeringManager>().TurnOn("FlyStraight");

		mav.GetComponent<SteeringManager>().leader = ice;
		mav.GetComponent<SteeringManager> ().offset = new Vector3 (50, 30, -150);
		mav.GetComponent<SteeringManager>().TurnOn("OffsetPursue");

		mig.GetComponent<SteeringManager>().leader = ice;
		mig.GetComponent<SteeringManager> ().offset = new Vector3 (-20, 20, -90);
		mig.GetComponent<SteeringManager>().TurnOn("OffsetPursue");
	}
	
	public override void Exit() {
		
	}
	
	public override void Update() {

		if (passed == 0) {
			if (director.timePassed >= 3.0f) {

				director.cameraManager.EnableCam("followerOne");
				mav.GetComponent<SteeringManager> ().offset = new Vector3 (30, 20, -180);
				passed++;
			}
		}

		if (passed == 1) {

			if (director.timePassed >= 6.5f) {

				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().TurnOn("Follow");
				passed++;
			}
		}

		if (passed == 2) {
			
			if (director.timePassed >= 7.0f) {
				
				ice.GetComponent<SteeringManager> ().TurnAllOff();
				ice.GetComponent<SteeringManager> ().TurnOn("AvoidLockOnRightLeft");
				passed++;
			}
		}

		if (passed == 3) {
			
			if (director.timePassed >= 8.0f) {

				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager>().leader = mig;
				mav.GetComponent<SteeringManager> ().TurnOn("Follow");
				passed++;
			}
		}

		if (passed == 4) {
			
			if (director.timePassed >= 16.0f) {
				
				ice.GetComponent<SteeringManager> ().TurnAllOff();
				ice.GetComponent<SteeringManager> ().TurnOn("FlyStraight");

				mig.GetComponent<SteeringManager> ().TurnAllOff();
				mig.GetComponent<SteeringManager>().leader = ice;
				mig.GetComponent<SteeringManager> ().TurnOn("Follow");
				passed++;
			}
		}

		if (passed == 5) {
			
			if (director.timePassed >= 17.5f) {

				director.cameraManager.EnableCam("followerTwo");
				mig.GetComponent<MaGun>().shoot = true;
				passed++;
			}
		}

		if (passed == 6) {
			
			if (director.timePassed >= 20.5f) {
				
				director.cameraManager.EnableCam("followerTwo");
				mig.GetComponent<MaGun>().shoot = false;
				passed++;
			}
		}

		if (passed == 7) {
			
			if (director.timePassed >= 21.0f) {
				
				ice.GetComponent<SteeringManager> ().TurnAllOff();
				ice.GetComponent<SteeringManager> ().TurnOn("AvoidLockOnRightLeft");
				passed++;
			}
		}

		if (passed == 8) {
			
			if (director.timePassed >= 25.0f) {
				
				ice.GetComponent<SteeringManager> ().TurnAllOff();
				ice.GetComponent<SteeringManager> ().TurnOn("FlyStraight");

				director.cameraManager.EnableCam("followerOne");
				passed++;
			}
		}

		if (passed == 9) {
			
			if (director.timePassed >= 31.0f) {

				ice.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
				ice.GetComponent<SteeringManager> ().TurnOn("TurnRight");

				mig.GetComponent<SteeringManager> ().TurnAllOff();
				mig.GetComponent<SteeringManager>().leader = ice;
				mig.GetComponent<SteeringManager>().offset = new Vector3( -10,10,0);
				mig.GetComponent<SteeringManager> ().TurnOn("OffsetPursue");

				director.cameraManager.EnableCam("followerOne");
				passed++;
			}
		}

		if (passed == 10) {
			
			if (director.timePassed >= 34.0f) {
				
				ice.GetComponent<SteeringManager> ().TurnAllOff();
				ice.GetComponent<SteeringManager> ().TurnOn("FlyStraight");

				passed++;
			}
		}

		if (passed == 11) {
			
			if (director.timePassed >= 35.0f) {
				
				GameObject missileTarget = new GameObject ();
				missileTarget.transform.position = director.iceman.transform.position + (director.iceman.transform.forward * 800);
				GameObject.Destroy(missileTarget, 15.0f);
				
				director.maverick.GetComponent<MiLauncher>().ShootMissile(missileTarget);

				ice.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
				ice.GetComponent<SteeringManager> ().TurnOn("TurnLeft");

				mig.GetComponent<SteeringManager>().offset = new Vector3( 10,-10,0);

				passed++;
			}
		}

		if (passed == 12) {
			
			if (director.timePassed >= 36.0f) {

				ice.GetComponent<SteeringManager> ().TurnAllOff();
				ice.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
						
				passed++;
			}
		}

		if (passed == 13) {
			
			if (director.timePassed >= 41.0f) {
				
				ice.GetComponent<SteeringManager> ().TurnAllOff();
				ice.GetComponent<SteeringManager> ().TurnOn("AvoidLockOnRightLeft");
				
				passed++;
			}
		}

		if (passed == 14) {
			
			if (director.timePassed >= 48.0f) {
				
				ice.GetComponent<SteeringManager> ().TurnAllOff();
				ice.GetComponent<SteeringManager> ().TurnOn("FlyStraight");

				director.maverick.GetComponent<MiLauncher>().ShootMissile(mig);

				passed++;
			}
		}

		if (passed == 15) {
			
			if (director.timePassed >= 51.0f) {

				ice.GetComponent<SteeringManager> ().TurnAllOff();

				mig.GetComponent<SteeringManager> ().TurnAllOff();

				mav.GetComponent<SteeringManager> ().TurnAllOff();
				mav.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
				
				passed++;
			}
		}

		if (passed == 16) {

			if (director.timePassed >= 52.0f) {
	
					Component[] l = mig.GetComponentsInChildren<Renderer> ();
	
					foreach (Renderer r in l) {
							r.enabled = false;
					}

					mig.GetComponent<SteeringManager> ().TurnAllOff ();
					mig.GetComponent<SteeringManager> ().leader = mav;
					mig.GetComponent<SteeringManager> ().offset = new Vector3 (60, 0, -150);
					mig.GetComponent<SteeringManager> ().TurnOn ("OffsetPursue");

					passed++;
			}
		}

		if (passed == 17) {
			
			if (director.timePassed >= 52.5f) {
				passed++;
				director.nextScene();
			}
		}
	}
}

