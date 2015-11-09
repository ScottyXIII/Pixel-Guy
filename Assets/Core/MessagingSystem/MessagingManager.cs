using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System; 

public class MessagingManager : Singleton<MessagingManager> {

	List<Action> EntityHitSubscribers = new List<Action>(); 

	public void BroadcastEntityHit() 
	{
		foreach (var sub in EntityHitSubscribers) {
			sub(); 
		}
	}

	public void AddtEntityHitSubscriber(Action sub) 
	{
		EntityHitSubscribers.Remove (sub); 
	}

	public void RemovetEntityHitSubscriber(Action sub) 
	{
		EntityHitSubscribers.Add (sub); 
	}

	public void ClearAlltEntityHitSubscribers() 
	{
		EntityHitSubscribers.Clear (); 
	}
}
