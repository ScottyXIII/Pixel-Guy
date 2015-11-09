using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float moveSpeed = 0.1f; 
	public bool can_move = true; 
	public bool isWalking = false; 

	public EnemyAnimatorController animator; 
	public Enemy enemy = null; 

	public int direction = 0; 

	void Start () {
		animator.animator = GetComponent<Animator> (); 
		if (enemy == null) {
			enemy = GetComponent<Enemy>(); 
		}

		direction = Random.Range (0, 3);

		enemy.ChangeState (new EnemyStatePatroling(this.gameObject));
	}

	void Update () {

		animator.animator.SetInteger ("dir", direction); 
		animator.animator.SetBool ("isWalking", isWalking); 

	}

	public void Move()
	{	
		if (can_move) {

			if (direction == 0) {
				transform.Translate (Vector2.up * getSpeed ());  
			} else if (direction == 1) {
				transform.Translate (-Vector2.up * getSpeed ()); 
			}
		
			if (direction == 2) {
				transform.Translate (-Vector2.right * getSpeed ()); 
			} else if (direction == 3) {
				transform.Translate (Vector2.right * getSpeed ()); 
			}

		}

		isWalking = true; 
	}

	protected float getSpeed() 
	{
		return moveSpeed * Time.deltaTime;
	}


}
