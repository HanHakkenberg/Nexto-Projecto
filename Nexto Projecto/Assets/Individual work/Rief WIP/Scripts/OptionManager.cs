﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

	[Header("Lists")]
	public List <AudioSource> music;
	public List<AudioSource> effects;
	public List<AudioSource> environmental;
    public AudioSource uiAudio;

    [Header("Sliders")]
	public Slider musicSlider;
	public Slider effectSlider;
	public Slider environmentSlider;
    public Slider uiSlider;
    List<Slider> allSliders = new List<Slider>();

	[Header("Booleans")]
	public bool subtitles = true;
	public bool cutscenes = true;
	bool masterOn = true;
	bool musicOn = true;
	bool effectsOn = true;
	bool envirOn = true;
    bool uiOn = true;
    public static bool inGame = false;
	public static bool started = false;

    [Header("Map")]
    public GameObject map;

	[Header("Pausing")]
	public GameObject pauseScreen;

    void Start () 
	{
		allSliders.Add(musicSlider);
		allSliders.Add(effectSlider);
		allSliders.Add(environmentSlider);
        allSliders.Add(uiSlider);
    }

	void Update()
	{
        Map();
        //Pausing();
    }

	public void MasterClick()
	{
		masterOn = !masterOn;

	}
	public void MusicClick()
	{
		musicOn = !musicOn;
	}
	public void EffectsClick()
	{
		effectsOn = !effectsOn;
	}
	public void EnvironmentalClick()
	{
		envirOn = !envirOn;
	}
	public void UIClick()
	{
        uiOn = !uiOn;
    }
	public void SubtitleClick()
	{
		subtitles = !subtitles;
	}
	public void CutsceneClick()
	{
		cutscenes = !cutscenes;
	}

	void Map()
	{
		if(Input.GetButtonDown("Map") && inGame) //Moet nog worden aangemaakt
		{
            if(map.activeInHierarchy == false)
			{
                map.SetActive(true);
            }
			else
			{
                map.SetActive(false);
            }
        }
	}
	
	public void InGame()
	{
		started = true;
        inGame = true;
        TimeScale();
    }
	public void ResetStarted()
	{
		started = false;
	}

	public void Pausing()
	{
        if (pauseScreen.activeInHierarchy == true)
        {
            Time.timeScale = 0;
            inGame = false;
        }
		else
		{
            Time.timeScale = 1;
            inGame = true;
        }
    }

	public void TimeScale()
	{
		if(inGame)
		{
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
		else
		{
            Time.timeScale = 0;
            Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
        }
	}

	public void MasterVolume(Slider masterSlider)
	{
		for(int i = 0; i < allSliders.Count; i++)
		{
			allSliders[i].value = masterSlider.value;
		}
	}

	public void ApplyClick()
	{
		//SOUND RELATED
		for(int o = 0; o < music.Count; o++)
		{
			music[o].GetComponent<AudioSource>().volume = musicSlider.GetComponent<Slider>().value;

			if(musicOn && masterOn)
			{
				music[o].GetComponent<AudioSource>().mute = false;
			}
			else
			{
				music[o].GetComponent<AudioSource>().mute = true;
			}
		}

		for(int k = 0; k < effects.Count; k++)
		{
			effects[k].GetComponent<AudioSource>().volume = effectSlider.GetComponent<Slider>().value;

			if(effectsOn && masterOn)
			{
				effects[k].GetComponent<AudioSource>().mute = false;
			}
			else
			{
				effects[k].GetComponent<AudioSource>().mute = true;
			}
		}

		for(int j = 0; j < environmental.Count; j++)
		{
			environmental[j].GetComponent<AudioSource>().volume = environmentSlider.GetComponent<Slider>().value;

			if(envirOn && masterOn)
			{
				environmental[j].GetComponent<AudioSource>().mute = false;
			}
			else
			{
				environmental[j].GetComponent<AudioSource>().mute = true;
			}
		}
		if(masterOn && uiOn)
		{
            uiAudio.mute = false;
        }
		else
		{
			if(!masterOn || !uiOn)
			{
                uiAudio.mute = true;
            }
		}

		//CUTSCENES RELATED
		if(cutscenes)
		{
			//Weet nog niet hoe de cutscenes gedaan worden, als ik dat weet kan ik hier mee verder
		}
	}
	public void Quit()
	{
        Application.Quit();
    }
}
