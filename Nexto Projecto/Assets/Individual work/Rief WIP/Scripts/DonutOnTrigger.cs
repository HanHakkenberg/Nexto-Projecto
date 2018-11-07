using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutOnTrigger : MonoBehaviour {

    public GameObject puzzleInfo;
    bool hit = false;


    public void OnTriggerEnter()
	{
        if(!hit)
        {
            puzzleInfo.GetComponent<DonutPuzzle>().hit+=1;
            hit = true;
        }
            
    }
}
