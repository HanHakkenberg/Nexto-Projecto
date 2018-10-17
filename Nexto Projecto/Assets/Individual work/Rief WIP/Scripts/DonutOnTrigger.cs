using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutOnTrigger : MonoBehaviour {

    public GameObject puzzleInfo;
    public int timeAdd;


    public void OnTriggerEnter(Collider hit)
	{
        if (hit.tag == "Companion")
        {
            puzzleInfo.GetComponent<DonutPuzzle>().time += timeAdd;
        }
        if(hit.tag == "Finish")
        {
            puzzleInfo.GetComponent<DonutPuzzle>().finished = true;
        }
    }
}
