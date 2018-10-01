using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour {

	public static CutsceneManager cutsceneManager;

	[Header("Dialogue Settings:")]
	public Dialogue[] cutSceneDialogue;
	public Transform[] cutsceneLocations;

	[Header("Static Ability Cutscene Related:")]
	public Animator blackscreen;
	public float blackScreenTimer = 5;

	[Header("Ability Cutscene Timers:")]
	public float timeAfterDialogue = 7;

	[Header("test")]
	public Cinemachine.CinemachineFreeLook mainCam;
	public Cinemachine.CinemachineVirtualCamera abilityCam;

	void Awake() {
		if(cutsceneManager != null)
		Destroy(this);
		else
		cutsceneManager = this;
	}

	public void LoadCutscene(int i) {
		StartCoroutine(StartCutScene(i));
	}

	public IEnumerator StartCutScene(int _Index) {
		GameManager.gameManager.gameTimeout = true;
		blackscreen.SetBool("IsFading", true);
		mainCam.enabled = false;
		abilityCam.enabled = true;
		yield return new WaitForSeconds(2);
		blackscreen.SetBool("IsFading", false);
		DialogueManager.dialogueManager.LoadInNewDialogue(cutSceneDialogue[0]);
	
		for(int i = 0; i < Mathf.Infinity; i++) {
			yield return new WaitForSeconds(2);
			if(GameManager.gameManager.gameTimeout == false)
			break;
		}

		mainCam.enabled = true;
		abilityCam.enabled = false;
		blackscreen.SetBool("IsFading", true);
		yield return new WaitForSeconds(timeAfterDialogue);
		blackscreen.SetBool("IsFading", false);
	}
}
