using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

public class WeaponsPanelUiHelper : MonoBehaviour {

	public List<GameObject> playersWeapons = new List<GameObject>(); 
 
	public List<Image> slotImages = new List<Image>(); 	// ref to each slot image in inventory ui.
	public List<GameObject> equipedIcon = new List<GameObject>();

	public Text infoText, infoName, infoType, price;
	public Image image; 

	public void RepopulatePlayersWeapons() 
	{
		playersWeapons = Game.Instance.player.inventory.weapons; 

		int loop = 0;
		foreach (var obj in playersWeapons) {
			// If we want to display in a certain order we can order playersWeapons list before displaying.  
			slotImages[loop].sprite = obj.GetComponent<Weapon>().image; 
			loop++;
		}
	}

	public void SetNewEquipedWepon(int index) 
	{
		SetSelectedWeaponIcon (index);

		Game.Instance.player.inventory.EquipWeapon (index);


	}

	void SetSelectedWeaponIcon(int index) 
	{
		foreach (GameObject icon in equipedIcon) {
			icon.gameObject.SetActive(false); 
		}
		equipedIcon [index].gameObject.SetActive(true);
	}

	public void PopulateInfoBox(int index)
	{
		if (index < Game.Instance.player.inventory.itemCount) {
			Weapon wep = playersWeapons [index].GetComponent<Weapon> ();

			infoText.text = wep.info;
			infoName.text = wep.item_name; 
			infoType.text = "Slasging";
			image.sprite = wep.image; 
			price.text = wep.price.ToString (); 
		}
	}
	
}
