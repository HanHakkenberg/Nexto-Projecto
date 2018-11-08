using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundTransition : MonoBehaviour {

    public Color skyboxColor;
    public Material skyboxMat;

    public void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player");
        print("E");
    }
}

