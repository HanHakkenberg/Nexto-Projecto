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
            StartCoroutine(CandyLight());
        }
	}
	IEnumerator CandyLight()
	{
		GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(2.5f,2.5f,2.5f,2.5f));
		yield return new WaitForSeconds(0.7f);
		GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1,1,1,1));
		yield return new WaitForSeconds(0.5f);
	}
}
