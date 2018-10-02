using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFade : MonoBehaviour {


	public float fadeSpeed;

	void Start () {
		
	}
	
	void Update () {
		AddAlpha();
	}
	public void AddAlpha()
	{
		//GetComponent<CanvasGroup>().alpha += fadeSpeed * Time.deltaTime;
	}
	void DecreaseAlpha() //doesn't work with the current UI setup.
	{
		GetComponent<Animator>().SetBool("Fade", false);
	}
}
