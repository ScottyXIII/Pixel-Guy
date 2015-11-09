using UnityEngine;
using System.Collections;

public class LineOfSightDetection : MonoBehaviour {

	public int dir = 0; 
	public bool active = true;
	public LineOfSight lineOfSight = null; 

	void Update() 
	{

	}

	public void OnTriggerEnter2D(Collider2D coll) 
	{
		lineOfSight.playerDirection = dir;
		if (active) {
			if (coll.gameObject.tag == "Player") {

			}
		} 
	}

	public void OnTriggerStay2D(Collider2D coll) 
	{
		lineOfSight.playerDirection = dir; 

		if (active) {
			if (coll.gameObject.tag == "Player") {
				lineOfSight.canSeePlayer = true; 
				lineOfSight.enemy.alert = true; 
				lineOfSight.enemy.changeState = true; 
			}
		} 
	}

	public void OnTriggerExit2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player") {
			lineOfSight.canSeePlayer = false; 
			lineOfSight.enemy.changeState = true; 
		}

	}

}
