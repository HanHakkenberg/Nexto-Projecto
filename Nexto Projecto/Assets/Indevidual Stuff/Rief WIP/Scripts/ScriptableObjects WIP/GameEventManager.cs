using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventManager : MonoBehaviour {

	public UIEvent theEvent;
	public UnityEvent myEvents;

	void Start () {

	}
	
	void Update () {
		if(Input.GetButton("Cancel") && myEvents != null)
		{
			myEvents.Invoke();
		}
	}
	void Ping()
	{
		Debug.Log("Ping");
	}
}
