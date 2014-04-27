using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IdealStateUS : State {
	
	private float range = 150.0f;

	public IdealStateUS( GameObject entity ):base( entity ) {
	
	}

	public override void Enter() {

		entity.GetComponent<SteeringManager> ().TurnOffAll ();
		entity.GetComponent<SteeringManager> ().WanderEnabled = true;
		entity.GetComponent<SteeringManager> ().FlyStraightEnabled = true;

	}

	public override void Exit() {
	
	}

	private bool isInRange( GameObject enemy ) {

		Vector3 toEn = enemy.transform.position - entity.transform.position;
	
		if ( toEn.magnitude <= range ) {

			Debug.Log ( entity.name + ": " + enemy.name + " is in range ");
			return true;
		}

		return false;
	}

	private bool isInFront( GameObject enemy ) {

		Vector3 toEn = enemy.transform.position - entity.transform.position;

		float dot = Vector3.Dot( toEn, entity.transform.forward );
		
		if( dot < 0 ) {
			//behind
			//Debug.Log ( enemy.name + " is behind " + entity.name );
			return false;
		} else {
			//infront
			//Debug.Log ( enemy.name + " is infront of " + entity.name );
			return true;
		}

	}


	public override void Update() {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("enemy");

		for (int i = 0; i < enemies.Length; i++) {

			if( isInRange(enemies[i])) {


				if( isInFront(enemies[i]) ) {
					//if enemy is in front of entity

					//entity.GetComponent<SteeringManager>().leader = enemies[i];
					//entity.GetComponent<StateManager>().SwitchState( new AttackingStateUS( entity ));
				}
				else if( !isInFront(enemies[i]) ) {

					// //if enemy is behind of entity
					//entity.GetComponent<SteeringManager>().target = enemies[i];
					//entity.GetComponent<StateManager>().SwitchState( new EscapeStateUS( entity ));
				}
			}
			
		}

	}
}
