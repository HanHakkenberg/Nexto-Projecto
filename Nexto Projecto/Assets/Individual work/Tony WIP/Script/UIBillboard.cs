using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour {

    public static Transform cam;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    public void Update()
    {
        transform.LookAt(cam);
    }
}
