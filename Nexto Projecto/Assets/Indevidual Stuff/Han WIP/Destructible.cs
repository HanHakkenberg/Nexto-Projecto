using UnityEngine;

public class Destructible : MonoBehaviour {
    [SerializeField] string destructionTag;
    [SerializeField] string getFromPool;
    [SerializeField] string addToPool;

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Projectile")) {
            Debug.Log("kS");

            ObjectPooler.instance.GetFromPool(getFromPool,transform.position,transform.rotation);
            ObjectPooler.instance.AddToPool(addToPool,gameObject);
        }
    }
}
