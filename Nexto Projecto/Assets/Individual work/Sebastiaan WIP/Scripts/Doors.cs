using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

    public Animator farmHouseDoors;
    public Collider leftDoor;
    public Collider rightDoor;

    void Update()
    {
        if (transform.GetComponent<QuestCollectable>().started)
        {
            farmHouseDoors.SetTrigger("Open");
            leftDoor.enabled = false;
            rightDoor.enabled = false;
        }
    }
}
