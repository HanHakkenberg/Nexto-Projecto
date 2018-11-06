using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    //Used for animation event to play audio;

    public void CallAudio(int _ID) {
        AudioManager.audioManager.PlayAudio(_ID, transform);
    }
}
