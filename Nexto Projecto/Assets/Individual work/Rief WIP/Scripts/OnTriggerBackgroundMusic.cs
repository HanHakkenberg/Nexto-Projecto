using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerBackgroundMusic : MonoBehaviour {

    public int songChoice;
    public GameObject player;



    public void OnTriggerEnter()
	{
        player.GetComponent<BackgroundMusic>().fading = true;
        player.GetComponent<BackgroundMusic>().currClip = songChoice;
	}
}
