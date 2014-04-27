using UnityEngine;
using System.Collections;

public abstract class State {

	public GameObject entity;

	public State( GameObject entity ) {

		this.entity = entity;
	}

	public abstract void Enter();
	public abstract void Exit();
	public abstract void Update();

}