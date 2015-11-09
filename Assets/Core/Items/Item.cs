using UnityEngine;
using System.Collections;

public enum ItemType {
	HEALING, SPEED_BUFF, ATTACK_BUFF, DEFENCE_BUFF, REGEN, REVIVE 
}

public class Item : MonoBehaviour {
	
	
	public Sprite image; 

	public string item_name; 
	public string info; 
	public int price; 


}