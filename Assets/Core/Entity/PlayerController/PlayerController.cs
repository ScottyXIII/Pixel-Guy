using UnityEngine;
using System.Collections;

public enum Direction {
	UP, DOWN, LEFT, RIGHT, NULL
}

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 0.1f; 

	public bool can_move = true; 

	public bool update_direction = true; 
	public bool update_movement_animations = true; 

	public GameObject magicObj;

	public PlayerAnimationController animator = new PlayerAnimationController(); 
	public InventoryController inventoryController;
	public EqupiedWeaponAnimatorController weaponController; 

	public Direction direction = new Direction(); 

	public int attackHash; 
	public bool isWalking = false; 
	public bool inMenu = false;
	
	void Start() {

		animator.animator = this.gameObject.GetComponent<Animator>(); 
	
		attackHash = animator.animator.GetCurrentAnimatorStateInfo(0).shortNameHash; 

	} 
	
	void Update() 
	{
		if (update_direction) {
			setDirection(); 
		}

		Attack (); 
 

		if (can_move) {
			inventory(); 
			movePlayer(); 
			Magic();
		} 

		if (update_movement_animations) {
			updateMovementAnims();
		}

		animator.animator.SetBool ("isWalking", isWalking); 
		animator.animator.SetInteger ("equipedWeapon", Game.Instance.player.equpiedWeapon); 
	}

	public void movePlayer()
	{
		if(InputManager.Instance.upHeld())
		{
			Game.Instance.player.transform.Translate(Vector2.up * getSpeed() * Input.GetAxis("Vertical") );  
		}
		else if(InputManager.Instance.downHeld())
		{
			Game.Instance.player.transform.Translate(-Vector2.up * getSpeed() * -Input.GetAxis("Vertical")); 
		}

		if(InputManager.Instance.rightHeld())
		{
			Game.Instance.player.transform.Translate(Vector2.right * getSpeed() * Input.GetAxis("Horizontal")); 
		} 
		else if(InputManager.Instance.leftHeld())
		{
			Game.Instance.player.transform.Translate(-Vector2.right * getSpeed() * -Input.GetAxis("Horizontal")); 
		}
	}

	protected void updateMovementAnims() 
	{	
		string clip = "";
		try {
			clip = animator.animator.GetCurrentAnimatorClipInfo (0)[0].clip.name; 
		} catch {
		}

		if (InputManager.Instance.upHeld ()) {
			if (clip != "") {
				animator.walkUp ();
			}
		} 
		if (InputManager.Instance.downHeld ()) {
			if (clip != "WalkingDown") {
				animator.walkDown();
			}
		}
		if (InputManager.Instance.leftHeld ()) {
			if (clip != "WalkingLeft") {
				animator.walkLeft();
			}

		} 
		if (InputManager.Instance.rightHeld ()) {
			if (clip != "WalkingRight") {
				animator.walkRight ();
			}
		}  
	}

	protected void inventory() 
	{
		if (InputManager.Instance.inventoryKey()) { 

			if (inMenu) {
				inMenu = false;
				inventoryController.HideWindow();
			} else {
				inMenu = true;
				inventoryController.ShowWindow();
			}
 		}
	}

	protected float getSpeed() 
	{
		return moveSpeed * Time.deltaTime;
	}

	protected void setDirection() 
	{	
		isWalking = false;
		if(InputManager.Instance.upHeld())
		{
			isWalking = true;
			direction = Direction.UP;
		}
		
		if(InputManager.Instance.downHeld())
		{ 
			isWalking = true;
			direction = Direction.DOWN; 
		}
		
		if(InputManager.Instance.leftHeld())
		{ 
			isWalking = true;
			direction = Direction.LEFT; 
		}
		
		if(InputManager.Instance.rightHeld())
		{
			isWalking = true;
			direction = Direction.RIGHT; 
		} 

		animator.dir = (int)direction; 
	}

	protected void Attack() 
	{
		if (InputManager.Instance.actionKey ()) {
			animator.attack ();
			Game.Instance.player.Attack();
		}  

	}

	protected void Magic() 
	{
		if (InputManager.Instance.secondaryKey ()) {
			animator.magic();
			Game.Instance.player.CastMagic(); 
		}  
	}

	public void DeactiveMovement() { 
		can_move = false; 
	}
	public void ActiveMovement() { 
		can_move = true; 
	}

	public void OnTriggerEnter2D(Collider2D collision) 
	{
		if (collision.name == "boundary") {
			// unreliable
			//resrict_direction = direction; 
		}
	}

	public void OnTriggerExit2D(Collider2D collision) 
	{

	}
	
}

