using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

	void OnTriggerEnter(Collider _C) {
		if(_C.transform.tag == "Player") {
			GameManager.gameManager.OnDeath();
		}
	}
}
