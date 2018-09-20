using UnityEngine;

public class Destructible : MonoBehaviour {
    [SerializeField] string destructionTag;
    [SerializeField] string getFromPool;
    [SerializeField] bool doesAddToPool;
    [SerializeField] string addToPool;

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Projectile")) {
            ObjectPooler.instance.GetFromPool(getFromPool, transform.position, transform.rotation);

            if(doesAddToPool == true) {
                ObjectPooler.instance.AddToPool(addToPool, gameObject);
            }
        }
    }
}
