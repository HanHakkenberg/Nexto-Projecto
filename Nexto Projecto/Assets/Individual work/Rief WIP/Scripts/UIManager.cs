using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public GameObject startScreen;
	public GameObject optionScreen;
	private bool canPressEsc = false;

	void Start () 
	{

	}

	void Update () 
	{
		EscapeButton();
	}
	public void StartButton()
	{
		TurnOffAll();
	}
	public void OptionButton()
	{
		startScreen.SetActive(false);
		optionScreen.SetActive(true);
		canPressEsc = true;
	}
	void TurnOffAll()
	{
		startScreen.SetActive(false);
		optionScreen.SetActive(false);
		canPressEsc = true;
	}
	void EscapeButton()
	{
		if(canPressEsc == true && Input.GetButton("Cancel"))
		{
			BackButton();
		}
	}
	public void BackButton()
	{
		optionScreen.SetActive(false);
		startScreen.SetActive(true);
		canPressEsc = false;
	}
}
