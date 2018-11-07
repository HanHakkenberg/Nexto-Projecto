using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour {
    [SerializeField] GameEvent myEvent;
    [SerializeField] UnityEvent unityEvents;

    public void RaiseEvent() {
        if(myEvent != null) {
            myEvent.Raise();
        }
        unityEvents.Invoke();
    }
}