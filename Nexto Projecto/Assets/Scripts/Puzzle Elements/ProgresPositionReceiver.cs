using UnityEngine;

public class ProgresPositionReceiver : MonoBehaviour {
    [SerializeField] FloatReference progres;
    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;
    [SerializeField] float minZ, maxZ;
    [SerializeField] bool posX, posY, posZ;

    void Start() {
        if(posX) {
            transform.position = new Vector3(minX + Mathf.Abs(minX - maxX) * progres.Value, transform.position.y, transform.position.z);
        }
        if(posY) {
            transform.position = new Vector3(transform.position.x, minY + Mathf.Abs(minY - maxY) * progres.Value, transform.position.z);
        }
        if(posZ) {
            transform.position = new Vector3(transform.position.x, transform.position.y, minZ + Mathf.Abs(minZ - maxZ) * progres.Value);
        }
    }

    public void UpdateProgres() {
        if(posX) {
            transform.position = new Vector3(minX + Mathf.Abs(minX - maxX) * progres.Value, transform.position.y, transform.position.z);
        }
        if(posY) {
            transform.position = new Vector3(transform.position.x, minY + Mathf.Abs(minY - maxY) * progres.Value, transform.position.z);
        }
        if(posZ) {
            transform.position = new Vector3(transform.position.x, transform.position.y, minZ + Mathf.Abs(minZ - maxZ) * progres.Value);
        }
    }
}
