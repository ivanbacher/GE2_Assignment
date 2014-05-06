using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		transform.root.Rotate (new Vector3 ( 90, 0, 0));
		Destroy(gameObject,3.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnCollisionEnter(Collision col) {

		GameObject.Destroy (gameObject);
	}
}
