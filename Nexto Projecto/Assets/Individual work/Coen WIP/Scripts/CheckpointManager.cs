using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

	public static CheckpointManager checkpointManager;

	[Header("Settings:")]
	public float timeTillSave = 2;
	public Checkpoint checkpoint;
	public Animator checkpointUI;
	
	void Awake() {
		if(checkpointManager != null)
		Destroy(this);
		else
		checkpointManager = this;
	}

	public IEnumerator LoadNewCheckpoint(Checkpoint _NewCheckpoint) {
		checkpoint = _NewCheckpoint;
		checkpointUI.SetBool("Load", true);
		yield return new WaitForSeconds(timeTillSave);
		checkpointUI.SetBool("Load", false);
	}
}
