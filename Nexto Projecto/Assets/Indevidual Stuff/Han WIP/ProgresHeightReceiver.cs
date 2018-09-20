using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgresHeightReceiver : MonoBehaviour {
    [SerializeField] FloatReference progres;
    [SerializeField] float min, max;

    public void UpdateProgres() {
        transform.position = new Vector3(transform.position.x,min + Mathf.Abs(min - max) * progres.Value, transform.position.z);
    }
}
