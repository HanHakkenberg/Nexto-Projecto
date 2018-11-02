using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionUnlock : MonoBehaviour {

    private void OnTriggerEnter(Collider _O) {
        if(_O.transform.tag == "Player") {
            CutsceneTrigger();
        }
    }

    void CutsceneTrigger() {
        if(GameManager.gameManager.player.GetComponent<PlayerController>().canSummonCompanion == false) {
            GameManager.gameManager.player.GetComponent<PlayerController>().canSummonCompanion = true;
            CutsceneManager.cutsceneManager.LoadStartCutscene(1);
        }
    }
}
