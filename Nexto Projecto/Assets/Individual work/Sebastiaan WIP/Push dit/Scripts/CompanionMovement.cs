using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour {

    private Rigidbody rigidbody;
    public bool hasFullyInstantiated = false;
    public float timeTillControl = 2;
    [SerializeField] float companionMoveSpeedHor = 10f;
    [SerializeField] float companionMoveSpeedVer = 10f;

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
        var forward = Camera.main.transform.TransformDirection(Vector3.forward* 5f);
        var right = Camera.main.transform.TransformDirection(Vector3.right* 5f);
        var up = Camera.main.transform.TransformDirection(Vector3.up * 5f);
            rigidbody.AddForce(companionMoveSpeedHor * forward * Input.GetAxis("Vertical"), ForceMode.Force);
            rigidbody.AddForce(companionMoveSpeedHor * right * Input.GetAxis("Horizontal"), ForceMode.Force);

         if (Input.GetButton("Shift"))
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, -up, companionMoveSpeedVer * Time.deltaTime);
         if (Input.GetButton("Space"))
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, up, companionMoveSpeedVer * Time.deltaTime);
          
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, 5f * Time.deltaTime);
        }
    }
}
