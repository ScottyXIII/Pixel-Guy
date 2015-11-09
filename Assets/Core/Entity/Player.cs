using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerController))]
public class Player : Entity {

	public int equpiedWeapon; // refers to wepon array index.  

	public override void Start() 
	{
		base.Start (); 
		
		Debug.Log(inventory.AddWeapon ("Bow"));

	}

	public override void Update () 
	{
		base.Update(); 
	}

	public override bool Attack ()
	{
		// Grab players weapon script and call its Attack function.
		inventory.weapons [equpiedWeapon].GetComponent<Weapon> ().Attack();
		return false;
	}

	public override void TakeDamage(int amount) 
	{
		base.TakeDamage (amount); 
		// Set a small period of invisability.
	}

	public void CastMagic()
	{
		GameObject flame = Game.loadObject ("Flame", "Flame");
		flame.transform.position = transform.position; 	
	}


}
