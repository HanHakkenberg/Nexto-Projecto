using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{

    public static float overallSensitivity = 10;

    [Header("Dialogue Info;")]
    public Dialogue dialogue;

    [Header("Quest Info:")]
    public QuestTemplate quest;

    [Header("Behaviour Settings:")]
    public bool overrideRotation = true;

    public bool canLoadUpDialogue = false;

    Vector3 startRot;

    void Update()
    {
        StartCoroutine(LoadDialogue());
        Rotate();
    }

    void Rotate()
    {
        if (GameManager.gameManager.gameTimeout == true)
            if (DialogueManager.dialogueManager.target != null)
            {
                if (DialogueManager.dialogueManager.target == gameObject.transform)
                {
                    if(overrideRotation == true)
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameManager.gameManager.player.transform.position - transform.position), overallSensitivity * Time.deltaTime);
                    return;
                }
            }

            if(!GetComponent<RootmotionAI>() && overrideRotation == false)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(startRot), overallSensitivity * Time.deltaTime);
    }

    void Awake()
    {
        startRot = transform.eulerAngles;
    }

    void OnTriggerEnter(Collider _C)
    {
        if (_C.transform.tag == "Player")
        {
            if(DialogueManager.dialogueManager.canTalk == true && GameManager.gameManager.gameTimeout == false)
            DialogueManager.dialogueManager.tooltip.SetActive(true);

            canLoadUpDialogue = true;
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

    public IEnumerator LoadDialogue()
    {
        if (!GameManager.gameManager.gameTimeout)
        {
            if (canLoadUpDialogue)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    yield return new WaitForEndOfFrame();
                    if (quest != null)
                    {
                        if (!quest.completed)
                        {
                            if(DialogueManager.dialogueManager.canTalk == true)
                            quest.UpdateQuestStatus();
                            yield break;
                        }
                    }

                    if(DialogueManager.dialogueManager.canTalk == true)
                        DialogueManager.dialogueManager.LoadInNewDialogue(dialogue, transform);
                }
            }
        }
    }
}

