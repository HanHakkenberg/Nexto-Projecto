using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgresRotationReciever : MonoBehaviour {
    [SerializeField] FloatReference progres;
    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;
    [SerializeField] float minZ, maxZ;
    [SerializeField] bool posX, posY, posZ;

    void Start() {
        if(posX) {
            transform.rotation = Quaternion.Euler(minX + Mathf.Abs(minX - maxX) * progres.Value, transform.rotation.y, transform.rotation.z);
        }
        if(posY) {
            transform.rotation = Quaternion.Euler(transform.rotation.x, minY + Mathf.Abs(minY - maxY) * progres.Value, transform.rotation.z);
        }
        if(posZ) {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, minZ + Mathf.Abs(minZ - maxZ) * progres.Value);
        }
    }

    public void UpdateProgres() {
        if(posX) {
            transform.rotation = Quaternion.Euler(minX + Mathf.Abs(minX - maxX) * progres.Value, transform.rotation.y, transform.rotation.z);
        }
        if(posY) {
            transform.rotation = Quaternion.Euler(transform.rotation.x, minY + Mathf.Abs(minY - maxY) * progres.Value, transform.rotation.z);
        }
        if(posZ) {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, minZ + Mathf.Abs(minZ - maxZ) * progres.Value);
        }
    }
}