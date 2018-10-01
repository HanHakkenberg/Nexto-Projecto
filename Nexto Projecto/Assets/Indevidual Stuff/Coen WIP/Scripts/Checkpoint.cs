using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	
	void OnTriggerEnter(Collider _Col) {
		if(_Col.transform.tag == "Player") {
			if(CheckpointManager.checkpointManager.checkpoint != this) {
				StartCoroutine(CheckpointManager.checkpointManager.LoadNewCheckpoint(this));
			}
		}
	}
}
