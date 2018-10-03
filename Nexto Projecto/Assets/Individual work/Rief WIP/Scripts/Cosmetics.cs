using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cosmetics : MonoBehaviour {

	[Header ("In Game")]
	public int currency;
	public TextMeshProUGUI currencyText;


	[Header ("Shop")]
	public GameObject playerSkin;
	public List<Material> skinTone;
	public TextMeshProUGUI currSkinText;
	int currSkin;

	public List<Mesh> hairType;
	//public GameObject playerHair;
	public TextMeshProUGUI currHairText;
	int currHair;

    public GameObject diaperColour;
    public List<Material> diaperType;
	//public GameObject playerDiaper;
	public TextMeshProUGUI currDiaperText;
	int currDiaper;

    public GameObject eyeLeft;
    public GameObject eyeRight;
    public List<Material> eyeType;
    public TextMeshProUGUI currEyesText;
    int currEyes;

    public GameObject cosmeticPanel_temp;
	

	void Update () 
	{
		AddCurrency();
	}

	void AddCurrency()
	{
		if(Input.GetKeyDown("="))
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

        diaperColour.GetComponent<Renderer>().material = diaperType[currDiaper];
        currDiaperText.text = diaperType[currDiaper].name;

        eyeLeft.GetComponent<Renderer>().material = eyeType[currEyes];
		eyeRight.GetComponent<Renderer>().material = eyeType[currEyes];
        currEyesText.text = eyeType[currEyes].name;
    }

	public void OpenCosmetics()
	{
		if(OptionManager.inGame)
		{
			cosmeticPanel_temp.SetActive(true);
            CosmeticUpdate();
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

	public void EyesUp()
	{
		if(currEyes > eyeType.Count-1)
		{
            currEyes++;
            CosmeticUpdate();
        }
	}

	public void EyesDown()
	{
		if(currEyes > 0)
		{
            currEyes--;
			CosmeticUpdate();
        }
	}
	#endregion
	
}
