using UnityEngine;

public class ProgresPositionReceiver : MonoBehaviour {
    [SerializeField] FloatReference progres;
    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;
    [SerializeField] float minZ, maxZ;
    [SerializeField] bool posX, posY, posZ;

    void Start() {
        if(posX) {
            transform.localPosition = new Vector3(minX + Mathf.Abs(minX - maxX) * progres.Value, transform.localPosition.y, transform.localPosition.z);
        }
        if(posY) {
            transform.localPosition = new Vector3(transform.localPosition.x, minY + Mathf.Abs(minY - maxY) * progres.Value, transform.localPosition.z);
        }
        if(posZ) {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, minZ + Mathf.Abs(minZ - maxZ) * progres.Value);
        }
    }

    public void UpdateProgres() {
        if(posX) {
            transform.localPosition = new Vector3(minX + Mathf.Abs(minX - maxX) * progres.Value, transform.localPosition.y, transform.localPosition.z);
        }
        if(posY) {
            transform.localPosition = new Vector3(transform.localPosition.x, minY + Mathf.Abs(minY - maxY) * progres.Value, transform.localPosition.z);
        }
        if(posZ) {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, minZ + Mathf.Abs(minZ - maxZ) * progres.Value);
        }
    }
}
