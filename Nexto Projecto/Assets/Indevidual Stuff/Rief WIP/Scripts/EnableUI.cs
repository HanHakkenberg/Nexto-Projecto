using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableUI : MonoBehaviour {

	public bool toEnable;
	public NewUI uiElement;


	void Start () {
		
	}
	
	void Update () {
		UIBehaviour();
	}

	public void UIBehaviour()
	{
		if(toEnable){
			uiElement.menuType.SetActive(true);
		} 
		else{
			uiElement.menuType.SetActive(false);
		}
	}
}
