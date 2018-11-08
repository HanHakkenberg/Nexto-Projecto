using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenDiaper : MonoBehaviour {

    private void OnTriggerEnter(Collider _O) {
        if(_O.transform.tag == "Player") {
            Destroy(gameObject);
            CutsceneManager.cutsceneManager.LoadStartCutscene(13);
        }
    }
}
