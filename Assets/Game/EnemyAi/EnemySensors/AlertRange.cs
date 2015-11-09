using UnityEngine;
using System.Collections;

public class AlertRange : MonoBehaviour {

	public Enemy enemy; 
	
	public void OnTriggerStay2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player" && !enemy.alert) {
			enemy.alert = true; 
			enemy.changeState = true; 
		}
	}
	
	public void OnTriggerExit2D(Collider2D coll) 
	{
	
	}
}
