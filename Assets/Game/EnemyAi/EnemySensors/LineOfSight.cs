using UnityEngine;
using System.Collections;

public class LineOfSight : MonoBehaviour {

	public int playerDirection = 0;
	public int enemyDirection = 0;
	public Enemy enemy; 
	[SerializeField]
	public LineOfSightDetection up, down, left, right = null; 
	public bool PlayerInVisionRange, canSeePlayer = false;

	void Update() 
	{
		enemyDirection = enemy.Enemycontroller.direction; 
	}

	// Can only see ahead. 
	public void VisionOnlyForward() 
	{	
		VisionAll ();

		if (enemyDirection == 0) {
			down.active = false; 
			left.active = false; 
			right.active = false; 
		} else if (enemyDirection == 1) {
			up.active = false; 
			left.active = false; 
			right.active = false; 
		} else if (enemyDirection == 2) {
			up.active = false; 
			down.active = false; 
			right.active = false; 
		} else if (enemyDirection == 3) {
			up.active = false; 
			down.active = false; 
			left.active = false; 
		}
	}

	// Can see in all directions.
	public void VisionAll() 
	{
		up.active = true;
		down.active = true; 
		left.active = true; 
		right.active = true; 
	}

	// Detection if play comes in visual range
	public void OnTriggerStay2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player") {
			PlayerInVisionRange = true; 
		}

	}
	
	public void OnTriggerExit2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player") {
			PlayerInVisionRange = false; 
			enemy.changeState = true; 
		}
	}
}

