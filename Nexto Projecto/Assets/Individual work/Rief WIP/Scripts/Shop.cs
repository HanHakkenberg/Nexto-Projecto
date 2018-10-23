using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    bool canInteract;
    int loadTime = 3;
	//public List<>

    void Start () {
		
	}
	
	void Update () {
		ShoptInteract();
    }
	void OnTriggerEnter(Collider _C)
	{
		if(_C.transform.tag == "Player")
		{
            canInteract = true;
        }
	}
	void OnTriggerExit(Collider _C)
	{
		if(_C.transform.tag == "Player")
		{
            canInteract = false;
        }
	}

	void ShoptInteract()
	{
		if(Input.GetButtonDown("Interact") && canInteract == true)
		{
            StartCoroutine(DoLoad());
        }
	}
	IEnumerator DoLoad()
	{
        canInteract = false;
        GameManager.gameManager.deathScreen.SetTrigger("Load");
		GameManager.gameManager.deathscreenTwo.SetTrigger("Load");
		yield return new WaitForSeconds(loadTime);
		GameManager.gameManager.deathScreen.SetTrigger("Unload");
		GameManager.gameManager.deathscreenTwo.SetTrigger("Unload");
    }
}
