using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel : MonoBehaviour {

    public float speedIncreasePS = 1.2f;
    public float minSpeed = 1;
    public float maxSpeed = 8;

    private Animator anim;
    private float speed;

    bool reachedTopSpeed = false;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    void Update () {
        Rotate();
	}

    void Rotate() {
        if(anim.enabled)
            if (reachedTopSpeed == false && GameManager.gameManager.gameTimeout == true) {
            speed = Mathf.Lerp(speed, maxSpeed, speedIncreasePS * Time.deltaTime);
            if(Mathf.Approximately(speed, maxSpeed)) { 
             reachedTopSpeed = true;
             }
            } else {
                speed = Mathf.Lerp(speed, minSpeed, speedIncreasePS * Time.deltaTime);
            }

        anim.SetFloat("Speed", speed);
    }
}
