using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Director : MonoBehaviour {

	//these gameobject are passed to the script by the GUI
	public GameObject maverick;
	public GameObject iceman;
	public GameObject mig;

	public CameraManager cameraManager;
	public AudioManager audioManager;

	public List<State> scenes;
	public int index;

	public float timePassed;

	void Start(){

		this.index = 0;

		scenes = new List<State> ();
		scenes.Add (new IceManChaseSceneOne (gameObject));
		scenes.Add (new IceManChaseSceneTwo (gameObject));

		timePassed = 0.0f;

		//GetComponent<StateManager> ().SwitchState ( scenes[ index ]);
		maverick.GetComponent<SteeringManager> ().TurnAllOff ();
		maverick.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
		//maverick.GetComponent<SteeringManager> ().TurnOn("BankHardRight");
	}

	public void nextScene() {
		index++;
		GetComponent<StateManager> ().SwitchState ( scenes[ index ]);
	}

	// Update is called once per frame
	void Update(){

		timePassed += Time.deltaTime;

	}
}
