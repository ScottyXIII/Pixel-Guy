using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems; 

public class InventoryUIHelper : MonoBehaviour {

	public GameObject equipmentPanel;
	public GameObject magicPanel;
	public EventSystem eventSystem; 
	public GameObject topNav, magicNav, weaponNav;
	
	public void switchToEquipment() 
	{
		magicPanel.SetActive (false);
		equipmentPanel.SetActive (true);
		eventSystem.SetSelectedGameObject (weaponNav); 
	}

	public void switchToMagic() 
	{
		equipmentPanel.SetActive (false);
		magicPanel.SetActive (true);
		eventSystem.SetSelectedGameObject (magicNav); 	
	}

	public void switchOffTopNavInput()
	{
		eventSystem.sendNavigationEvents = false; 
	}

	public void switchOnTopNavInput()
	{
		eventSystem.sendNavigationEvents = true; 
		eventSystem.SetSelectedGameObject (topNav); 
	}

}
