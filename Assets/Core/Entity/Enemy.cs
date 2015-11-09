using UnityEngine;
using System.Collections;

public class Enemy : Entity {

	public EnemyState currentState = null; 
	public string stateAsString = "";
	public EnemyState lastState = null; 
	public LineOfSight sight; 
	public EnemyPlayerInRange inRange = new EnemyPlayerInRange(); 
	public bool alert, emotionBubble = false; 
	public GameObject bubbleObj = null;
	public EnemyController Enemycontroller; 
	bool alertBubble = false;
	public bool attack = false;

	public bool changeState = false;

	public override void Start() 
	{
		base.Start (); 
		Enemycontroller = GetComponent<EnemyController> (); 
	}
	// If I add anymore funtionality for this state machine inside of Enemy Class abstract it to its own class.  
	public void ChangeState(EnemyState newState) 
	{
		if (currentState != null) {
			currentState.OnExit ();
			lastState = currentState; 
		}
		currentState = newState;
		currentState.OnEnter (); 
	}

	
	public override void Update()
	{	
		stateAsString = currentState.ToString (); 

		currentState.Run ();

		if (changeState) {
			EnemyControllerLogic ();
		}

		AlertBubble (); 

	}

	
	public override void TakeDamage(int amount) 
	{
		this.hp -= amount; 
		
		Enemycontroller.animator.hurt (); 
		
		if (!isAlive ()) {
			alive = false; 
		}
		
		controller.animator.animator.SetBool ("alive", alive);
	}

	void AlertBubble() 
	{	
		if (sight.PlayerInVisionRange && alert) {
			if (bubbleObj == null && !alertBubble) {
				bubbleObj = Game.loadObject ("AlertBubble", "alertBubble");
				bubbleObj.transform.SetParent (transform, false);
				alertBubble = true; 
			}
		} else if (!sight.PlayerInVisionRange) {
			alertBubble = false;
		}
	}

	void EnemyControllerLogic() 
	{
		if (alert) {
			Enemycontroller.moveSpeed = 0.1f; 
			if (sight.PlayerInVisionRange) {
				ChangeState (new EnemyStateMoveToPlayer (this.gameObject));
			} else {
				ChangeState (new EnemyStateSeekingPlayer (this.gameObject));
			}
		} else {
			ChangeState (new EnemyStatePatroling (this.gameObject)); 
		}

		if (inRange.playerInRange && attack) {
			ChangeState(new EnemyStateAttacking(this.gameObject)); 
		}

		changeState = false;
	}
	
}
