using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPickup : MonoBehaviour
{

    public bool beingCarried;
    private bool planted;
    private bool canPlant;
    private bool canPick;
    private GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            DialogueManager.dialogueManager.tooltip.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            if (canPick && !beingCarried)
            {
                beingCarried = true;
                transform.SetParent(player.transform);
                canPick = false;
                DialogueManager.dialogueManager.tooltip.SetActive(false);
                // GameManager.gameManager.player.GetComponent<Animator>().SetBool("PickSeed",true);
            }
            else if (beingCarried)
            {
                beingCarried = false;
                transform.SetParent(null);
                // GameManager.gameManager.player.GetComponent<Animator>().SetBool("DropSeed",true);
            }
        if (player != null && !beingCarried)
            canPick = true;
        else
            canPick = false;

        if (Input.GetKeyDown(KeyCode.E) && beingCarried && canPlant)
        {
            beingCarried = false;
            planted = true;
            transform.SetParent(null);
            // GameManager.gameManager.player.GetComponent<Animator>().SetBool("PlantSeed",true);
            //todo play cutscene and make tree grow.
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.transform.tag == "Player")
            player = col.gameObject;

        if (col.transform.tag == "PlantLocation")
            canPlant = true;
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            DialogueManager.dialogueManager.tooltip.SetActive(false);
            player = null;
        }
        if (col.transform.tag == "PlantLocation")
            canPlant = false;
    }
}
