using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContainer : MonoBehaviour {

	[Header("Dialogue Info;")]
	public Dialogue dialogue;

	public bool canLoadUpDialogue = false;

	void Update() {
		LoadDialogue();
	}

	void OnTriggerEnter(Collider _C) {
		if(_C.transform.tag == "Player") {
			canLoadUpDialogue = true;
			DialogueManager.dialogueManager.tooltip.SetActive(true);
		}
	}

	void OnTriggerExit(Collider _C) {
		if(_C.transform.tag == "Player") {
			canLoadUpDialogue = false;
			DialogueManager.dialogueManager.tooltip.SetActive(false);
		}
	}

	public void LoadDialogue() {
		if(Input.GetButtonDown("Fire1")) {
			if(canLoadUpDialogue == true) {
				if(GameManager.gameManager.gameTimeout == false) {
					CutsceneManager.cutsceneManager.dialogueTarget.m_Targets[1].target = transform;
					CutsceneManager.cutsceneManager.dialogueCamera.enabled = true;
					CutsceneManager.cutsceneManager.abilityCam.enabled = false;
					CutsceneManager.cutsceneManager.mainCam.enabled = false;

					DialogueManager.dialogueManager.LoadInNewDialogue(dialogue);
					DialogueManager.dialogueManager.tooltip.SetActive(false);
					}
				}
			}
		}
	}
