using UnityEngine;
using UnityEngine.Events;

public class InputDownEvent : MonoBehaviour {
	[SerializeField] GameEvent myEvent;
    [SerializeField] UnityEvent myUnityEvent;
    [SerializeField] string myInput;

	void Update() {
		if (Input.GetButtonDown(myInput)) {
            if(myEvent != null) {
                myEvent.Raise();
            }
            myUnityEvent.Invoke();
        }
	}
}
