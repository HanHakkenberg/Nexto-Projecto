using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysInteract : MonoBehaviour {


	bool canInteract = false;
	public GameObject simonSays;
	void Start () {
		
	}
	
	void Update () {
		Interact();
	}

	public void OnTriggerEnter(Collider _P)
	{
		if(_P.tag == "Player")
		{
			canInteract = true;
		}
	}
	public void OnTriggerExit(Collider _P)
	{
		if(_P.tag == "Player")
		{
			canInteract = false;
		}
	}

	void Interact()
	{
		if(canInteract && Input.GetButtonDown("Interact"))
		{
			simonSays.GetComponent<SimonSays>().Check(gameObject.name);
		}
	}
}
