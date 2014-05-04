using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class CameraManager : MonoBehaviour {

	public Camera mainCamera;

	//maverick Cameras
	public Camera maverickFrontCamera;
	public Camera maverickRearCamera;
	public Camera maverickWingCamera;

	private List<Camera> allCams;

	// Use this for initialization
	void Start () {

		allCams = new List<Camera> ();

		allCams.Add (mainCamera);
		allCams.Add (maverickFrontCamera);
		allCams.Add (maverickRearCamera);
		allCams.Add (maverickWingCamera);

		disableAll ();
		maverickFrontCamera.enabled = true;
	}

	private void disableAll() {

		foreach (Camera cam in allCams) {
			cam.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("1")) {

			disableAll();
			mainCamera.enabled = true;
		}

		if (Input.GetKeyDown ("2")) {

			disableAll();
			maverickFrontCamera.enabled = true;
		}

		if (Input.GetKeyDown ("3")) {

			disableAll();
			maverickRearCamera.enabled = true;
		}

		if (Input.GetKeyDown ("4")) {

			disableAll();
			maverickWingCamera.enabled = true;
		}

	}
}
