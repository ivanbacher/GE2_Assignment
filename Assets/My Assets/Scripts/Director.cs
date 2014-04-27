using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Director : MonoBehaviour {

	//these gameobject are passed to the script by the GUI
	public GameObject maverick;
	public GameObject iceman;
	public GameObject mig;
		           
	void Start(){
	
		maverick.GetComponent<StateManager>().SwitchState ( new IdealStateUS (maverick) );
		iceman.GetComponent<StateManager>().SwitchState ( new IdealStateUS (iceman) );
		mig.GetComponent<StateManager>().SwitchState ( new IdealStateEM (mig) );

		/*
		iceman.GetComponent<SteeringManager> ().FlyStraightEnabled = true;
		mig.GetComponent<SteeringManager> ().OffsetPursuitEnabled = true;
		maverick.GetComponent<SteeringManager> ().OffsetPursuitEnabled = true;
		mig.GetComponent<SteeringManager> ().leader = iceman;
		maverick.GetComponent<SteeringManager>().leader = mig;

		//iceman.GetComponent<SteeringManager> ().SeekEnabled = true;
		//mig.GetComponent<SteeringManager> ().SeekEnabled = true;
		//maverick.GetComponent<SteeringManager> ().SeekEnabled = true;

		//iceman.GetComponent<SteeringManager> ().seekTargetPos = new Vector3 (-2000, 17210, 2000);
		//mig.GetComponent<SteeringManager> ().seekTargetPos = new Vector3 (-2000, 17210, 2000);
		//maverick.GetComponent<SteeringManager> ().seekTargetPos = new Vector3 (-2000, 17210, 2000);
		*/
	}

	// Update is called once per frame
	void Update(){

	}
}
