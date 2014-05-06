using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Director : MonoBehaviour {

	//these are passed to the script by the GUI
	public GameObject maverick;
	public GameObject iceman;
	public GameObject mig;

	public CameraManager cameraManager;
	public AudioManager audioManager;
	public StateManager stateManager;
	//end

	public float timePassed;

	private List<State> scenes;
	private int index;
	
	void Awake() {

		this.scenes = new List<State> ();
		this.scenes.Add (new IceOne(gameObject));
		this.scenes.Add (new MavOne (gameObject));

		this.iceman.AddComponent<SteeringManager> ();
		this.mig.AddComponent<SteeringManager> ();
		this.maverick.AddComponent<SteeringManager> ();

		this.timePassed = 0.0f;
		this.index = 0;
	}

	void Start(){

		stateManager.SwitchState ( scenes[ index ]);
		audioManager.PlayCurrent ();
	}

	public void nextScene() {
		index++;
		stateManager.SwitchState ( scenes[ index ]);
	}

	// Update is called once per frame
	void Update(){

		timePassed += Time.deltaTime;

	}
}
