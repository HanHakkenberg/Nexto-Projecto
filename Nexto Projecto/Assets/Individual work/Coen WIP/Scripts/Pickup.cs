using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    [Header("Ability Unlock Settings:")]
    public bool shouldUnlockAbility;
    public bool isQuestCollectable;
    public int unlockIndex = 0;
    public float animDuration = 1.5f;
    public GameObject effect;

    bool hasBeenPickedUp = false;

    void OnTriggerStay(Collider _C)
    {
        print ("Called");

        if (_C.transform.tag == "PlayerTriggerField")
        {
            print("trigger");
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("key pressed");
                DialogueManager.dialogueManager.tooltip.SetActive(false);
                Collect();
            }
        }
        }

    private void OnTriggerEnter(Collider _C)
    {
        if (_C.transform.tag == "PlayerTriggerField")
            DialogueManager.dialogueManager.tooltip.SetActive(true);

    }

    private void OnTriggerExit(Collider _C)
    {
        if (_C.transform.tag == "PlayerTriggerField")
            DialogueManager.dialogueManager.tooltip.SetActive(false);
    }

    public void Collect() {
        if (!hasBeenPickedUp)
        {
            if (effect != null)
                Instantiate(effect, transform.position, transform.rotation);

            hasBeenPickedUp = true;
            if (shouldUnlockAbility)
            {
                CutsceneManager.cutsceneManager.LoadCutscene(unlockIndex);
                StartCoroutine(GameManager.gameManager.AddAbility());
            }
            else
               if (isQuestCollectable)
                GameManager.gameManager.AddQuestCollectable(1);
            else
                GameManager.gameManager.AddDiaper(1);
            StartCoroutine(DestroySelf());
        }
    }

    IEnumerator DestroySelf()
    {
        if(GetComponent<Animator>())
        GetComponent<Animator>().SetTrigger("Pickup");

        yield return new WaitForSeconds(animDuration);
        Destroy(transform.parent.gameObject);
    }
}
