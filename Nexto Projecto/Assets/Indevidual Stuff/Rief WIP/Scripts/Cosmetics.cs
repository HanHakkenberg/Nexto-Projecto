using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cosmetics : MonoBehaviour {

	[Header ("In Game")]
	public int currency;
	public Text currencyText;


	[Header ("Shop")]
	public GameObject playerSkin;
	public List<Material> skinTone;
	public Text currSkinText;
	int currSkin;

	public List<Mesh> hairType;
	//public GameObject playerHair;
	public Text currHairText;
	int currHair;

	public List<Material> diaperType;
	//public GameObject playerDiaper;
	public Text currDiaperText;
	int currDiaper;

	public GameObject cosmeticPanel_temp;
	

	void Update () 
	{
		AddCurrency();
	}

	void AddCurrency()
	{
		if(Input.GetButtonDown("SwitchKey"))
		{
			currency++;
			CurrencyUpdate();
		}
	}
	public void SpendCurrency(int _Cost)
	{
		if(_Cost >= currency){
			currency -= _Cost;
			CurrencyUpdate();
		}
	}
	void CurrencyUpdate()
	{
		currencyText.text = currency.ToString();
	}

	void CosmeticUpdate()
	{
		playerSkin.GetComponent<Renderer>().material = skinTone[currSkin];
		currSkinText.text = skinTone[currSkin].name;
	}

	public void OpenCosmetics()
	{
		if(OptionManager.inGame)
		{
			cosmeticPanel_temp.SetActive(true);
			OptionManager.inGame = false;
		}
	}

#region ButtonClicks
	public void SkinUp()
	{
		if(currSkin < skinTone.Count-1)
		{
			currSkin++;
			CosmeticUpdate();
		}
	}
	public void SkinDown()
	{
		if(currSkin > 0)
		{
			currSkin--;
			CosmeticUpdate();
		}
	}
		public void HairUp()
	{
		if(currHair < hairType.Count-1)
		{
			currHair++;
			CosmeticUpdate();
		}
	}
	public void HairDown()
	{
		if(currHair > 0)
		{
			currHair--;
			CosmeticUpdate();
		}
	}
	public void DiaperUp()
	{
		if(currDiaper < diaperType.Count-1)
		{
			currDiaper++;
			CosmeticUpdate();
		}
	}
	public void DiaperDown()
	{
		if(currDiaper > 0)
		{
			currDiaper--;
			CosmeticUpdate();
		}
	}
	#endregion
	
}
