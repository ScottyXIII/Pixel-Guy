using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
	
	public Inventory inventory; 

	public Texture2D image; 

	public string entity_name; 

	public bool canBeHit = true;
	// stats 
	public int level, exp; 
	public int hp, max_hp; 
	public bool alive = true; 

	public int gold = 0;

	public PlayerController controller; 

	public bool set_lerp = false;
	public float startTime; 
	public float journeyLength; 
	public Vector2 end_pos, start_pos; 

	public GameObject spawn_point, attacking_obj; 

	public GameObject we;
	public GameObject w;

	public virtual void Start() 
	{
		//controller = GetComponent<PlayerController> ();
	}

	public virtual bool moveTo(GameObject obj, Vector2 offSet, float speed)
	{
		if (!set_lerp) {
			startTime = Time.time;
			end_pos = new Vector2(obj.transform.position.x + offSet.x, obj.transform.position.y + offSet.y); 
			journeyLength = Vector3.Distance(transform.position, end_pos);
			set_lerp = true;
			start_pos = transform.position;
		} else {
			float distCovered = (Time.time - startTime);
			float fracJourney = (distCovered / journeyLength) * speed; 

			if (transform.position.x == end_pos.x) {
				set_lerp = false; 
				return true;
			}
			// Sort this shit out.... MAybe abstract this movig function into its own class/ 
			//if (transform.position == end_pos) { 
			//	return true; 
			//}

			transform.position = Vector3.Lerp(transform.position, end_pos, fracJourney);
		}
	

		return false; 
	}

	public void resetMoveTo()
	{
		set_lerp = false; 
	}

	public virtual void moveTo(Vector2 pos)
	{
		
	}

	public virtual void Update()
	{
	
	}
	
	public virtual bool Attack() 
	{
		return true; 
	}

	public virtual bool magic() 
	{
		return true; 
	}

	public virtual bool special() 
	{
		return false; 
	}

	public virtual bool item() 
	{
		return false; 
	}

	public virtual bool defend() 
	{
		return false; 
	}

	public virtual bool run() 
	{
		return false; 
	}

	public bool isAlive()
	{
		if (hp > 0) {

		} else if (hp == 0 || hp < 0) {
			hp = 0; 
			if (alive) {
				alive = false; 
			}
			alive = false; 
		}

		return alive; 
	}

	public int baseAttackDamage()
	{
		return Random.Range(0,100); 
	}

	public virtual void TakeDamage(int amount) 
	{
		this.hp -= amount; 

		controller.animator.hurt (); 

		if (!isAlive ()) {
			alive = false; 
		}

		controller.animator.animator.SetBool ("alive", alive);
	}

	public virtual void OnCollisionEnter2D(Collision2D coll) {
	
		Debug.Log (coll.gameObject.tag); 

		if (canBeHit) {
			if (coll.gameObject.tag == "weapon") {
				TakeDamage(1); 
			}

			if (coll.gameObject.tag == "Enemy") {
				Vector3 v = (Vector3)coll.contacts[0].point - transform.position;
				GetComponent<Rigidbody2D> ().AddForce (-v * 2000f); 
				TakeDamage(1); 
			}
		}
	}

	public void DestroyObject()
	{
		Destroy (this.gameObject); 
	}

}
