using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour {

    private Rigidbody rigidbody;
    public bool hasFullyInstantiated = false;
    public float timeTillControl = 2;

    private void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        StartCoroutine(StartControls());
    }

    IEnumerator StartControls() {
        yield return new WaitForSeconds(timeTillControl);
        ActivateColliders();
    }

    void ActivateColliders() {
        Collider[] colliders = GetComponents<Collider>();
        foreach(Collider _Col in colliders) {
            if(_Col.isTrigger == false) {
                _Col.enabled = true;
            }
        }

        GetComponent<Animator>().enabled = false;
        hasFullyInstantiated = true;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {   
        if(GameManager.gameManager.gameTimeout == true) {
            rigidbody.velocity = Vector3.zero;
            return;
        }

        if(hasFullyInstantiated == true) {
        var forward = Camera.main.transform.TransformDirection(Vector3.forward*5);
        var right = Camera.main.transform.TransformDirection(Vector3.right*5);
        var up = Camera.main.transform.TransformDirection(Vector3.up * 5);
            rigidbody.AddForce(forward* Input.GetAxis("Vertical"), ForceMode.Force);
            rigidbody.AddForce(right*Input.GetAxis("Horizontal"), ForceMode.Force);

         if (Input.GetButton("Shift"))
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, -up, 2f * Time.deltaTime);
         if (Input.GetButton("Space"))
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, up, 2f * Time.deltaTime);
          
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, 5f * Time.deltaTime);
        }
    }
}
