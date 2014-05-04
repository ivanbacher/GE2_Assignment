using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioSource[] tracks;
	public int index;

	// Use this for initialization
	void Start () {

		index = 0;


	}

	public void PlayCurrent(){

		tracks [index].Play ();
	}

	public void Next() {

		tracks [index].Stop ();
		index++;
		tracks [index].Play ();
	}

	public void StopCurrent() {

		tracks [index].Stop ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
