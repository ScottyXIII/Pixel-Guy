using UnityEngine;
using System.Collections;


// Need to only patrol a certain area. 


[System.Serializable]
public class EnemyStatePatroling : EnemyState {

	float partrolTime = 1f;
	float time = 0f; 
	public float maxPartrolTime = 5f;
	public float minPartrolTime = 0.1f; 

	public EnemyStatePatroling (GameObject obj) : base(obj) { 
		this.obj = obj;
	} 
 	
	void intPatrol() 
	{
		partrolTime = Random.Range (minPartrolTime, maxPartrolTime);
		obj.GetComponent<EnemyController> ().direction = Random.Range (0, 3); 
	
		time = 0f;
	}

	public override void OnEnter ()
	{
		intPatrol ();
	}

	public override void Run ()
	{
		obj.GetComponentInChildren<LineOfSight> ().VisionOnlyForward (); 
		obj.GetComponent<EnemyController> ().Move (); 

		time += Time.deltaTime;

		if (time > partrolTime) {
			intPatrol();
		}
	}

	public override void OnExit ()
	{

	}
}
