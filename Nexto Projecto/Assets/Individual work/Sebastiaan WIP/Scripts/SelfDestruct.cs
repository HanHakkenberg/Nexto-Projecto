using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    public float selfDestructTimer;
    public bool fadeOut;

    private Color color = new Color(0.5f, 0.5f, 0.5f, 1f);

    void Update()
    {

        selfDestructTimer -= Time.deltaTime;

        if (fadeOut && color.a >0f)
        {
            color.a -= 1 * Time.deltaTime/2;
            transform.GetComponent<Renderer>().material.color = color;
        }

        if (selfDestructTimer < 0)
            Destroy(transform.gameObject);

    }
}
