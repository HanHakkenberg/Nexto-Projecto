using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningWheal : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] int minRot, maxRot;

    void Update() {
        if(Input.GetButton("Fire1") && transform.rotation.y >= minRot) {
            transform.Rotate(new Vector3(0,speed * Time.deltaTime));
        }
        else if(Input.GetButton("Fire2") && transform.rotation.y <= maxRot) {
            transform.Rotate(new Vector3(0,-speed * Time.deltaTime));
        }
    }
}
