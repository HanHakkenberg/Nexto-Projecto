using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

[Header("Lists")]
	public List <AudioSource> music;
	public List<AudioSource> effects;
	public List<AudioSource> environmental;
	
[Header("Sliders")]
	public Slider musicSlider;
	public Slider effectSlider;
	public Slider environmentSlider;
	List<Slider> allSliders = new List<Slider>();

[Header("Booleans")]
	public bool subtitles = true;
	public bool cutscenes = true;
	bool masterOn = true;
	bool musicOn = true;
	bool effectsOn = true;
	bool envirOn = true;

	void Start () 
	{
		allSliders.Add(musicSlider);
		allSliders.Add(effectSlider);
		allSliders.Add(environmentSlider);
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
	public void SubtitleClick()
	{
		subtitles = !subtitles;
	}
	public void CutsceneClick()
	{
		cutscenes = !cutscenes;
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

		//SUBTITLE RELATED
		if(subtitles)
		{
			//zodra in game UI klaar is kan ik hier mee verder
		}
		else
		{
			//zodra in game UI klaar is kan ik hier mee verder
		}

		//CUTSCENES RELATED
		if(cutscenes)
		{
			//Weet nog niet hoe de cutscenes gedaan worden, als ik dat weet kan ik hier mee verder
		}
	}
}
