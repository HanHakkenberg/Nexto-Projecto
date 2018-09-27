using UnityEngine;
using UnityEngine.Events;

public class Gumball : MonoBehaviour {
    [SerializeField] float gumballSpeed;
    [SerializeField] float lifeSpenInSec;
    [SerializeField] UnityEvent onDestroy;
    float currentLifeSpen;


    void OnEnable() {
        currentLifeSpen = lifeSpenInSec;
    }

    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * gumballSpeed);

        currentLifeSpen -= Time.deltaTime;
        if(currentLifeSpen <= 0) {
            onDestroy.Invoke();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("GumballInteraction")) {
            Vector3 v = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            float newYRot = 90 - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, newYRot, 0);
        }
        else {
            onDestroy.Invoke();
        }
    }

    public void AddToPool() {
        ObjectPooler.instance.AddToPool("Gumball", gameObject);
    }
}
