using UnityEngine;
using UnityEngine.Events;

public class TurningWheal : MonoBehaviour {
    [SerializeField] FloatReference progression;
    float currentProgression;
    [SerializeField] int maxRot;
    [SerializeField] float speed;
    [SerializeField] UnityEvent myUnityEvent;
    [SerializeField] AudioSource myAudio;

    float newSpeed;

    void Update() {
        newSpeed = speed * Time.deltaTime;

        if(Input.GetButton("Fire1") && currentProgression + newSpeed < maxRot) {
            transform.localEulerAngles += new Vector3(0, newSpeed);
            currentProgression += newSpeed;
            UpdateProgression();
            myAudio.Play();
        }
        else if(Input.GetButton("Fire2") && currentProgression - newSpeed > 0) {
            transform.localEulerAngles -= new Vector3(0, newSpeed);
            currentProgression -= newSpeed;
            UpdateProgression();
            myAudio.Play();
        }
        else {
            myAudio.Pause();
        }
    }

    void UpdateProgression() {
        progression.Value = currentProgression / maxRot;
        myUnityEvent.Invoke();
    }
}
