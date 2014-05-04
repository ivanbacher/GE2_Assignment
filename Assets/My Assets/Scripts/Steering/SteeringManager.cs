using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SteeringManager : MonoBehaviour {

	public Vector3 force;
	public Vector3 velocity;
	public Vector3 acceleration;

	public Vector3 seekTarget;
	public Vector3 offset;
	public GameObject leader;
	public GameObject target;
	
	public List<SteeringBehaviour> behaviours;

	public float mass = 1.0f;
	public float maxSpeed = 300.0f;
	public float maxForce = 400.0f;
	
	public SteeringManager(){

		this.behaviours = new List<SteeringBehaviour> ();
	
		this.force = Vector3.zero;
		this.velocity = Vector3.zero;

		this.seekTarget = Vector3.zero;
		this.offset = new Vector3( 0,0,0);

		this.leader = null;
		this.target = null;
	}

	void Start () {

		Debug.Log ( "SteeringManager added to: " + this.name );

		this.behaviours.Add ( new SeekBehaviour (GetComponent<SteeringManager> ()) );
		this.behaviours.Add ( new FlyStraightBehaviour (GetComponent<SteeringManager> ()) );
		this.behaviours.Add ( new PursueBehaviour (GetComponent<SteeringManager> ()) );
		this.behaviours.Add ( new FleeBehaviour (GetComponent<SteeringManager> ()) );
		this.behaviours.Add ( new EvadeBehaviour (GetComponent<SteeringManager> ()) );
		this.behaviours.Add ( new AvoidLockOnRightLeftBehaviour (GetComponent<SteeringManager> ()) );
		this.behaviours.Add ( new ArriveBehaviour (GetComponent<SteeringManager> ()) );
		this.behaviours.Add ( new OffsetPursueBehaviour (GetComponent<SteeringManager> ()) );
		this.behaviours.Add ( new FollowBehaviour (GetComponent<SteeringManager> ()) );
		this.behaviours.Add ( new BankHardRightBehaviour (GetComponent<SteeringManager> ()) );
	}


	#region behaviour methods
	public void TurnOn( string whichOneToTurnOn ) {

		foreach( SteeringBehaviour b in behaviours ) {

			if( b.tag == whichOneToTurnOn ) {

				b.isEnabled = true;
			}
		}
	}

	public void TurnOff( string whichOneToTurnOff ) {

		foreach( SteeringBehaviour b in behaviours ) {
			
			if( b.tag == whichOneToTurnOff ) {
				
				b.isEnabled = false;
			}
		}
	}

	public void TurnAllOff() {
	
		foreach( SteeringBehaviour b in behaviours ) {
				
			b.isEnabled = false;
		}
	}

	public void ChangeBehaviourWeight( string whichOne, float newWeight ) {

		foreach( SteeringBehaviour b in behaviours ) {
			
			if( b.tag == whichOne ) {
				
				b.steeringWeight = newWeight;
			}
		}
	}

	#endregion
	
	// Update is called once per frame
	void Update () {

		float smoothRate;
		force = Calculate();

		Utilities.checkNaN(force);

		Vector3 newAcceleration = force / mass;

		if (Time.deltaTime > 0.0f) {
			//magic numbers?
			smoothRate = Utilities.Clip(9.0f * Time.deltaTime, 0.15f, 0.4f) / 2.0f;
			Utilities.BlendIntoAccumulator( smoothRate, newAcceleration, ref acceleration);
		}

		velocity += acceleration * Time.deltaTime;

		float speed = velocity.magnitude;
	
		if (speed > maxSpeed) {
			velocity.Normalize();
			velocity *= maxSpeed;

		}
	
		transform.position += velocity * Time.deltaTime;

		Vector3 globalUp = new Vector3 (0, 0.2f, 0);
		Vector3 accelUp = acceleration * 0.05f;
		Vector3 bankUp = accelUp + globalUp;

		smoothRate = Time.deltaTime * 3.0f;
		Vector3 tempUp = transform.up;
		Utilities.BlendIntoAccumulator (smoothRate, bankUp, ref tempUp);

		if (speed > 0.0001f) {
			transform.forward = Vector3.Normalize(velocity);
			transform.LookAt ( transform.position + transform.forward, tempUp);
			velocity *= 0.99f; //damping
		}

	}

	private bool accumulateForce( ref Vector3 runningTotal, Vector3 force ) {

		float soFar = runningTotal.magnitude;
		float remaining = maxForce - soFar;

		if (remaining <= 0) {

			return false;
		}

		float toAdd = force.magnitude;

		if (toAdd < remaining) {
			runningTotal += force;
		} else {
			runningTotal += Vector3.Normalize(force) * remaining;
		}
		return true;
	}

	public Vector3 Calculate() {

		Vector3 force = Vector3.zero;
		Vector3 steeringForce = Vector3.zero;

		foreach (SteeringBehaviour b in behaviours) {

			if(b.isEnabled == true) {

				force = b.CalculateForce () * b.steeringWeight;

				if (!accumulateForce (ref steeringForce, force)) {
						return steeringForce;
				}
			}
		}

		return steeringForce;
	}


}
