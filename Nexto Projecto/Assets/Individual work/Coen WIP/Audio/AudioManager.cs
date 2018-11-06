using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This manager its sole purpose is dealing with audio*/

public class AudioManager : MonoBehaviour {

    [Header("Sorting Purposes:")]
    public Transform audioCollector;

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
            _Sound.transform.position = _Transform.position;
            _Sound.transform.SetParent(audioCollector);
            PresetAudioSettings(_Sound, 100, 5, audioFiles[_ID].clip);
            Destroy _CurDestroy = _Sound.AddComponent<Destroy>(); //Adds the destroy component;
            StartCoroutine(_CurDestroy.DestroySelf());
        }
    }

    public static AudioSource PresetAudioSettings(GameObject _Obj, float _3D, float _MaxDistance, AudioClip _Clip) {
        AudioSource _PresetAudioSource = _Obj.AddComponent<AudioSource>();
        _PresetAudioSource.maxDistance = _MaxDistance;
        _PresetAudioSource.loop = false;
        _PresetAudioSource.rolloffMode = AudioRolloffMode.Custom;
        _PresetAudioSource.spatialBlend = _3D;
        _PresetAudioSource.PlayOneShot(_Clip);
        return _PresetAudioSource;
    }
}