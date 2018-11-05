using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPickup : MonoBehaviour
{

    private bool beingCarried;

    public void OnCollisionStay(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            DialogueManager.dialogueManager.tooltip.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E) && !beingCarried)
            {
                GameManager.gameManager.player.GetComponent<Animator>().SetBool("CarryingSeed", true);
                beingCarried = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && beingCarried)
            {
                GameManager.gameManager.player.GetComponent<Animator>().SetBool("CarryingSeed", false);

            }
        }
    }
}
