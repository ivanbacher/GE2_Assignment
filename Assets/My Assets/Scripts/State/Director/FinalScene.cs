using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FinalScene : State {
	
	public Director director;
	
	private int passed;
	
	public FinalScene( GameObject entity ):base( entity ) {
		
		director = entity.GetComponent<Director>();
		passed = 0;
	}
	
	public override void Enter() {

		director.audioManager.Next();
	}
	
	public override void Exit() {
		
	}
	
	public override void Update() {
		
		if (director.timePassed > 1.4f) {
		
		}

	}
}

