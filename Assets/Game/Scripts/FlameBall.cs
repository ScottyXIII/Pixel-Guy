using UnityEngine;
using System.Collections;

public class FlameBall : MonoBehaviour {

	public int direction = 0; 
	public float speed = 3f; 

	void Start () {
		direction = Game.Instance.player.controller.animator.dir;
		
		if(direction == 0)
		{
			transform.Rotate(0, 0, 90);
		}
		else if(direction == 1)
		{
			transform.Rotate(0, 0, -90);
		}
		
		if(direction == 2)
		{
			transform.Rotate(0, 180, 0);
		} 
		else if(direction == 3)
		{

		} 
	}
	
	// Update is called once per frame
	void Update () {

		if(direction == 0)
		{
			transform.Translate(Vector2.right * (speed * Time.deltaTime) );  
		}
		else if(direction == 1)
		{
			transform.Translate(Vector2.right *  (speed * Time.deltaTime)); 
		}
		
		if(direction == 2)
		{
			transform.Translate(Vector2.right *  (speed * Time.deltaTime)); 
		} 
		else if(direction == 3)
		{
			transform.Translate(Vector2.right *  (speed * Time.deltaTime)); 
		} 

	}
}
