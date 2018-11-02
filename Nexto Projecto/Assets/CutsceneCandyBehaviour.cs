using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCandyBehaviour : MonoBehaviour {

    public float activationTime = 4;
    public Animator anim;

    public void StartAnimation() {
        StartCoroutine(Animate());
    }

    public IEnumerator Animate() {
        yield return new WaitForSeconds(activationTime);
        anim.enabled = true;
    }
} 
