using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public List<Quest> inactive = new List<Quest>();
	public List<Quest> active = new List<Quest>();
	public List<Quest> finished = new List<Quest>();

	public static QuestManager questManager;

	private void Awake() {
		if(questManager == null)
		questManager = this;
		else
		Destroy(this);
	}

	public void QuestHandler() {

	}
}
