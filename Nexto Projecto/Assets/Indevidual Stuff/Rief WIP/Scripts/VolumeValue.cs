using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour {

	public Slider masterSlider;
	void Start () {
		
	}
	
	void Update () {
		//volumeUpdate();
	}

	public void volumeUpdate()
	{
		GetComponent<Slider>().value = masterSlider.value;
	}
}
