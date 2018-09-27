using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningPlate : MonoBehaviour {
    [SerializeField] Animator myAnimator;
    [SerializeField] bool turnAtStart;

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
    }

    public void Play() {
        myAnimator.speed = 1;
    }
}
