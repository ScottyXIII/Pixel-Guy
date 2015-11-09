using UnityEngine;
using System.Collections;

public class EnemyStateAttacking : EnemyState {

	float time;
	float waitTime; 

	public EnemyStateAttacking (GameObject obj) : base(obj) { 
		this.obj = obj;
	} 
	
	public override void OnEnter ()
	{
		waitTime = 1f; 
		time = 0f; 
	}
	
	public override void Run ()
	{
		obj.GetComponent<EnemyController> ().animator.attack ();
		obj.GetComponent<Enemy> ().attack = false; 
		obj.GetComponent<Enemy> ().changeState = true; 
	}
	
	public override void OnExit ()
	{
		
	}

 
}