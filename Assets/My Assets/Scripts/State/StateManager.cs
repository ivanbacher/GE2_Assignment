using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	State currentState;

	// Use this for initialization
	void Start () {

		Debug.Log ( "StateManager added to: " + this.name );
	}
	
	// Update is called once per frame
	void Update () {

		if (currentState != null) {
			currentState.Update();
		}
	}

	public void SwitchState( State newState ) {

		if (currentState != null) {
			currentState.Exit();
		}

		currentState = newState;

		if (currentState != null) {

			currentState.Enter();
		}
	
		Debug.Log ("Switching to state for: " + newState.entity.name);
	}
}
