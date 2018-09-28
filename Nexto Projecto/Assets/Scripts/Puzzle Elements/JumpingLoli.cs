using UnityEngine;

public class JumpingLoli : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
    }
}
