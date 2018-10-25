using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public static DialogueManager dialogueManager;

    [Header("Target:")]
    public Transform target;

	[Header("Dialogue UI References:")]
	public Animator dialogueBox;
	public GameObject uiCompleteDialogueBox; 
	public Text uiName;
	public Text uiDialogue;
	public GameObject progressIndicator;
	public GameObject continuationHint;
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

	bool spottedWhitespace = false;

	void Update() {
		if(currentlyUsedDialogue != null) {
		LoadInNewChar();
		LoadNextDialogueBox();
		}

		RefreshDialogueTimer();
	}

	void Awake() {
		if(dialogueManager != null)
		return;
		else
		dialogueManager = this;
	}

	bool TimeCheck() {
		timer += Time.deltaTime;

		if(spottedWhitespace == true) {
			if(timer >= currentlyUsedDialogue.dialogue[dialogueBoxIndex].options.waitTime) {
				spottedWhitespace = false;
				return true;
			} else {
				return false;
			}
		}

		if(timer >= currentlyUsedDialogue.timeTillNewChar) {
			timer = 0;
			return true;
		}

		return false;
	}

	void SetUI(bool _Current) {
		if(_Current) {
			progressIndicator.SetActive(true);
			continuationHint.SetActive(true);
			tooltip.SetActive(true);
		} else {
			progressIndicator.SetActive(false);
			continuationHint.SetActive(false);
			tooltip.SetActive(false);
		}
	}

	public void LoadInNewDialogue(Dialogue _Dialogue, Transform _Target)
    {
		canTalk = false;
        GameManager.gameManager.gameTimeout = true;
        target = _Target;
        CutsceneManager.cutsceneManager.SetupDialogue(_Target);
        GameManager.gameManager.statisticsParent.SetActive(false);
		currentlyUsedDialogue = _Dialogue;
		charIndex = 0;
		dialogueBoxIndex = 0;
		canGoNextPage = false;
		uiName.text = currentlyUsedDialogue.dialogue[dialogueBoxIndex].name;
		uiDialogue.text = "";
		SetUI(false);
		tooltip.SetActive(false);
		dialogueBox.SetBool("Load", true);
	}

		public void LoadCutsceneDialogue(Dialogue _Dialogue)
    {
		canTalk = false;
        GameManager.gameManager.statisticsParent.SetActive(false);
		currentlyUsedDialogue = _Dialogue;
		charIndex = 0;
		dialogueBoxIndex = 0;
		canGoNextPage = false;
		uiName.text = currentlyUsedDialogue.dialogue[dialogueBoxIndex].name;
		uiDialogue.text = "";
		SetUI(false);
		tooltip.SetActive(false);
		dialogueBox.SetBool("Load", true);
	}

    public void LoadInAbilityDialogue(Dialogue _Dialogue)
    {
		canTalk = false;
        GameManager.gameManager.gameTimeout = true;
        GameManager.gameManager.statisticsParent.SetActive(false);
        CutsceneManager.cutsceneManager.mainCam.enabled = false;
        CutsceneManager.cutsceneManager.dialogueCamera.enabled = false;
        CutsceneManager.cutsceneManager.abilityCam.enabled = true;
        currentlyUsedDialogue = _Dialogue;
        charIndex = 0;
        dialogueBoxIndex = 0;
        canGoNextPage = false;
        uiName.text = currentlyUsedDialogue.dialogue[dialogueBoxIndex].name;
        uiDialogue.text = "";
		SetUI(false);
		tooltip.SetActive(false);
        dialogueBox.SetBool("Load", true);
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
					continuationHint.SetActive(false);
					progressIndicator.SetActive(false);
				} else {
				StartCoroutine(ActivateFunctions(currentlyUsedDialogue));
				continuationHint.SetActive(false);
				dialogueBox.SetBool("Load", false);
                target = null;
				currentlyUsedDialogue = null;

					if(CutsceneManager.cutsceneManager.cutscenePlaying == false) {
						GameManager.gameManager.statisticsParent.SetActive(true);
						GameManager.gameManager.gameTimeout = false;
						CutsceneManager.cutsceneManager.mainCam.enabled = true;
						CutsceneManager.cutsceneManager.dialogueCamera.enabled = false;
					}
				}
			} 
		}
	}

	IEnumerator ActivateFunctions(Dialogue _Cur) {
		if(currentlyUsedDialogue.shouldActivateFunctions)
		yield return new WaitForSeconds(currentlyUsedDialogue.timeTillActivation);
        if (_Cur.functionsToBeActivated != null)
            _Cur.functionsToBeActivated.Raise();
    }

	void LoadInNewChar() {
		if(currentlyUsedDialogue != null) {
			if(canGoNextPage == false) {
				if(TimeCheck()) {
					if(currentlyUsedDialogue.dialogue[dialogueBoxIndex].options.shouldWaitAtSpace)
						if(currentlyUsedDialogue.dialogue[dialogueBoxIndex].currDialogueBox[charIndex] == ' ') {
						spottedWhitespace = true;
						timer = 0;
						}

					if(currentlyUsedDialogue.dialogue[dialogueBoxIndex].currDialogueBox[charIndex] != '/')
					uiDialogue.text += currentlyUsedDialogue.dialogue[dialogueBoxIndex].currDialogueBox[charIndex];
					else 
					uiDialogue.text += "\n";

					if(charIndex < currentlyUsedDialogue.dialogue[dialogueBoxIndex].currDialogueBox.Length - 1) {
						charIndex++;
						LoadInNewChar();
					} else {
						canGoNextPage = true;
						SetUI(true);
					}
				}
			}
		}
	}

	void RefreshDialogueTimer() {
		if(canTalk == false && currentlyUsedDialogue == null) {
			if(sessionTimer < timeBetweenSessions) {
			sessionTimer += Time.deltaTime;
			} else {
				canTalk = true;
				sessionTimer = 0;
			}
		}
	}
}
