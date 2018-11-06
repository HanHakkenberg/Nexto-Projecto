using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningAIManager : MonoBehaviour {

    public static List<ParticleSystem> particles;

    public int fartID;

    public bool shouldOverrideStaticList;
    public List<ParticleSystem> myList;

    Animator anim;

    public void Awake() {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        StartCoroutine(StartUpAnimator());
        if(shouldOverrideStaticList == true) {
            particles = myList;
        }
    }

    public void LoadFart() {
        particles[fartID].Play();
    }

    IEnumerator StartUpAnimator() {
        yield return new WaitForSeconds(Random.Range(0, 3));
        GetComponent<Animator>().enabled = true;
    }
}
