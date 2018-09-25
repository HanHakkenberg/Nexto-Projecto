using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public static DialogueManager dialogueManager;

	[Header("Dialogue UI References:")]
	public GameObject uiCompleteDialogueBox; 
	public Text uiName;
	public Text uiDialogue;
	public GameObject progressIndicator;
	public GameObject tooltip;

	[Header("Visual Effects:")]
	public float timeTillNewChar = 0.15f;

	[Header("Functionality:")]
	public bool canTalk = true;
	public float timeBetweenSessions = 1.5f;
	public bool canGoNextPage = false;

	Dialogue currentlyUsedDialogue = null;
	float timer = 0;
	float sessionTimer = 0;
	int dialogueBoxIndex = 0; //Current index representing the part of the script we are at now;
	int charIndex = 0; //Used to add a char one at a time;

	void Update() {
		if(currentlyUsedDialogue != null) {
		LoadInNewChar();
		LoadNextDialogueBox();
		RefreshDialogueTimer();
		}
	}

	void Awake() {
		if(dialogueManager != null)
		return;
		else
		dialogueManager = this;
	}

	bool TimeCheck() {
		timer += Time.deltaTime;

		if(timer >= timeTillNewChar) {
			timer = 0;
			return true;
		}

		return false;
	}

	public void LoadInNewDialogue(Dialogue _Dialogue) {
		GameManager.gameManager.gameTimeout = true;
		currentlyUsedDialogue = _Dialogue;
		charIndex = 0;
		dialogueBoxIndex = 0;
		canGoNextPage = false;
		uiName.text = currentlyUsedDialogue.dialogue[dialogueBoxIndex].name;
		uiDialogue.text = "";
		progressIndicator.SetActive(false);
		uiCompleteDialogueBox.SetActive(true);
	}

	void LoadNextDialogueBox() { //Next page with text;
		if(Input.GetKeyDown(KeyCode.E)) {
			if(currentlyUsedDialogue != null) {
				if(dialogueBoxIndex < currentlyUsedDialogue.dialogue.Count - 1) {
					dialogueBoxIndex++;
					charIndex = 0;
					progressIndicator.SetActive(false);
					uiName.text = currentlyUsedDialogue.dialogue[dialogueBoxIndex].name;
					uiDialogue.text = "";
					canGoNextPage = false;
					progressIndicator.SetActive(false);
				} else {
				uiCompleteDialogueBox.SetActive(false);
				currentlyUsedDialogue = null;
				GameManager.gameManager.gameTimeout = false;
				}
			} 
		}
	}

	void LoadInNewChar() {
		if(currentlyUsedDialogue != null) {
			if(canGoNextPage == false) {
				if(TimeCheck()) {
					if(currentlyUsedDialogue.dialogue[dialogueBoxIndex].currDialogueBox[charIndex] != '/') {
					uiDialogue.text += currentlyUsedDialogue.dialogue[dialogueBoxIndex].currDialogueBox[charIndex];
					} else {
						uiDialogue.text += "\n";
					}

					if(charIndex < currentlyUsedDialogue.dialogue[dialogueBoxIndex].currDialogueBox.Length - 1) {
						charIndex++;
						LoadInNewChar();
					} else {
						canGoNextPage = true;
						progressIndicator.SetActive(true);
					}
				}
			}
		}
	}

	void RefreshDialogueTimer() {
		if(canTalk == false) {
			if(sessionTimer < timeBetweenSessions) {
			sessionTimer += Time.deltaTime;
			} else {
				canTalk = true;
				sessionTimer = 0;
			}
		}
	}
}
