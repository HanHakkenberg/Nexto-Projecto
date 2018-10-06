using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour {

	public AudioSource soundSource;
	public AudioClip hoverSound;
	public AudioClip clickSound;

	public void OnHover()
	{
		soundSource.PlayOneShot(hoverSound);
	}
	public void OnClick()
	{
		soundSource.PlayOneShot(clickSound);
	}
}
