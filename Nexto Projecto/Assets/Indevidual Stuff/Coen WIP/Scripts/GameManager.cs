using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager gameManager;

	[Header("Game Statistics:")]
	public int diapers;
	public bool gameTimeout = false;

	void Awake() {
		if(gameManager != null)
		return;
		else
		gameManager = this;
	}
	

}
