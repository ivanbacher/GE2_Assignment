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

	public Camera followerOneCam;
	public Camera followerTwoCam;
	public Camera followerThreeCam;

	private List<Camera> allCams;

	// Use this for initialization
	void Start () {

		allCams = new List<Camera> ();

		allCams.Add (mainCamera);
		allCams.Add (maverickFrontCamera);
		allCams.Add (maverickRearCamera);
		allCams.Add (maverickWingCamera);
		allCams.Add (followerOneCam);
		allCams.Add (followerTwoCam);
		allCams.Add (followerThreeCam);

		disableAll ();
		mainCamera.enabled = true;
	}

	private void disableAll() {

		foreach (Camera cam in allCams) {
			cam.enabled = false;
		}
	}

	public void EnableCam(string whichOne){

		disableAll ();

		if (whichOne == "main") {
			mainCamera.enabled = true;
		}
		if (whichOne == "maverickFront") {
			maverickFrontCamera.enabled = true;
		}
		if (whichOne == "maverickRear") {
			maverickRearCamera.enabled = true;
		}
		if (whichOne == "maverickWing") {
			maverickWingCamera.enabled = true;
		}
		if (whichOne == "followerOne") {
			followerOneCam.enabled = true;
		}
		if (whichOne == "followerTwo") {
			followerTwoCam.enabled = true;
		}
		if (whichOne == "followerThree") {
			followerThreeCam.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
