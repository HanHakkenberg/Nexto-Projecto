using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerBackgroundMusic : MonoBehaviour {


    //public int songChoice;
    //public GameObject player;
    public GameObject cosmetics;
    public List<CosmeticInfo> extraDiaper;
    public List<CosmeticInfo> extraHair;
    public int level;
    public bool hasAdded;



    public void OnTriggerEnter()
	{
       // player.GetComponent<BackgroundMusic>().fading = true;
       // player.GetComponent<BackgroundMusic>().currClip = songChoice;
        Cosmetics.currLevel = level;
        CosmeticForloop();

    }
    public void CosmeticForloop()
    {
        if (!hasAdded)
        {
            for (int i = extraHair.Count - 1; i >= 0; i--)
            {
                cosmetics.GetComponent<Cosmetics>().hairType.Add(extraHair[0]);
                extraHair.Remove(extraHair[0]);
            }

            for (int i = extraDiaper.Count - 1; i >= 0; i--)
            {
                cosmetics.GetComponent<Cosmetics>().myDiapers.Add(extraDiaper[0]);
                extraDiaper.Remove(extraDiaper[0]);
            }
        }
        hasAdded = false;
    }
}
