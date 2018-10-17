using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class CosmeticInfo
{
	public string name;
    public Material colour;
    public Mesh hairType;
    public bool locked;
    public int cost;
}

public class Cosmetics : MonoBehaviour {


	[Header ("In Game")]
	public int currency;
	public TextMeshProUGUI currencyText;


	[Header ("Skin")]
	public GameObject playerSkin;
	public List<CosmeticInfo> skinTone = new List<CosmeticInfo>();
	public TextMeshProUGUI currSkinText;
	public GameObject skinBuyButton;
	int currSkin;

	[Header ("Hair")]
	public List<Mesh> hairType;
	//public GameObject playerHair;
	public TextMeshProUGUI currHairText;
	public GameObject hairBuyButton;
	int currHair;

	[Header("Diaper")]
	public List<CosmeticInfo> myDiapers = new List<CosmeticInfo>();
    
    public GameObject diaperModel;
	//public GameObject playerDiaper;
	public TextMeshProUGUI currDiaperText;
	public GameObject diaperBuyButton;
	int currDiaper;

	[Header ("Eyes")]
    public GameObject eyeLeft;
    public GameObject eyeRight;
    public List<CosmeticInfo> eyeType = new List<CosmeticInfo>();
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
		if(skinTone[currSkin].locked == false)
		{
			playerSkin.GetComponent<Renderer>().material = skinTone[currSkin].colour;
			skinBuyButton.SetActive(false);
		}
		else
		{
			skinBuyButton.SetActive(true);
		}

		if(myDiapers[currDiaper].locked == false)
		{
			diaperModel.GetComponent<Renderer>().material = myDiapers[currDiaper].colour;
			diaperBuyButton.SetActive(false);
		}
		else
		{
			diaperBuyButton.SetActive(true);
		}

		if(eyeType[currEyes].locked == false)
		{
			eyeLeft.GetComponent<Renderer>().material = eyeType[currEyes].colour;
			eyeRight.GetComponent<Renderer>().material = eyeType[currEyes].colour;
			eyesBuyButton.SetActive(false);
		}
		else
		{
			eyesBuyButton.SetActive(true);
		}
	}

	public void SkinBuy()
	{
		if(skinTone[currSkin].cost <= currency)
		{
            skinTone[currSkin].locked = false;
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
		if(myDiapers[currDiaper].cost <= currency)
		{
           myDiapers[currDiaper].locked = false;
        }
	}
	public void EyesBuy()
	{
		if(eyeType[currEyes].cost <= currency)
		{
			eyeType[currEyes].locked = false;
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
        LockedCheck();
        currSkinText.text = skinTone[currSkin].name;
        currDiaperText.text = myDiapers[currDiaper].name;
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
		if(currDiaper < myDiapers.Count-1)
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
