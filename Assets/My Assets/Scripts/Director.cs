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

		GetComponent<StateManager> ().SwitchState (new IceManChaseSceneOne ( gameObject ));

	}

	// Update is called once per frame
	void Update(){

	}
}
