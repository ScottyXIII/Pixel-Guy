using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class AnimatorController : MonoBehaviour {

	public Animator animator; 

	public virtual void Start()
	{
		animator = gameObject.GetComponent<Animator>(); 
	}

	public virtual void idel()  
	{
		animator.SetTrigger("idel");
	}

	public virtual void idelUp()  
	{
		animator.SetTrigger("idelUp");
	}

	public virtual void idelDown()  
	{
		animator.SetTrigger("idelDown");
	}

	public virtual void idelLeft()  
	{
		animator.SetTrigger("idelLeft");
	}

	public virtual void idelRight()  
	{
		animator.SetTrigger("idelRight");
	}

	public virtual void walkUp()  
	{
		animator.SetTrigger("isWalkingUp");
	}

	public virtual void walkDown()  
	{
		animator.SetTrigger("isWalkingDown");
	}

	public virtual void walkLeft()  
	{
		animator.SetTrigger("isWalkingLeft");
	}

	public virtual void walkRight()  
	{
		animator.SetTrigger("isWalkingRight");	
	}

	public virtual void hurt()  
	{
		animator.SetTrigger("hurt");
	}

	public virtual void attack()  
	{
		animator.SetTrigger("attack");
	}
	
	public virtual void death()  
	{
		animator.SetTrigger("death");
	}

	public virtual void attackSecendary()  
	{
		animator.SetTrigger("attackSecendary");
	}

	public virtual void specialAttack()  
	{
		animator.SetTrigger("specialAttack");
	}

	public virtual void battleStance()  
	{
		animator.SetTrigger("battleStance");
	}
}
