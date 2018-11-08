using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutQuestCutscene : MonoBehaviour {

    bool hasPlayed;

    void Start () {
		
	}

    void OnTriggerEnter(Collider _P)
    {
        if (_P.tag == "Player")
        {
            if (!hasPlayed)
            {
                CutsceneManager.cutsceneManager.LoadStartCutscene(11);
                hasPlayed = true;
            }
        }
    }
}
