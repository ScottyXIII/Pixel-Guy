using UnityEngine;
using System.Collections;

public class GameObjectBuilder : MonoBehaviour {

	public static GameObject NewObject(string name, Vector3 positionOffSet) 
	{
		GameObject obj = new GameObject(); 
		obj.name = name;

		obj.transform.position = new Vector3(obj.transform.position.x + positionOffSet.x, obj.transform.position.y + positionOffSet.y, obj.transform.position.z + positionOffSet.z);

		return obj; 
	}
	public static GameObject MeshObject(string name, Material mat, Vector3 positionOffSet, Transform parent) 
	{	
		GameObject Meshobj = GameObjectBuilder.NewObject (name, positionOffSet); 
		Meshobj.AddComponent<BoxCollider> ();
		BoxCollider boxCol = Meshobj.GetComponent<BoxCollider> (); 
		boxCol.center = new Vector2(0.5f, -0.5f); 

		Meshobj.AddComponent<MeshFilter>(); 
		//Meshobj.AddComponent<MeshCollider>();
		Rigidbody rb = Meshobj.AddComponent<Rigidbody> ();
		rb.useGravity = false; 
		rb.constraints = RigidbodyConstraints.FreezeAll; 

		Meshobj.AddComponent<MeshRenderer>().sharedMaterial = mat;
		Meshobj.transform.SetParent(parent); 


		return Meshobj; 
	}

	public static GameObject MeshObject(string name, Material mat, Vector3 positionOffSet, Transform parent, string tag) 
	{	
		GameObject Meshobj = GameObjectBuilder.MeshObject (name, mat, positionOffSet, parent);  

		Meshobj.tag = tag; 
	
		return Meshobj; 
	}

}
