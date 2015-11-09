using UnityEngine;
using System.Collections;

public class EnemyStateSeekingPlayer : EnemyState {

	float time = 0f; 
	float look_time = 1f;
	bool changeState = false; 

	public EnemyStateSeekingPlayer (GameObject obj) : base(obj) { 
		this.obj = obj;
	} 
	
	public override void OnEnter ()
	{
		time = Time.fixedTime; 
		obj.GetComponent<Enemy> ().Enemycontroller.direction = 0;
	}
	
	public override void Run ()
	{
		if (Time.fixedTime < time + look_time) {

		} else {
			ChangeDirection();
			time = Time.fixedTime; 
		}
	}
	
	public override void OnExit ()
	{
		
	}

	void ChangeDirection() 
	{
		int dir = obj.GetComponent<Enemy> ().Enemycontroller.direction;

		if (dir == 0) {
			obj.GetComponent<Enemy> ().Enemycontroller.direction = 1;
		} else if (dir == 1) {
			obj.GetComponent<Enemy> ().Enemycontroller.direction = 2;
		} else if (dir == 2) {
			obj.GetComponent<Enemy> ().Enemycontroller.direction = 3;
			if (changeState) {
				obj.GetComponent<Enemy> ().alert = false; 
				obj.GetComponent<Enemy> ().changeState = true; 
				changeState = false; 
			}
		} else if (dir == 3) {
			obj.GetComponent<Enemy> ().Enemycontroller.direction = 0;
			changeState = true;
		}
	}
}
