using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	[Header("Ability Unlock Settings:")]
	public bool shouldUnlockAbility;
	public int unlockIndex = 0;

	bool hasBeenPickedUp = false;

	void OnTriggerEnter(Collider _C) {
		if(_C.transform.tag == "Player") {
			if(hasBeenPickedUp == false) {
			hasBeenPickedUp = true;
			if(shouldUnlockAbility == true) {
				CutsceneManager.cutsceneManager.LoadCutscene(unlockIndex);
			} else {
			StartCoroutine(GameManager.gameManager.AddDiaper());
			}
			StartCoroutine(DestroySelf());
			}
		}
	}

	IEnumerator DestroySelf() {
		GetComponent<Animator>().SetTrigger("Pickup");
		yield return new WaitForSeconds(1.5f);
		Destroy(transform.parent.gameObject);
	}	
}
