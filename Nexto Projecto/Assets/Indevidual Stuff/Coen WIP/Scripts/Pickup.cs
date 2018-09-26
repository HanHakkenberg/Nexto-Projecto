﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	bool hasBeenPickedUp = false;

	void OnTriggerEnter(Collider _C) {
		if(_C.transform.tag == "Player") {
			if(hasBeenPickedUp == false) {
			hasBeenPickedUp = true;
			StartCoroutine(GameManager.gameManager.AddDiaper());
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
