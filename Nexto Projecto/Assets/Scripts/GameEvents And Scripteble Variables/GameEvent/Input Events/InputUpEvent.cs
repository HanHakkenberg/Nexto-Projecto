using UnityEngine;
using UnityEngine.Events;

public class InputUpEvent : MonoBehaviour {
	[SerializeField] GameEvent myEvent;
    [SerializeField] UnityEvent myUnityEvent;
    [SerializeField] string myInput;

	void Update() {
		if (Input.GetButtonUp(myInput)) {
            if(myEvent != null) {
                myEvent.Raise();
            }
            myUnityEvent.Invoke();
		}
	}
}