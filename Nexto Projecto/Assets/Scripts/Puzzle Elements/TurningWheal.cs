using UnityEngine;
using UnityEngine.Events;

public class TurningWheal : MonoBehaviour {
    [SerializeField] FloatReference progression;
    float currentProgression;
    [SerializeField] int maxRot;
    [SerializeField] float speed;
    [SerializeField] UnityEvent myUnityEvent;

    float newSpeed;

    void Update() {
        newSpeed = speed * Time.deltaTime;

        if(Input.GetButton("Fire1") && currentProgression + newSpeed < maxRot) {
            transform.localEulerAngles += new Vector3(0, newSpeed);
            currentProgression += newSpeed;
            UpdateProgression();
        }
        else if(Input.GetButton("Fire2") && currentProgression - newSpeed > 0) {
            transform.localEulerAngles -= new Vector3(0, newSpeed);
            currentProgression -= newSpeed;
            UpdateProgression();
        }
    }

    void UpdateProgression() {
        progression.Value = currentProgression / maxRot;
        myUnityEvent.Invoke();
    }
}
