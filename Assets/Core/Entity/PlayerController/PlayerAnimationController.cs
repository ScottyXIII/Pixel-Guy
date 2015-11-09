using UnityEngine;
using System.Collections;

public class PlayerAnimationController : AnimatorController {

	public AnimatorClipInfo clip; 

	public int playerWeaponId, dir; 

	public override void  Start () {
		base.Start();
	}

	void Update () {
		animator.SetInteger ("dir", dir); 

	}

	public virtual void magic()  
	{
		animator.SetTrigger("magic");
	}


	public virtual void onLadderIdel()  
	{
		animator.SetTrigger("onLadder");
	}

	public virtual void onLadderMove()  
	{
		animator.SetTrigger("onLadderMove");
	}

	public virtual void jumping() 
	{
		animator.SetTrigger("jump");
	}
}
