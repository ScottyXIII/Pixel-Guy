using UnityEngine;
using System.Collections;

public class EqupiedWeaponAnimatorController : MonoBehaviour {

	public Animator anim; 
	public Renderer sprite; 

	void Start()
	{
		anim = GetComponent<Animator> (); 

	}

	void Update() 
	{
		anim.SetBool("isWalking", Game.Instance.player.controller.isWalking);
		anim.SetInteger("dir", Game.Instance.player.controller.animator.dir); 
		anim.SetInteger("weapon", Game.Instance.player.equpiedWeapon); 
	}

	public void ResetEquipment()
	{
		anim.SetTrigger ("newEquipment");
	}

	public void RenderBehindPlayer()
	{
		sprite.sortingOrder = 0;
	}

	public void RenderInfrontOfPlayer()
	{
		sprite.sortingOrder = 2;
	}
}

