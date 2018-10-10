using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    public AudioSource bgmSource;
    public List<AudioClip> bgm = new List<AudioClip>();
    public int currClip;
    public bool fading;
    public float fadeTime;

	void Update()
	{
		if(fading)
		{
            bgmSource.volume -= fadeTime * Time.deltaTime;
        }
        else
		{
            bgmSource.volume += fadeTime * Time.deltaTime;
        }
        BGMUpdate();
	}

    public void BGMUpdate()
	{
        if (bgmSource.volume <= 0)
        {
            bgmSource.clip = bgm[currClip];
            bgmSource.Play();
			fading = false;
        }
    }
}
