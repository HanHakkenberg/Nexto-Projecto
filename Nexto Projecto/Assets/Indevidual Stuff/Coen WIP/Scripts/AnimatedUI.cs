using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedUI : MonoBehaviour {

	[Header("UI Settings:")]
	public string textBase;
	public string textAdded;
	public float timeTillUpdate = 0.4f;

	Text text;
	float timer;
	int charIndex;

	void Awake() {
		text = GetComponent<Text>();
	}

	// Use this for initialization
	void Update() {
		UpdateText();
	}

	void UpdateText() {
		timer += Time.deltaTime;

		if(timer > timeTillUpdate) {
			timer = 0;

			if(charIndex < textAdded.Length) {
				text.text += textAdded[charIndex];
				charIndex++;
			} else {
				text.text = textBase;
				charIndex = 0;
			}
		}
	}
}
