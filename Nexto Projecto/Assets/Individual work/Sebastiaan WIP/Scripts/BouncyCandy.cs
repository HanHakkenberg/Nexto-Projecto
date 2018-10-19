using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCandy : MonoBehaviour {

    private AnimationEvent evt;
    private Animator candyAnim;

    private GameObject player;
    private Vector3 velocity;

    private void Awake()
    {
        candyAnim = transform.GetComponentInParent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            candyAnim.SetBool("Jump_Anim", true);
            velocity = player.transform.GetComponent<Rigidbody>().velocity;
        }
    }

    public void StopAnim()
    {
            candyAnim.SetBool("Jump_Anim", false);
    }
    public void AddBounceForce()
    {
        player.transform.GetComponent<Rigidbody>().AddForce(Vector3.up*8, ForceMode.Impulse);
    }
}
