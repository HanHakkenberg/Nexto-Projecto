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
    }

    private void OnTriggerStay(Collider _C)
    {
        if (_C.transform.tag == "PlayerTriggerField")
            if (Input.GetKeyDown(KeyCode.E) &&egg !=null)
            {
                transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 150f);
                anim.SetBool("Falling", true);
                egg.SetActive(true);
            }
    }

    private void OnTriggerEnter(Collider _C)
    {
        if (canHideEgg &&egg !=null)
        {
            egg.SetActive(false);
            anim.SetBool("Falling", false);
            canHideEgg = false;
        }

    }


    private void OnTriggerExit(Collider _C)
    {
        canHideEgg = true;
    }
}
