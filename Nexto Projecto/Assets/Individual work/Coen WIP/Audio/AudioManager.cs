using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This manager its sole purpose is dealing with audio*/

public class AudioManager : MonoBehaviour {

    [Header("Sorting Purposes:")]
    public Transform audioCollector;

    [Header("Prefab Component:")]
    public AudioSource audioSettings;

    [System.Serializable]
    public struct AudioFiles {
        public string name;
        public AudioClip clip;
    }

    public List<AudioFiles> audioFiles;

    public static AudioManager audioManager;

    public void Awake() {
        if (audioManager == null) { audioManager = this; return; }
        Destroy(this);
    }

    public void PlayAudio(int _ID, Transform _Transform) {
        if (_ID < audioFiles.Count) { //If a audioclip exists;
            GameObject _Sound = new GameObject(audioFiles[_ID].name); //Instantiates the gameobject with the name of the audiofile;
            _Sound.AddComponent<AudioSource>(); //Adds the audiosource component;
            _Sound.transform.position = _Transform.position;
            _Sound.transform.SetParent(audioCollector);

            AudioSource _SoundComponent = _Sound.GetComponent<AudioSource>(); //Sets the reference to the component;
            _SoundComponent = audioSettings; //Sets the parameters of the audiosource;
            _SoundComponent.enabled = true; //Activates the audio component;
            _SoundComponent.clip = audioFiles[_ID].clip; //Overloads the clip into the audiosource;
            _SoundComponent.Play(); //Plays the audioclip;
            _Sound.AddComponent<Destroy>(); //Adds the destroy component;
            StartCoroutine(_Sound.GetComponent<Destroy>().DestroySelf(_SoundComponent.clip.length));
        }
    }
}