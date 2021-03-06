﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour
{

    private Rigidbody rigidbody;
    public bool hasFullyInstantiated = false;
    public float movementSpeed = 3f;
    public float timeTillControl = 2;
    public float flyspeed = 1f;

    private Vector2 inputs { get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); } }
    public Animator companionAnim;
    public Animator companionSpawnAnim;

    [SerializeField] float companionMoveSpeedHor = 5f;
    [SerializeField] float companionMoveSpeedVer = 5f;

    private void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        StartCoroutine(StartControls());
    }

    IEnumerator StartControls()
    {
        yield return new WaitForSeconds(timeTillControl);
        ActivateColliders();
    }

    void ActivateColliders()
    {
        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider _Col in colliders)
        {
            if (_Col.isTrigger == false)
            {
                _Col.enabled = true;
            }
        }

        companionSpawnAnim.enabled = false;
        hasFullyInstantiated = true;
    }

    private void Update()
    {
        if(companionSpawnAnim.enabled == false)
        Move();

    }

    void Move()
    {
        if (GameManager.gameManager.gameTimeout == true)
        {
            rigidbody.velocity = Vector3.zero;
            return;
        }


        if (hasFullyInstantiated == true)
        {
            var forward = Camera.main.transform.TransformDirection(Vector3.forward * movementSpeed);
            var right = Camera.main.transform.TransformDirection(Vector3.right * movementSpeed);
            var up = Camera.main.transform.TransformDirection(Vector3.up * movementSpeed);




            if (inputs != Vector2.zero || Input.GetButton("Shift") || Input.GetButton("Space"))
            {
                rigidbody.AddForce(companionMoveSpeedHor * forward * inputs.y, ForceMode.Force);
                rigidbody.AddForce(companionMoveSpeedHor * right * inputs.x, ForceMode.Force);
                Mathf.Lerp(flyspeed, 2f,  Time.deltaTime);
                transform.forward = -forward;
            }
                else                
                    Mathf.Lerp(flyspeed, 1f, 1.5f*Time.deltaTime);                

                if (Input.GetButton("Shift"))
                {
                    rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, -up, companionMoveSpeedVer * Time.deltaTime);
                    Mathf.Lerp(flyspeed, 2f, Time.deltaTime);
                }
                if (Input.GetButton("Space"))
                {
                    rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, up, companionMoveSpeedVer * Time.deltaTime);
                    Mathf.Lerp(flyspeed, 2f, Time.deltaTime);
                }
                
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, 5f * Time.deltaTime);                      
        }

        companionAnim.SetFloat("Speed", flyspeed);
        print(flyspeed);
    }
}
