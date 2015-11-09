using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	// Scprit will set player to its location and then delete itselfs and its parent object. 

	void Start () {
		GameObject.Find ("Player").transform.position = this.gameObject.transform.position; 
		Destroy (this.gameObject);
	}

}
