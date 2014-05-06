using UnityEngine;
using System.Collections;

public class MaGun : MonoBehaviour {

	public bool shoot;
	public float delta;
	public float deltaMax;

	public GameObject bullet;

	// Use this for initialization
	void Start () {

		this.shoot = false;
		this.delta = 0;
		this.deltaMax = 0.05f;
	}
	
	// Update is called once per frame
	void Update () {

		delta += Time.deltaTime;

		if (shoot) {

			if(delta > deltaMax){

				GameObject shot = GameObject.Instantiate( bullet, transform.root.position + (transform.root.forward * 15), transform.root.rotation) as GameObject;

				shot.rigidbody.AddForce( GetComponent<SteeringManager>().transform.forward * 27000.0f );
				delta = 0.0f;
			}
		}
	}
}
