using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public Vector3 targetPos;
	public float maxSpeed;
	public Vector3 force;
	public Vector3 velocity;
	public float mass;
	public Vector3 acceleration;

	public float asd;
	// Use this for initialization
	void Start () {

		force = Vector3.zero;
		velocity = Vector3.zero;
		mass = 1.0f;
		maxSpeed = 20;
	}

	public Vector3 Calc(Vector3 targetPos) {
		Vector3 desVel = targetPos - gameObject.transform.position;
		desVel.Normalize();
		desVel *= maxSpeed;
		
		return( desVel - velocity );
	}
	
	// Update is called once per frame
	void Update () {

		force = Calc(targetPos);
		acceleration = force / mass;

		velocity += acceleration * Time.deltaTime;

		float speed = velocity.magnitude;
		if (speed > maxSpeed)
		{
			velocity.Normalize();
			velocity *= maxSpeed;
		}

		gameObject.transform.position += velocity * Time.deltaTime;

		/*
		Vector3 globalUp = new Vector3(0, 0.2f, 0);
		Vector3 accelUp = acceleration * 0.05f;
		Vector3 bankUp = accelUp + globalUp;

		Vector3 tempUp = gameObject.transform.up;

		
		if (speed > 0.0001f)
		{
			gameObject.transform.forward = velocity;
			gameObject.transform.forward.Normalize();
			gameObject.transform.LookAt(gameObject.transform.position + gameObject.transform.forward, tempUp);
			// Apply damping
			velocity *= 0.99f;
		}
		*/

	}
}
