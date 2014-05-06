using UnityEngine;
using System.Collections;

public class Missle : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Awake() {

	}

	void Start () {

		transform.root.Rotate (new Vector3 ( 90, 0, 0));
		GameObject.Destroy(gameObject, 10.0f);
	}

	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter(Collision col) {

		Debug.Log ("sdjfkdjkfjsdkfjkhjksdhfjksdf");

		Vector3 posOne = transform.position + (transform.forward * 20);
		Vector3 posTwo = transform.position + (transform.forward * 22);
		Vector3 posThree = transform.position + (transform.forward * 24);
		Vector3 posFour = transform.position + (transform.forward * 26);

		Vector3 posFive = (transform.position + (transform.forward * 20)) + new Vector3(0,5,0);
		Vector3 posSix = (transform.position + (transform.forward * 20)) + new Vector3(0,-5,0);
		Vector3 posSeven = (transform.position + (transform.forward * 20)) + new Vector3(5,0,0);
		Vector3 posEight = (transform.position + (transform.forward * 20)) + new Vector3(-5,0,0);


		GameObject a = Instantiate (explosion, posOne, Quaternion.identity) as GameObject;
		GameObject b = Instantiate (explosion, posTwo, Quaternion.identity) as GameObject;
		GameObject c = Instantiate (explosion, posThree, Quaternion.identity) as GameObject;
		GameObject d = Instantiate (explosion, posFour, Quaternion.identity) as GameObject;

		GameObject e = Instantiate (explosion, posFive, Quaternion.identity) as GameObject;
		GameObject f = Instantiate (explosion, posSix, Quaternion.identity) as GameObject;
		GameObject g = Instantiate (explosion, posSeven, Quaternion.identity) as GameObject;
		GameObject h = Instantiate (explosion, posEight, Quaternion.identity) as GameObject;


		GameObject.Destroy (a, 7.5f);
		GameObject.Destroy (b, 7.5f);
		GameObject.Destroy (c, 7.5f);
		GameObject.Destroy (d, 7.5f);
		GameObject.Destroy (e, 7.5f);
		GameObject.Destroy (f, 7.5f);
		GameObject.Destroy (g, 7.5f);
		GameObject.Destroy (h, 7.5f);

		GameObject.Destroy (gameObject);
	}
}
