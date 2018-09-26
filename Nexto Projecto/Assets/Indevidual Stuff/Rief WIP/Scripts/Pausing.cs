using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour {

    public bool inGame = false;
    public GameObject pauseScreen;

    void Start () {
		
	}
	

	void Update () 
	{
        ToPause();
    }

	public void Starting()
	{
        inGame = true;
    }
	void ToPause()
	{
		if(Input.GetButtonDown("Cancel") && inGame)
		{
			if(pauseScreen.activeInHierarchy == true)
			{
                pauseScreen.SetActive(false);
            }
			else
			{
                pauseScreen.SetActive(true);
            }
        }
	}
}
