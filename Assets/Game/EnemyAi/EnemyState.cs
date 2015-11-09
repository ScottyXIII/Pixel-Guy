using UnityEngine;
using System.Collections;

/*
 * Abstract class for EnemyStates. 
 */

[System.Serializable]
public class EnemyState {

	public GameObject obj;

	public EnemyState (GameObject obj) {this.obj = obj;}

	public virtual void Run(){} 
	public virtual void OnEnter(){} 
	public virtual void OnExit(){}


}
