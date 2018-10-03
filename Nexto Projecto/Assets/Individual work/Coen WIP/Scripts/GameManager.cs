using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager gameManager;

	public Transform player;

	[Header("Currency:")]
	public GameObject statisticsParent;
	public Animator currencyOrb;
	public Text abilityCollectableText;

	[Header("Death:")]
	public Animator deathScreen;
	public Animator deathscreenTwo;
	public Animator collectables;
	public Text collectableText;
	public float timeTillUpdateCollectableUI = 1;
	public float loadTime;

	[Header("Game Statistics:")]
	public int diapers;
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

	public IEnumerator AddDiaper() {
		collectables.SetTrigger("In");
		yield return new WaitForSeconds(timeTillUpdateCollectableUI);
		collectables.SetTrigger("Out");
		diapers++;
		collectableText.text = diapers.ToString();
	}
	
	public IEnumerator AddAbility() {
		currencyOrb.SetTrigger("Get");
		yield return new WaitForSeconds(timeTillUpdateCollectableUI);
		unlockedAbilitys++;
		abilityCollectableText.text = unlockedAbilitys.ToString();
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
