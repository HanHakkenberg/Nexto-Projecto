using UnityEngine;
using UnityEngine.Events;

public class InputDownEvent : MonoBehaviour {
	[SerializeField] GameEvent myEvent;
    [SerializeField] UnityEvent myUnityEvent;
    [SerializeField] string myInput;
    [SerializeField] bool canUse;

	void Update() {
		if (Input.GetButtonDown(myInput) && canUse == OptionManager.started) {
            if(myEvent != null) {
                myEvent.Raise();
            }
            myUnityEvent.Invoke();
        }
	}
}
