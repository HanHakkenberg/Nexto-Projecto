using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

[System.Serializable]
public class CosmeticInfo
{
	public string name;
    public Material colour;
    public GameObject hairType;
    public bool locked;
    public int cost;
}

public class Cosmetics : MonoBehaviour {


	[Header ("In Game")]
	public int currency;
	public TextMeshProUGUI currencyText;
    public Transform playerTrans;
    Vector3 oldPos;
 	Quaternion oldRot;
    public List<Transform> cosmeticPos;
    public CinemachineFreeLook mainCam;
    public List<GameObject> cosmeticCamLoc;
    public List<CinemachineVirtualCamera> cosmeticCam;
    public static int currLevel = 1;



    [Header ("Skin")]
	public GameObject playerSkin;
	public List<CosmeticInfo> skinTone = new List<CosmeticInfo>();
	public TextMeshProUGUI currSkinText;
	public GameObject skinBuyButton;
    public TextMeshProUGUI skinBuyText;
    int currSkin;

	[Header ("Hair")]
	public List<CosmeticInfo> hairType;
	//public GameObject playerHair;
	public TextMeshProUGUI currHairText;
	public GameObject hairBuyButton;
    public TextMeshProUGUI hairBuyText;
    public int currHair;

	[Header("Diaper")]
	public GameObject diaperModel;
	public List<CosmeticInfo> myDiapers = new List<CosmeticInfo>();
	//public GameObject playerDiaper;
	public TextMeshProUGUI currDiaperText;
	public GameObject diaperBuyButton;
    public TextMeshProUGUI diaperBuyText;
    int currDiaper;

	[Header ("Eyes")]
    public GameObject eyeLeft;
    public GameObject eyeRight;
    public List<CosmeticInfo> eyeType = new List<CosmeticInfo>();
    public TextMeshProUGUI currEyesText;
	public GameObject eyesBuyButton;
	public TextMeshProUGUI eyeBuyText;
    int currEyes;

	[Header ("Other")]
    public GameObject cosmeticPanel_temp;

    Material startSkin;
    Material startDiaper;
    Material startEyes;
    GameObject startHair;

    public int skinNumb;
    int diaperNumb;
    int eyeNumb;
    public int hairNumb;

    public Material skinColour;
    public Material diaperColour;
    public Material eyeColour;


	void Awake()
	{
        skinNumb = currSkin;
        diaperNumb = currDiaper;
        eyeNumb = currEyes;
        hairNumb = currHair;
    }
	void UpdateColours()
	{
        playerSkin.GetComponent<Renderer>().material = skinColour;
        diaperModel.GetComponent<Renderer>().material = diaperColour;
        eyeRight.GetComponent<Renderer>().material = eyeColour;
		eyeLeft.GetComponent<Renderer>().material = eyeColour;

        for (int i = 0; i < hairType.Count; i++)
		{
            hairType[i].hairType.SetActive(false);
        }
        hairType[currHair].hairType.SetActive(true);
    }

    public void SaveCurrent()
	{
		skinNumb = currSkin;
        diaperNumb = currDiaper;
        eyeNumb = currEyes;
        hairNumb = currHair;
        startSkin = skinColour;
        startDiaper = diaperColour;
        startEyes = eyeColour;
		UpdateColours();
    }

	public void ApplyStartCosmetics()
	{
        currSkin = skinNumb;
        diaperNumb = currDiaper;
        eyeNumb = currEyes;
        skinColour = startSkin;
        diaperColour = startDiaper;
		eyeColour = startEyes;
		UpdateColours();
        for (int i = 0; i < hairType.Count; i++)
		{
            hairType[i].hairType.SetActive(false);
        }
        hairType[hairNumb].hairType.SetActive(true);
		
    }


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
			skinColour = skinTone[currSkin].colour;
			skinBuyButton.SetActive(false);
		}
		else
		{
			skinBuyButton.SetActive(true);
            skinBuyText.text = "Buy " + skinTone[currSkin].cost + "c";
        }

		if(myDiapers[currDiaper].locked == false)
		{
			diaperColour = myDiapers[currDiaper].colour;
			diaperBuyButton.SetActive(false);
		}
		else
		{
			diaperBuyButton.SetActive(true);
            diaperBuyText.text = "Buy " + myDiapers[currDiaper].cost + "c";
        }

		if(eyeType[currEyes].locked == false)
		{
			eyeColour = eyeType[currEyes].colour;
			eyesBuyButton.SetActive(false);
		}
		else
		{
			eyesBuyButton.SetActive(true);
            eyeBuyText.text = "Buy " + eyeType[currEyes].cost + "c";
        }
		if(hairType[currHair].locked == false)
		{
            hairBuyButton.SetActive(false);
        }
		else
		{
            hairBuyButton.SetActive(true);
			hairBuyText.text = "Buy " + hairType[currHair].cost + "c";
        }
	}

	public void SkinBuy()
	{
		if(skinTone[currSkin].cost <= currency)
		{
            skinTone[currSkin].locked = false;
        }
	}

		public void HairBuy()
	{
		if(hairType[currHair].cost <= currency)
		{
			hairType[currHair].locked = false;
		}
	}

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
        currHairText.text = hairType[currHair].name;
    }

	public void OpenCosmetics()
	{
		if(OptionManager.inGame)
		{
			cosmeticPanel_temp.SetActive(true);
            CosmeticUpdate();
			//OptionManager.inGame = false;
		}
	}

	public void SetPosition()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
        oldPos = playerTrans.position;
        oldRot = playerTrans.rotation;
        playerTrans.position = cosmeticPos[currLevel-1].position;
        playerTrans.LookAt(cosmeticCamLoc[currLevel-1].transform);
        cosmeticCam[currLevel - 1].enabled = true;
        mainCam.enabled = false;


    }
	public void ResetPosition()
	{
        playerTrans.position = oldPos;
        playerTrans.rotation = oldRot;
        cosmeticCam[currLevel - 1].enabled = false;
        mainCam.enabled = true;
	}

#region ButtonClicks
	public void SkinUp()
	{
		if(currSkin < skinTone.Count-1)
		{
			currSkin++;
			CosmeticUpdate();
			UpdateColours();
		}
	}
	public void SkinDown()
	{
		if(currSkin > 0)
		{
			currSkin--;
			CosmeticUpdate();
			UpdateColours();
		}
	}
		public void HairUp()
	{
		if(currHair < hairType.Count-1)
		{
			currHair++;
			CosmeticUpdate();
            UpdateColours();
        }
	}
	public void HairDown()
	{
		if(currHair > 0)
		{
			currHair--;
			CosmeticUpdate();
			UpdateColours();
        }
	}
	public void DiaperUp()
	{
		if(currDiaper < myDiapers.Count-1)
		{
			currDiaper++;
			CosmeticUpdate();
			UpdateColours();
		}
	}
	public void DiaperDown()
	{
		if(currDiaper > 0)
		{
			currDiaper--;
			CosmeticUpdate();
			UpdateColours();
		}
	}

	public void EyesUp()
	{
		if(currEyes > eyeType.Count-1)
		{
            currEyes++;
            CosmeticUpdate();
			UpdateColours();
        }
	}

	public void EyesDown()
	{
		if(currEyes > 0)
		{
            currEyes--;
			CosmeticUpdate();
			UpdateColours();
        }
	}
	#endregion
	
}
