using UnityEngine;
using System.Collections;

public class MessagingClient : MonoBehaviour {

	// Class is used to add and subscribe its methods to a MessagingManager class.

	void Start()
	{
	//	MessagingManager.Instance.AddSubscriber (MethodToAdd); 
	}

	void MethodToAdd() 
	{
		Debug.Log ("example method");
	}
}
