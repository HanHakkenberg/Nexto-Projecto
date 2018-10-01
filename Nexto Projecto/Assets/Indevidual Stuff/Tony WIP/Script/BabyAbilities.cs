using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyAbilities : MonoBehaviour
{
    private WaitForSeconds doubleClickTreshHold = new WaitForSeconds(0.3f);
    private float dashReset = 0.4f;
    private Rigidbody rigidbody;
    public ParticleSystem fartUp;
    public ParticleSystem fartForward;

    Animator animator;
    float timer = 0;

    private void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        fartUp.Stop();
        fartForward.Stop();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ResetTimer();

        if(GameManager.gameManager.gameTimeout == false) {
        Dash();

     }
 }

    public void Jump(float _Power)
    {
<<<<<<< HEAD:Nexto Projecto/Assets/Indevidual Stuff/Tony WIP/Script/BabyMovement.cs
        rigidbody.velocity = Vector3.zero;
		rigidbody.AddForce(new Vector3(0, _Power, 0), ForceMode.Impulse);
        fartUp.Play();
=======
        var up = GameManager.gameManager.player.transform.TransformDirection(Vector3.up * 5);

            fartUp.Play();
            rigidbody.velocity += new Vector3(0, up.y * 1f, 0);
>>>>>>> 48c25ad50849cda52fc971073deb8895cfde8722:Nexto Projecto/Assets/Indevidual Stuff/Tony WIP/Script/BabyAbilities.cs
    } 

    void Dash()
    {
        if(Input.GetButtonDown("Fire3")) {
            animator.SetTrigger("Dash");
            timer = 0;
        }
    }

    void ResetTimer() {
        timer += Time.deltaTime;
        if(timer > dashReset) {
            timer = 0;
            animator.ResetTrigger("Dash");
        }
    }

    void Fart() {
        fartForward.Play();
    }
}
