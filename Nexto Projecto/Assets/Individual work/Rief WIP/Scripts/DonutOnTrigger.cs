using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutOnTrigger : MonoBehaviour {

    public GameObject puzzleInfo;
    public GameObject chocolate;
    bool hit = false;


    public void OnTriggerEnter(Collider _C)
	{
        if(!hit && _C.tag == "Companion")
        {
            hit = true;
            puzzleInfo.GetComponent<DonutPuzzle>().hit+=1;
            Destroy(chocolate);
        }
            
    }
}
