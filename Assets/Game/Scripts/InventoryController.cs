using UnityEngine;
using System.Collections;

public class InventoryController : MonoBehaviour {

	public Animator contorller;
	
	public void ShowWindow () {
		contorller.SetBool ("visable", true);
	}

	public void HideWindow () {
		contorller.SetBool ("visable", false);
	}
	
}
