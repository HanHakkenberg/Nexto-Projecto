using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour {

    public GameObject pauseScreen;

    void Start () {
		
	}
	

	void Update () 
	{
        ToPause();
    }

	public void Starting()
	{
       // GetComponent<OptionManager>().inGame = true;
    }
	void ToPause()
	{
		if(Input.GetButtonDown("Cancel") && OptionManager.inGame)
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
