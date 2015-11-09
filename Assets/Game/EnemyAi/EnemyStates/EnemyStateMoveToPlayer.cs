using UnityEngine;
using System.Collections;

public class EnemyStateMoveToPlayer : EnemyState {

	public EnemyStateMoveToPlayer (GameObject obj) : base(obj) { 
		this.obj = obj;
	} 

	public override void OnEnter ()
	{
		obj.GetComponentInChildren<LineOfSight> ().VisionAll ();
		obj.GetComponent<EnemyController> ().direction = Random.Range (0, 3); 
	}
	
	public override void Run ()
	{	
		obj.GetComponentInChildren<LineOfSight> ().VisionAll (); 
		obj.GetComponent<EnemyController> ().direction = obj.GetComponentInChildren<LineOfSight> ().playerDirection; 
		obj.GetComponent<EnemyController> ().Move (); 
	}
	
	public override void OnExit ()
	{
		
	}
}
