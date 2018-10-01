using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyAbilities : MonoBehaviour
{
    private WaitForSeconds doubleClickTreshHold = new WaitForSeconds(0.3f);
    public float speed;
    private int tapCount;
    private float dashReset = 0.4f;
    private Rigidbody rigidbody;
    public ParticleSystem fartUp;
    public ParticleSystem fartForward;

    private void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        fartUp.Stop();
        fartForward.Stop();
    }

    void Update()
    {
        if(GameManager.gameManager.gameTimeout == false) {
        Dash();
        }

    }

    public void Jump()
    {
        var up = GameManager.gameManager.player.transform.TransformDirection(Vector3.up * 5);

            fartUp.Play();
            rigidbody.velocity += new Vector3(0, up.y * 1f, 0);
    } 

    void Dash()
    {
        var forward = GameManager.gameManager.player.transform.TransformDirection(Vector3.forward * 5);

        dashReset -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            tapCount++;
            dashReset = 0.4f;
        }

        if(tapCount == 2)
        {
            rigidbody.AddForce(forward * 300, ForceMode.Acceleration);
            fartForward.Play();
            tapCount = 0;
        }
        if (dashReset <= 0f)
        {
            tapCount = 0;
            dashReset = 0.4f;
        }
    }
}
