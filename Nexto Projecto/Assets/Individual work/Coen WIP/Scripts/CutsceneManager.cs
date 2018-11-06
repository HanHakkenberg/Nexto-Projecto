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
	public GameObject pauseMenu;

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
        public float timeTillEndingDuration = 0f;
		public float endingDuration;

		[Header("Start Game-Event:")]
		public GameEvent startEvent;

		[Header("Focussed-Npc:")]
		public GameObject npc;
		public Dialogue endDialogue;

		[Header("Cameras:")]
		public List<Cinemachine.CinemachineVirtualCamera> cameras = new List<Cinemachine.CinemachineVirtualCamera>();
		public List<Animator> animatedObjects = new List<Animator>();

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
        if (playStartscene == true) {
            StartCoroutine(StartCutscene(0));
        } else {
            mainCam.enabled = true;
        }
	}

	public void StartLoadCamera(int _ID) {
		blackscreen.SetBool("IsFading", true);
		StartCoroutine(LoadCamera(_ID));
	}

	IEnumerator LoadCamera(int _ID) {
		foreach(Cinemachine.CinemachineVirtualCamera _Cam in currentScene.cameras) 
		_Cam.enabled = false;

		currentScene.cameras[_ID].enabled = true;
		yield return new WaitForSeconds(currentScene.cameraSwitchDuration);

		if(currentScene.animatedObjects[_ID] != null)
		currentScene.animatedObjects[_ID].enabled = true;
		blackscreen.SetBool("IsFading", false);
	}

	public void StartLoadCutsceneDialogue(int _ID) {
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
        yield return new WaitForSeconds(currentScene.timeTillEndingDuration);
        cutscenePlaying = false;
		blackscreen.SetBool("IsFading", true);
        foreach (Cinemachine.CinemachineVirtualCamera _Cam in currentScene.cameras)
            _Cam.enabled = false;
		mainCam.enabled = true;
		yield return new WaitForSeconds(currentScene.endingDuration);
		blackscreen.SetBool("IsFading", false);
		if(currentScene.npc != null && currentScene.endDialogue != null) {
			DialogueManager.dialogueManager.LoadInNewDialogue(currentScene.endDialogue, currentScene.npc.transform);
			currentScene = null;
		} else {
			currentScene = null;
			GameManager.gameManager.gameTimeout = false;
			
		}
	}

    public void LoadStartCutscene(int _I) {
        StartCoroutine(StartCutscene(_I));
    }

	public IEnumerator StartCutscene(int _I) {
		GameManager.gameManager.gameTimeout = true;
		pauseMenu.SetActive(false);
		cutscenePlaying = true;
		GameManager.gameManager.statisticsParent.SetActive(false);
		blackscreen.SetBool("IsFading", true);
		currentScene = allCutscenes[_I];
		mainCam.enabled = false;
		currentScene.cameras[0].enabled = true;
		yield return new WaitForSeconds(currentScene.cameraSwitchDuration);
		blackscreen.SetBool("IsFading", false);
		if(currentScene.startEvent != null)
			currentScene.startEvent.Raise();
		yield return new WaitForSeconds(currentScene.startDialogueTimer);

        if(currentScene != null)
        if(currentScene.dialogues.Count != 0)
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
		DialogueManager.dialogueManager.LoadInAbilityDialogue(cutSceneDialogue[_Index]);
	
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
