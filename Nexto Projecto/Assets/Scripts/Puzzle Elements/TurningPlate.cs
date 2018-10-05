using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningPlate : MonoBehaviour {
    [SerializeField] Animator myAnimator;
    [SerializeField] bool turnAtStart;
    [SerializeField] AudioSource myAudio;

    private void Start() {
        if(turnAtStart == true) {
            Play();
        }
        else {
            Pause();
        }
    }

    public void Pause() {
        myAnimator.speed = 0;
        myAudio.Pause();
    }

    public void Play() {
        myAnimator.speed = 1;
        myAudio.Play();
    }
}
