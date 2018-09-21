using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMovement : MonoBehaviour {

    public float speed;

    void Update()
    {
        Cursor.visible = false;

        Move();

    }

    void Move()
    {
        var forward = Camera.main.transform.TransformDirection(Vector3.forward);
        var right = Camera.main.transform.TransformDirection(Vector3.right);

        if (Input.GetButton("W"))
            transform.GetComponent<Rigidbody>().velocity = Vector3.Lerp(transform.GetComponent<Rigidbody>().velocity, forward, 2f * Time.deltaTime);
        else if (Input.GetButton("A"))
            transform.GetComponent<Rigidbody>().velocity = Vector3.Lerp(transform.GetComponent<Rigidbody>().velocity, -right, 2f * Time.deltaTime);
        else if (Input.GetButton("S"))
            transform.GetComponent<Rigidbody>().velocity = Vector3.Lerp(transform.GetComponent<Rigidbody>().velocity, -forward, 2f * Time.deltaTime);
        else if (Input.GetButton("D"))
            transform.GetComponent<Rigidbody>().velocity = Vector3.Lerp(transform.GetComponent<Rigidbody>().velocity, right, 2f * Time.deltaTime);
        else
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.Lerp(transform.GetComponent<Rigidbody>().velocity, Vector3.zero, 5f*Time.deltaTime);
        }
    }
}
