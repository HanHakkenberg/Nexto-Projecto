using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehaviour : MonoBehaviour
{

    public GameObject egg;

    private bool canHideEgg;
    public float jumpTimer;
    private Animator anim;

    private void Awake()
    {
        jumpTimer = Random.Range(5f, 15f);
        anim = GetComponent<Animator>();
        egg.SetActive(false);
    }

    private void Update()
    {
        jumpTimer -=Time.deltaTime;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Anim_Jump"))
            egg.SetActive(true);
        else
            egg.SetActive(false);

        if (jumpTimer <= 0)
        {
            jumpTimer = Random.Range(5f, 15f);
            anim.SetTrigger("Jumping");
        }

    }
}
