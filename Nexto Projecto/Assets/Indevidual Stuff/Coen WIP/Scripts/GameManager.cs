using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager gameManager;

	public Transform player;

	[Header("Death:")]
	public Animator deathScreen;
	public Animator deathscreenTwo;
	public Animator collectables;
	public Text collectableText;
	public float timeTillUpdateCollectableUI = 1;
	public float loadTime;
	public Transform respawnPoint;

	[Header("Game Statistics:")]
	public int diapers;
	public bool gameTimeout = false;

	void Awake() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;

		if(gameManager != null)
		return;
		else
		gameManager = this;
	}

	public IEnumerator AddDiaper() {
		collectables.SetTrigger("In");
		collectables.SetTrigger("Out");
		yield return new WaitForSeconds(timeTillUpdateCollectableUI);
		diapers++;
		collectableText.text = diapers.ToString();
	}

	public void OnDeath() {
		StartCoroutine(DeathLoading());
	}

	public IEnumerator DeathLoading() {
		deathScreen.SetTrigger("Load");
		deathscreenTwo.SetTrigger("Load");
		gameTimeout = true;
		yield return new WaitForSeconds(loadTime);
		gameTimeout = false;
		player.transform.position = respawnPoint.position;
		deathScreen.SetTrigger("Unload");
		deathscreenTwo.SetTrigger("Unload");
	}
}
