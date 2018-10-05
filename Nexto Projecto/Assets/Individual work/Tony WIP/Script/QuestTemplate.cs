using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTemplate : MonoBehaviour {

    public Dialogue startDialogue;
    public Dialogue activeDialogue;
    public Dialogue completedDialogue;
    public Sprite collectableIcon;
    public int rewardAmount;
    public bool completed;

    public bool started = false;

	public virtual void UpdateQuestStatus() {
        if (QuestManager.questManager.currentActiveQuest != null)
        {
            if (QuestManager.questManager.currentActiveQuest != this)
            {
                DialogueManager.dialogueManager.LoadInNewDialogue(QuestManager.questManager.alreadyHasQuestDialogue);
                return;
            }
        }

        if(!started)
        {
            started = true;
            QuestManager.questManager.inactive.Remove(this);
            QuestManager.questManager.currentActiveQuest = this;
            CutsceneManager.cutsceneManager.SetupDialogue(transform);
            DialogueManager.dialogueManager.LoadInNewDialogue(startDialogue);
            return;
        }

        DialogueManager.dialogueManager.LoadInNewDialogue(activeDialogue);
        
	}

    public void GiveReward()
    {
        CutsceneManager.cutsceneManager.SetupDialogue(transform);
        DialogueManager.dialogueManager.LoadInNewDialogue(completedDialogue);
        completed = true;
        QuestManager.questManager.finished.Add(this);
        StartCoroutine(GameManager.gameManager.AddDiaper(rewardAmount));
        QuestManager.questManager.currentActiveQuest = null;
    }
}
