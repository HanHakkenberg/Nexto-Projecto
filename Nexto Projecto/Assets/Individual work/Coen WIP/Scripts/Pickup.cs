using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    [Header("Ability Unlock Settings:")]
    public bool shouldUnlockAbility;
    public bool isQuestCollectable;
    public int unlockIndex = 0;

    bool hasBeenPickedUp = false;

    void OnTriggerEnter(Collider _C)
    {
        if (_C.transform.tag == "Player")
        {
            if (hasBeenPickedUp == false)
            {
                hasBeenPickedUp = true;
                if (shouldUnlockAbility == true)
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
    }

    IEnumerator DestroySelf()
    {
        GetComponent<Animator>().SetTrigger("Pickup");
        yield return new WaitForSeconds(1.5f);
        Destroy(transform.parent.gameObject);
    }
}
