using UnityEngine;
using System.Collections;

public class Missle : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Awake() {

	}

	void Start () {
		transform.root.Rotate (new Vector3 ( 90, 0, 0));
		GameObject.Destroy(gameObject, 7.0f);
	}

	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter(Collision col) {

		Debug.Log("sdfsdfsdfsdf");


		GameObject a = Instantiate (explosion, transform.position + (transform.forward * 10), Quaternion.identity) as GameObject;

		GameObject.Destroy (a, 5.5f);

		GameObject.Destroy (gameObject);
	}
}
