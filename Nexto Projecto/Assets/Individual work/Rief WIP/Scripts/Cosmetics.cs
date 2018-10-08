using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cosmetics : MonoBehaviour {

	[Header ("In Game")]
	public int currency;
	public TextMeshProUGUI currencyText;


	[Header ("Skin")]
	public GameObject playerSkin;
	public List<GameObject> skinTone;
	public TextMeshProUGUI currSkinText;
	public GameObject skinBuyButton;
	int currSkin;

	[Header ("Hair")]
	public List<Mesh> hairType;
	//public GameObject playerHair;
	public TextMeshProUGUI currHairText;
	public GameObject hairBuyButton;
	int currHair;

	[Header ("Diaper")]
    public GameObject diaperColour;
    public List<GameObject> diaperType;
	//public GameObject playerDiaper;
	public TextMeshProUGUI currDiaperText;
	public GameObject diaperBuyButton;
	int currDiaper;

	[Header ("Eyes")]
    public GameObject eyeLeft;
    public GameObject eyeRight;
    public List<GameObject> eyeType;
    public TextMeshProUGUI currEyesText;
	public GameObject eyesBuyButton;
    int currEyes;

    public GameObject cosmeticPanel_temp;

	void Update () 
	{
		AddCurrency();
		LockedCheck();
	}

	void AddCurrency()
	{
		if(Input.GetKeyDown("="))
		{
			currency++;
			CurrencyUpdate();
		}
	}

	public void LockedCheck()
	{
		if(skinTone[currSkin].GetComponent<CosmeticCost>().locked == false)
		{
			playerSkin.GetComponent<Renderer>().material = skinTone[currSkin].GetComponent<Renderer>().sharedMaterial;
			skinBuyButton.SetActive(false);
		}
		else
		{
			skinBuyButton.SetActive(true);
		}

		if(diaperType[currDiaper].GetComponent<CosmeticCost>().locked == false)
		{
			diaperColour.GetComponent<Renderer>().material = diaperType[currDiaper].GetComponent<Renderer>().sharedMaterial;
			diaperBuyButton.SetActive(false);
		}
		else
		{
			diaperBuyButton.SetActive(true);
		}

		if(eyeType[currEyes].GetComponent<CosmeticCost>().locked == false)
		{
			eyeLeft.GetComponent<Renderer>().material = eyeType[currEyes].GetComponent<Renderer>().sharedMaterial;
			eyeRight.GetComponent<Renderer>().material = eyeType[currEyes].GetComponent<Renderer>().sharedMaterial;
			eyesBuyButton.SetActive(false);
		}
		else
		{
			eyesBuyButton.SetActive(true);
		}
	}

	public void SkinBuy()
	{
		if(skinTone[currSkin].GetComponent<CosmeticCost>().cost <= currency)
		{
			skinTone[currSkin].GetComponent<CosmeticCost>().locked = false;
		}
	}

	/*public void HairBuy()
	{
		if(hairType[currHair].GetComponent<CosmeticCost>().cost <= currency)
		{
			skinTone[currSkin].GetComponent<CosmeticCost>().locked = false;
		}
	}*/

	public void DiaperBuy()
	{
		if(diaperType[currDiaper].GetComponent<CosmeticCost>().cost <= currency)
		{
			diaperType[currDiaper].GetComponent<CosmeticCost>().locked = false;
		}
	}
	public void EyesBuy()
	{
		if(eyeType[currEyes].GetComponent<CosmeticCost>().cost <= currency)
		{
			eyeType[currEyes].GetComponent<CosmeticCost>().locked = false;
		}
	}

	public void SpendCurrency(int _Cost)
	{
		
		if(_Cost <= currency){
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
		currSkinText.text = skinTone[currSkin].name;
        currDiaperText.text = diaperType[currDiaper].name;
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
