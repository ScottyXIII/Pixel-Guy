using UnityEngine;
using System.Collections;

public class DamageEnemyOnHit : MonoBehaviour {

	public Enemy enemy; 
	public int dmg = 1;

	public void OnCollisionEnter2D(Collision2D collision) 
	{	 

		if (collision.collider.tag == "Enemy") {
			collision.gameObject.GetComponent<Enemy>().TakeDamage(dmg); 
			Destroy(this.gameObject);
		}

	
	}
	
	public void OnTriggerExit2D(Collider2D collision) 
	{
		
	}

}
