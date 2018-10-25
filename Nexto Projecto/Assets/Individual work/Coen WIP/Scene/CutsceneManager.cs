using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour {

	public static CutsceneManager cutsceneManager;

	public bool cutscenePlaying = false;

	public bool playStartscene = false;

	[Header("Dialogue Settings:")]
	public Dialogue[] cutSceneDialogue;
	public Transform[] cutsceneLocations;

	[Header("Static Ability Cutscene Related:")]
	public Animator blackscreen;
	public float blackScreenTimer = 5;

	[Header("Ability Cutscene Timers:")]
	public float timeAfterDialogue = 7;

	[System.Serializable]
	public class Cutscene {
		public string cutsceneName;
		public float startDialogueTimer;
		public float cameraSwitchDuration;
		public float endingDuration;

		[Header("Focussed-Npc:")]
		public GameObject npc;
		public Dialogue endDialogue;

		[Header("Cameras:")]
		public List<Cinemachine.CinemachineVirtualCamera> cameras = new List<Cinemachine.CinemachineVirtualCamera>();

		[Header("Dialogue:")]
		public List<Dialogue> dialogues = new List<Dialogue>();

	}

	[Header("Actual Cutscenes Setup;")]
	public List<Cutscene> allCutscenes;

	[Header("Cams:")]
	public Cinemachine.CinemachineFreeLook mainCam;
	public Cinemachine.CinemachineVirtualCamera abilityCam;
	public Cinemachine.CinemachineVirtualCamera dialogueCamera;
	public Cinemachine.CinemachineTargetGroup dialogueTarget;

	internal Cutscene currentScene = null;

	void Awake() {
		if(cutsceneManager != null)
		Destroy(this);
		else
		cutsceneManager = this;
	}

	void Start() {
		if(playStartscene == true)
		StartCoroutine(StartCutscene(0));
	}

	internal void StartLoadCamera(int _ID) {
		blackscreen.SetBool("IsFading", false);
		StartCoroutine(LoadCamera(_ID));
	}

	IEnumerator LoadCamera(int _ID) {
		yield return new WaitForSeconds(currentScene.cameraSwitchDuration);
		foreach(Cinemachine.CinemachineVirtualCamera _Cam in currentScene.cameras) 
		_Cam.enabled = false;
		currentScene.cameras[_ID].enabled = true;
	}

	internal void StartLoadCutsceneDialogue(int _ID) {
		StartCoroutine(LoadCutsceneDialogue(_ID));
	}

	IEnumerator LoadCutsceneDialogue(int _ID) {
		yield return new WaitForSeconds(currentScene.startDialogueTimer);
		DialogueManager.dialogueManager.LoadCutsceneDialogue(currentScene.dialogues[_ID]);
	}

	public void EndCutscene() {
		StartCoroutine(LoadEndCutscene());
	}
	

	IEnumerator LoadEndCutscene() {
		blackscreen.SetBool("IsFading", false);
		yield return new WaitForSeconds(currentScene.endingDuration);
		mainCam.enabled = true;
		blackscreen.SetBool("IsFading", true);
		yield return new WaitForSeconds(currentScene.endingDuration);
		if(currentScene.npc != null && currentScene.endDialogue != null) {
			DialogueManager.dialogueManager.LoadInNewDialogue(currentScene.endDialogue, currentScene.npc.transform);
		} else {
			currentScene = null;
			GameManager.gameManager.gameTimeout = false;
			cutscenePlaying = false;
		}
	}

	public IEnumerator StartCutscene(int _I) {
		cutscenePlaying = true;
		GameManager.gameManager.statisticsParent.SetActive(false);
		blackscreen.SetBool("IsFading", true);
		GameManager.gameManager.gameTimeout = true;
		currentScene = allCutscenes[_I];
		mainCam.enabled = false;
		currentScene.cameras[0].enabled = true;
		yield return new WaitForSeconds(currentScene.cameraSwitchDuration);
		blackscreen.SetBool("IsFading", false);
		yield return new WaitForSeconds(currentScene.startDialogueTimer);
		DialogueManager.dialogueManager.LoadCutsceneDialogue(currentScene.dialogues[0]);

	}

	public void LoadAbilityCutscene(int i) {
		StartCoroutine(StartAbilityCutScene(i));
	}

	public IEnumerator StartAbilityCutScene(int _Index) {
		blackscreen.SetBool("IsFading", true);
		mainCam.enabled = false;
		abilityCam.enabled = true;
		yield return new WaitForSeconds(2);
		blackscreen.SetBool("IsFading", false);
		DialogueManager.dialogueManager.LoadInAbilityDialogue(cutSceneDialogue[0]);
	
		for(int i = 0; i < Mathf.Infinity; i++) {
			yield return new WaitForSeconds(2);
			if(GameManager.gameManager.gameTimeout == false) {
			GameManager.gameManager.gameTimeout = true;
			break;
			}
		}
		mainCam.enabled = true;
		abilityCam.enabled = false;
		blackscreen.SetBool("IsFading", true);
		yield return new WaitForSeconds(timeAfterDialogue);
		blackscreen.SetBool("IsFading", false);
		GameManager.gameManager.gameTimeout = false;
	}

    public void SetupDialogue(Transform _TalkingTo)
    {
        CutsceneManager.cutsceneManager.dialogueTarget.m_Targets[1].target = _TalkingTo;
        CutsceneManager.cutsceneManager.dialogueCamera.enabled = true;
        CutsceneManager.cutsceneManager.abilityCam.enabled = false;
        CutsceneManager.cutsceneManager.mainCam.enabled = false;
        DialogueManager.dialogueManager.tooltip.SetActive(false);
    }
}
