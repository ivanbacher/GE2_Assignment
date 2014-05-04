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
	private bool init = true;

	void Start(){

		iceman.AddComponent<SteeringManager> ();
		mig.AddComponent<SteeringManager> ();
		maverick.AddComponent<SteeringManager> ();

		gameObject.AddComponent<StateManager> ();


		this.timePassed = 0.0f;
		this.index = 0;

		this.scenes = new List<State> ();
		this.scenes.Add (new IceManChaseSceneOne (gameObject));
		this.scenes.Add (new IceManChaseSceneTwo (gameObject));


		//maverick.GetComponent<SteeringManager> ().TurnAllOff ();
		//maverick.GetComponent<SteeringManager> ().TurnOn("FlyStraight");
		//maverick.GetComponent<SteeringManager> ().TurnOn("BankHardRight");
	}

	public void nextScene() {
		index++;
		GetComponent<StateManager> ().SwitchState ( scenes[ index ]);
	}

	// Update is called once per frame
	void Update(){

		timePassed += Time.deltaTime;

		if (timePassed > 0.1f) {

			if( init == true){
				init = false;
				gameObject.GetComponent<StateManager> ().SwitchState ( scenes[ index ]);
			}
		}
	}
}
