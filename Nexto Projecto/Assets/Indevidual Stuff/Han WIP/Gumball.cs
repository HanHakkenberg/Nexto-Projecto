using UnityEngine;

public class Gumball : MonoBehaviour {
    [SerializeField] float gumballSpeed;

    void Update() {
        transform.Translate(transform.right * Time.deltaTime * gumballSpeed);
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("GumballInteraction")) {
            transform.localEulerAngles = collision.contacts[0].normal * 90;
            Debug.Log(transform.localEulerAngles);
        }
    }

    public void AddToPool() {
        ObjectPooler.instance.AddToPool("Gumball", gameObject);
    }
}
