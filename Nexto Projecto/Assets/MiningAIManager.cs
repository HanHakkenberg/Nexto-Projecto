using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningAIManager : MonoBehaviour {

    public static List<ParticleSystem> particles;

    public int fartID;

    public bool shouldOverrideStaticList;
    public List<ParticleSystem> myList;

    public void Awake() {
        if(shouldOverrideStaticList == true) {
            particles = myList;
        }
    }

    public void LoadFart() {
        particles[fartID].Play();
    }
}
