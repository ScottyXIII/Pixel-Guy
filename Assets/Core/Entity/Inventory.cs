using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Inventory : MonoBehaviour {

	public int itemCount = 0; 
	public int maxItems = 10;

	public List<Item> items = new List<Item>();
	public List<GameObject> weapons = new List<GameObject>();
	public GameObject EqupiedObj, WeaponsObj, EqupiedWeapon; 

	public WeaponsPanelUiHelper weaponUi;

	public void EquipWeapon(int inventoryIndex) 
	{
		if (itemCount > inventoryIndex) {
			Game.Instance.player.equpiedWeapon = inventoryIndex; 
			Game.Instance.player.controller.weaponController.ResetEquipment ();

			EqupiedWeapon.transform.parent = WeaponsObj.transform;
			EqupiedWeapon.SetActive (false); 
			EqupiedWeapon = weapons [inventoryIndex];
			EqupiedWeapon.SetActive (true); 
			EqupiedWeapon.transform.parent = EqupiedObj.transform;

			// Little bug where the animator needs to be reset? 
			Game.Instance.player.controller.weaponController.gameObject.SetActive (false);
			Game.Instance.player.controller.weaponController.gameObject.SetActive (true);

		} else {
			Debug.Log("The weapon index you are trying to equip is larger than the number of intems in the inventory. Either itemCount is not being set or we are calling to large of an index. ");
		}
	}

	public string AddWeapon(string prefabPath) 
	{	
		GameObject obj = null; 

		if (itemCount < maxItems) {
				obj = WeaponFactory (prefabPath);
				weapons.Add(obj); 
				itemCount++; 
				weaponUi.RepopulatePlayersWeapons();
		} else {
			return "To many items"; 
		}

		return obj.name +" was added to inventory";
	}

	public GameObject WeaponFactory(string path)
	{
		GameObject obj = Game.loadObject ("weapon", "Weapons/"+path, GameObject.Find("Weapons"));
		obj.name = obj.GetComponent<Weapon>().item_name; 
	
		return obj; 
	}
}
