using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour {


    void Start () {
		
	}
	
	void Update () {
		
	}

	public void CompanionOpen()
	{
        SwitchManager.switchManager.ToggleController(true);
        GameManager.gameManager.gameTimeout = true;
    }
	public void CompanionClose()
	{

	}
}
