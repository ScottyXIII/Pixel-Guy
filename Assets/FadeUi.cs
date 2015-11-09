using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class FadeUi : Singleton<FadeUi> {

	public Image screenFill;
	public float fadeIntervalTime = 0.01f; 
	public float fadeAmount = 0.5f; 
	public bool fadeOnStart = true;

	public void Start() 
	{
		screenFill.color = Color.black; 
		if (fadeOnStart) {
			StartFadeOut (); 
		}
	}

	IEnumerator FadeOut() 
	{
		while (screenFill.color.a > 0) {
			screenFill.color = new Color(screenFill.color.r, screenFill.color.g, screenFill.color.b, screenFill.color.a - fadeAmount); 
			yield return new WaitForSeconds(fadeIntervalTime);
		}

		Destroy (this.gameObject.transform.parent.gameObject);
	}

	public IEnumerator FadeIn() 
	{
		yield return null;
	}

	public void StartFadeOut() 
	{
		StartCoroutine (FadeOut()); 
	}

	public void StartFadeIn() 
	{
		StartCoroutine (FadeIn()); 
	}

}
