using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SteeringManager : MonoBehaviour {

	public Vector3 force;
	public Vector3 velocity;
	public Vector3 acceleration;

	public float mass;
	public float maxSpeed;
	public float maxForce;
	public float timeDelta;
	public float wanderRad;
	public float wanderJitter;
	public float wanderDist;

	public GameObject target; // required for evade
	public GameObject leader; // required for offset pursuit
	private Vector3 wanderTargetPos;
	public Vector3 seekTargetPos;
	public Vector3 offset;
	private Vector3 randomWalkTarget;

	public float wanderWeight;
	
	#region Flags
	public bool SeekEnabled;
	public bool FleeEnabled;
	public bool ArriveEnabled;
	public bool WanderEnabled;
	public bool PursuitEnabled;
	public bool EvadeEnabled;
	public bool OffsetPursuitEnabled;
	public bool FlyStraightEnabled;
	#endregion
	
	// Use this for initialization
	public SteeringManager(){
		TurnOffAll();
		Debug.Log ( "SteeringManager added to: " + this.name );

		target = null;
		leader = null;

		force = Vector3.zero;
		velocity = Vector3.zero;

		mass = 1.0f;
		maxSpeed = 100;
		maxForce = 50;

		wanderRad = 3;
		wanderJitter = 20;
		wanderDist = 15;

		wanderWeight = 0.01f;
	}

	void Start () {

		wanderTargetPos = UnityEngine.Random.insideUnitSphere * wanderRad;
	}
	
	// Update is called once per frame
	void Update () {

		float smoothRate;
		force = Calculate();

		Utilities.checkNaN(force);

		Vector3 newAcceleration = force / mass;
		timeDelta = Time.deltaTime * 1.0f;

		if (timeDelta > 0.0f) {
			//magic numbers?
			smoothRate = Utilities.Clip(9.0f * timeDelta, 0.15f, 0.4f) / 2.0f;
			Utilities.BlendIntoAccumulator( smoothRate, newAcceleration, ref acceleration);
		}

		velocity += acceleration * timeDelta;

		float speed = velocity.magnitude;

		if (speed > maxSpeed) {
			velocity.Normalize();
			velocity *= maxSpeed;
		}

		transform.position += velocity * timeDelta;

		//-----------
		Vector3 globalUp = new Vector3 (0, 0.2f, 0);
		Vector3 accelUp = acceleration * 0.05f;
		Vector3 bankUp = accelUp + globalUp;

		smoothRate = timeDelta * 3.0f;
		Vector3 tempUp = transform.up;
		Utilities.BlendIntoAccumulator (smoothRate, bankUp, ref tempUp);

		if (speed > 0.0001f) {

			transform.forward = velocity;
			transform.forward.Normalize();
			transform.LookAt ( transform.position + transform.forward, tempUp);
			velocity *= 0.99f; //damping
		}

	}

	public void TurnOffAll() {

		SeekEnabled= false;
		FleeEnabled= false;
		ArriveEnabled= false;
		WanderEnabled= false;
		PursuitEnabled= false;
		EvadeEnabled= false;
		OffsetPursuitEnabled= false;
		FlyStraightEnabled = false;
	}

	#region util functions
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

		if (SeekEnabled) {

			force = Seek( seekTargetPos ) * 1.0f;

			if(!accumulateForce( ref steeringForce, force )) {
				return steeringForce;
			}
		}

		if(FleeEnabled){

			force = Flee(target.transform.position) * 1.0f;

			if (!accumulateForce(ref steeringForce, force)){
				return steeringForce;
			}
		}

		if(ArriveEnabled){

			force = Arrive(seekTargetPos) * 1.0f;

			if (!accumulateForce(ref steeringForce, force)){
				return steeringForce;
			}
		}

		if(WanderEnabled){

			force = Wander() * wanderWeight;;

			if (!accumulateForce(ref steeringForce, force)){
				return steeringForce;
			}
		}

		if(PursuitEnabled){

			force = Pursue() * 1.0f;

			if (!accumulateForce(ref steeringForce, force)){
				return steeringForce;
			}
		}

		if(EvadeEnabled){

			force = Evade() * 1.0f;

			if (!accumulateForce(ref steeringForce, force)){
				return steeringForce;
			}
		}

		if(OffsetPursuitEnabled){
			force = OffsetPursuit(offset) * 1.0f;
			if (!accumulateForce(ref steeringForce, force)){
				return steeringForce;
			}
		}

		if (FlyStraightEnabled) {

			force = FlyStraight() * 1.0f;

			if (!accumulateForce(ref steeringForce, force)){
				return steeringForce;
			}
		}

		return steeringForce;
	}
	#endregion


















	#region Behaviours
	
	Vector3 FlyStraight () {

		Vector3 targetPos = transform.position + (transform.forward * maxSpeed);

		return Seek (targetPos);
	}

	Vector3 Seek( Vector3 targetPos ) {

		Vector3 desiredVelocity;
		
		desiredVelocity = targetPos - transform.position;
		desiredVelocity.Normalize();
		desiredVelocity *= maxSpeed;

		return (desiredVelocity - velocity);
	}

	Vector3 Evade() {

		float dist = (target.transform.position - transform.position).magnitude;
		float lookAhead = maxSpeed;
		
		Vector3 targetPos = target.transform.position + (lookAhead * target.GetComponent<SteeringManager>().velocity);
		return Flee(targetPos);
	}

	Vector3 Flee( Vector3 targetPos ) {

		float panicDistance = 500.0f;
		Vector3 desiredVelocity;
		desiredVelocity = transform.position - targetPos;
		if (desiredVelocity.magnitude > panicDistance)
		{
			//return Vector3.zero;
		}
		desiredVelocity.Normalize();
		desiredVelocity *= maxSpeed;
		return (desiredVelocity - velocity);
	}

	Vector3 Wander() {

		float jitterTimeSlice = wanderJitter * timeDelta;
		
		Vector3 toAdd = UnityEngine.Random.insideUnitSphere * jitterTimeSlice;
		wanderTargetPos += toAdd;
		wanderTargetPos.Normalize();
		wanderTargetPos *= wanderRad;
		
		Vector3 localTarget = wanderTargetPos + Vector3.forward * wanderDist;
		Vector3 worldTarget = transform.TransformPoint(localTarget);

		return (worldTarget - transform.position);
	}

	Vector3 Arrive(Vector3 target) {

		Vector3 toTarget = target - transform.position;
		
		float slowingDistance = 8.0f;
		float distance = toTarget.magnitude;
		if (distance == 0.0f)
		{
			return Vector3.zero;
		}
		const float DecelerationTweaker = 10.3f;
		float ramped = maxSpeed * (distance / (slowingDistance * DecelerationTweaker));
		
		float clamped = Math.Min(ramped, maxSpeed);
		Vector3 desired = clamped * (toTarget / distance);

		Utilities.checkNaN(desired);

		return desired - velocity;
	}

	Vector3 Pursue() {

		Vector3 toTarget = leader.transform.position - transform.position;
		float dist = toTarget.magnitude;
		float time = dist / maxSpeed;
		
		Vector3 targetPos = leader.transform.position + (time * leader.GetComponent<SteeringManager>().velocity);
				
		return Seek(targetPos);
	}

	Vector3 OffsetPursuit(Vector3 offset)
	{

		Vector3 target = Vector3.zero;
		target = leader.transform.TransformPoint(offset);
		
		float dist = (target - transform.position).magnitude;
		
		float lookAhead = (dist / maxSpeed);
		
		target = target + (lookAhead * leader.GetComponent<SteeringManager>().velocity);
		
		Utilities.checkNaN(target);
		return Arrive(target);
	}
	#endregion
}
