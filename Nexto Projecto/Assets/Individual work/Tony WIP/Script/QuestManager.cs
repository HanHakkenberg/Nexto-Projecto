using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public List<QuestTemplate> inactive = new List<QuestTemplate>();
	public List<QuestTemplate> finished = new List<QuestTemplate>();

    public QuestTemplate currentActiveQuest;
    public Dialogue alreadyHasQuestDialogue;

	public static QuestManager questManager;

	private void Awake() {
		if(questManager == null)
		questManager = this;
		else
		Destroy(this);
	}
}
