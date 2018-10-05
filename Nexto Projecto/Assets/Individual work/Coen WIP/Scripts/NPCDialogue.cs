using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{

    [Header("Dialogue Info;")]
    public Dialogue dialogue;

    [Header("Quest Info:")]
    public QuestTemplate quest;

    public bool canLoadUpDialogue = false;

    void Update()
    {
        LoadDialogue();
    }

    void OnTriggerEnter(Collider _C)
    {
        if (_C.transform.tag == "Player")
        {
            canLoadUpDialogue = true;
            DialogueManager.dialogueManager.tooltip.SetActive(true);
        }
    }

    void OnTriggerExit(Collider _C)
    {
        if (_C.transform.tag == "Player")
        {
            canLoadUpDialogue = false;
            DialogueManager.dialogueManager.tooltip.SetActive(false);
        }
    }

    public void LoadDialogue()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canLoadUpDialogue)
            {
                if (!GameManager.gameManager.gameTimeout)
                {
                    if (quest != null)
                    {
                        if (!quest.completed)
                        {
                            quest.UpdateQuestStatus();
                            return;
                        }
                    }
                }

                CutsceneManager.cutsceneManager.SetupDialogue(transform);
                DialogueManager.dialogueManager.LoadInNewDialogue(dialogue);
                }
            }
        }
    }

