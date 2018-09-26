using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FartInfo : MonoBehaviour {

    public bool canUse = false;
	
	void Update () 
	{
        Usable();
    }

	void Usable()
	{
		if(GetComponent<Image>().fillAmount >= 1)
		{
            canUse = true;
        }
		else
		{
            canUse = false;
        }
	}
}
