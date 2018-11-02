using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	public static GameManager gameManager;

	public Transform player;

	[Header("Currency:")]
	public GameObject statisticsParent;
	public Animator currencyOrb;

	[Header("Death:")]
	public Animator deathScreen;
	public Animator deathscreenTwo;
	public Animator collectables;
    public Animator questCollectablesAnim;
    public Image questCollectableImage;
	public TextMeshProUGUI collectableText;
    public TextMeshProUGUI questCollectablesText;
	public float timeTillUpdateCollectableUI = 1;
	public float loadTime;

	[Header("Game Statistics:")]
	public int diapers;
    public int questCollectables;
	public int unlockedAbilitys;
	public bool gameTimeout = false;

	bool died = false;

	void Awake() {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;

		if(gameManager != null)
		return;
		else
		gameManager = this;
	}

	public void AddDiaper(int _Add) {
		collectables.SetTrigger("In");
		diapers += _Add;
		collectableText.text = diapers.ToString();
	}

    public void AddQuestCollectable(int _Add) {
        QuestCollectable _ColQuest = (QuestCollectable)QuestManager.questManager.currentActiveQuest;
        questCollectablesAnim.ResetTrigger("In");
        questCollectablesAnim.SetTrigger("In");
        questCollectables += _Add;
        questCollectablesText.text = questCollectables.ToString() + "/" + _ColQuest.collectablesNeeded;

        if (_ColQuest.collectablesNeeded <= questCollectables)
            if (_ColQuest.shouldDoCutscene == true)
                if (_ColQuest.doneCutscene == false) {
                    _ColQuest.doneCutscene = true;
                    CutsceneManager.cutsceneManager.LoadStartCutscene(_ColQuest.cutsceneID);
                }
    }
	
	public IEnumerator AddAbility() {
		yield return new WaitForSeconds(0);
		currencyOrb.SetTrigger("Get");
	}


	public void OnDeath() {
		StartCoroutine(DeathLoading());
	}

	public IEnumerator DeathLoading() {
		if(died == false) {
		died = true;
		deathScreen.SetTrigger("Load");
		deathscreenTwo.SetTrigger("Load");
		gameTimeout = true;
		yield return new WaitForSeconds(loadTime);
		gameTimeout = false;
		player.transform.position = CheckpointManager.checkpointManager.checkpoint.transform.position;
		deathScreen.SetTrigger("Unload");
		deathscreenTwo.SetTrigger("Unload");
		died = false;
		}
	}
}
