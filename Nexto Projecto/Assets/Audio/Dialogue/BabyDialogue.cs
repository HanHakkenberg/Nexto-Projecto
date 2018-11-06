using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDialogue : MonoBehaviour {

    public static List<AudioClip> babyConvo;

    [Header("Options:")]
    public bool shouldOverrideStaticList = false;
    public List<AudioClip> newStaticAudioList;

    private int index = 0;
    private AudioSource source;

    private void Awake() {
        source = GetComponent<AudioSource>();

        if(shouldOverrideStaticList == true) {
            babyConvo = newStaticAudioList;
        }
    }

    public void PlayAudio() {
        source.PlayOneShot(babyConvo[index]);
        GetNewIndex();
    }

    void GetNewIndex() {
        if(index < babyConvo.Count - 1) {
            index++;
        } else {
            index = 0;
        }
    }
}
