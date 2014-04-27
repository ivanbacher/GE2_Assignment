using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public Camera mainCamera;
	public Camera frontCamera;
	public Camera rearCamera;
	public Camera wingCamera;


	// Use this for initialization
	void Start () {

		mainCamera.enabled = true;
		frontCamera.enabled = false;
		rearCamera.enabled = false;
		wingCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("1")) {
			mainCamera.enabled = true;
			frontCamera.enabled = false;
			rearCamera.enabled = false;
			wingCamera.enabled = false;
		}

		if (Input.GetKeyDown ("2")) {
			mainCamera.enabled = false;
			frontCamera.enabled = true;
			rearCamera.enabled = false;
			wingCamera.enabled = false;
		}

		if (Input.GetKeyDown ("3")) {
			mainCamera.enabled = false;
			frontCamera.enabled = false;
			rearCamera.enabled = true;
			wingCamera.enabled = false;
		}

		if (Input.GetKeyDown ("4")) {
			mainCamera.enabled = false;
			frontCamera.enabled = false;
			rearCamera.enabled = false;
			wingCamera.enabled = true;
		}

	}
}
