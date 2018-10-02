using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour {
    [SerializeField] UnityEvent myUnityEvent;
    [SerializeField] float Delay;

    public void StartDelay(){
        StartCoroutine(Timer());
    }

    public void StopDelay() {
        StopCoroutine(Timer());
    }

    IEnumerator Timer() {
        StopCoroutine(Timer());
        yield return new WaitForSeconds(Delay);
        myUnityEvent.Invoke();
    }
}
