using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

	public float endTime, curTime;

	// Use this for initialization
	void Start () {
		curTime = 0f; 
	}
	
	// Update is called once per frame
	void Update () {

		if (curTime < endTime) {
			curTime += Time.deltaTime; 
		} else {
			Destroy(this.gameObject);
		}
	}
}
