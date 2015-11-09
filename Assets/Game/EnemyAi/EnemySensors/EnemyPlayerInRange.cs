using UnityEngine;
using System.Collections;

public class EnemyPlayerInRange : MonoBehaviour {

	public bool playerInRange = false;
	public Enemy enemy; 
	
	public void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player") {
			playerInRange = true; 
			enemy.changeState = true; 
			enemy.attack = true; 
		}
		
	}

	public void OnTriggerExit2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player") {
			playerInRange = false; 
			enemy.changeState = true; 
		}
		
	}
}
