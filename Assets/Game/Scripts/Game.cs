using UnityEngine;
using System.Collections; 
using System;
using System.Collections.Generic;

[System.Serializable] 
public class Game : Singleton<Game> {

	public Player player; 

	void Start () {

	}

	void Update () {
	
	}

	public static GameObject loadObject(string name, string path)
	{	
		GameObject obj = null; 
		
		try {
			obj = (GameObject) Instantiate(Resources.Load(path));
			obj.name = name; 

			// If Background object is present set this as parent due to scaling n shit 
			if (GameObject.Find("Background")) {
				//obj.transform.parent = GameObject.Find("Background").transform; 
			}

		} catch {
			Debug.Log("Could not load object" + name + " with path: " + path); 
		}
	
		return obj;
	}

	public static GameObject loadObject(string name, string path, GameObject parent)
	{	
		GameObject obj = loadObject (name, path); 
		obj.transform.SetParent (parent.transform);

		return obj; 
	}
}
