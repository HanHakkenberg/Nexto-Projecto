using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour {

	public List<AudioSource> master;
	public List<AudioSource> effects;
	public List<AudioSource> environmental;
	bool masterOn = true;
	bool effectsOn = true;
	bool envirOn = true;

	void Start () 
	{
		master.AddRange(effects);
		master.AddRange(environmental);
	}

	void Update () 
	{
	}

	public void masterClick()
	{
		masterOn = !masterOn;

	}
	public void effectsClick()
	{
		effectsOn = !effectsOn;
	}
	public void environmentalClick()
	{
		envirOn = !envirOn;
	}

	public void applyClick()
	{
		for(int i = 0; i < master.Count; i++)
		{
			if(masterOn){
				master[i].GetComponent<AudioSource>().mute = false;
			}
			else
			{
				master[i].GetComponent<AudioSource>().mute = true;
			}
		}
		for(int j = 0; j < environmental.Count; j++)
		{
			if(envirOn)
			{
				if(environmental[j].tag == "MusicEnvironment"){
				environmental[j].GetComponent<AudioSource>().mute = false;
				}
			}
			else
			{
				if(!masterOn)
				{
					environmental[j].GetComponent<AudioSource>().mute = true;
				}
			}
		}
	}
}
