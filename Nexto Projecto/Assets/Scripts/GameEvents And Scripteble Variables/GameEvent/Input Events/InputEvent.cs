using UnityEngine;
using UnityEngine.Events;

public class InputEvent : MonoBehaviour {
    [SerializeField] GameEvent myEvent;
    [SerializeField] UnityEvent myUnityEvent;
    [SerializeField] string myInput;

    void Update() {
        if(Input.GetButton(myInput)) {
            if(myEvent != null) {
                myEvent.Raise();
            }
            myUnityEvent.Invoke();
        }
    }
}