using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehaviour : MonoBehaviour
{

    public GameObject egg;

    private bool canHideEgg;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        egg.SetActive(false);
    }

    private void OnTriggerStay(Collider _C)
    {
        if (_C.transform.tag == "PlayerTriggerField")
            if (Input.GetKeyDown(KeyCode.E) && egg != null)
            {
                anim.SetBool("Jumping", true);
                egg.SetActive(true);
            }
    }

    private void OnTriggerEnter(Collider _C)
    {
        if (canHideEgg && egg != null)
        {
            egg.SetActive(false);
            anim.SetBool("Jumping", false);
            canHideEgg = false;
        }

    }


    private void OnTriggerExit(Collider _C)
    {
        canHideEgg = true;
    }
}
