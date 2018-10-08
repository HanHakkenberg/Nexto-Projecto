using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuestTemplate : MonoBehaviour
{

    public Dialogue startDialogue;
    public Dialogue activeDialogue;
    public Dialogue completedDialogue;
    public Image questStatusDisplay;
    public int rewardAmount;
    public bool completed;
    public bool finished;
    public bool started = false;

    //add self and child to list
    protected virtual void Start()
    {
        QuestManager.questManager.inactive.Add(this);
    }

    public virtual IEnumerator StartQuestTimer()
    {
        CutsceneManager.cutsceneManager.SetupDialogue(transform);
        DialogueManager.dialogueManager.LoadInNewDialogue(startDialogue);

        for (int i = 0; i < Mathf.Infinity; i++)
        {
            yield return new WaitForSeconds(1);
            if (GameManager.gameManager.gameTimeout == false)
                break;
        }

        QuestManager.questManager.inactive.Remove(this);
        QuestManager.questManager.currentActiveQuest = this;
    }

    public virtual void UpdateQuestStatus()
    {
        if (finished)
        {
            GiveReward();
            return;
        }


        if (QuestManager.questManager.currentActiveQuest != null)
        {
            if (QuestManager.questManager.currentActiveQuest != this)
            {
                DialogueManager.dialogueManager.LoadInNewDialogue(QuestManager.questManager.alreadyHasQuestDialogue);
                return;
            }
        }

        if (!started)
        {
            StartQuest();
            return;
        }

        DialogueManager.dialogueManager.LoadInNewDialogue(activeDialogue);

    }

    public virtual void StartQuest()
    {
        started = true;
        StartCoroutine(StartQuestTimer());
        return;
    }

    public virtual IEnumerator GiveReward()
    {
        CutsceneManager.cutsceneManager.SetupDialogue(transform);
        DialogueManager.dialogueManager.LoadInNewDialogue(completedDialogue);
        questStatusDisplay.enabled = false;
        completed = true;

        for (int i = 0; i < Mathf.Infinity; i++)
            if (GameManager.gameManager.gameTimeout)
                yield return new WaitForSeconds(1);
            else
                break;

        QuestManager.questManager.finished.Add(this);
        GameManager.gameManager.AddDiaper(rewardAmount);
        QuestManager.questManager.currentActiveQuest = null;
    }
}
