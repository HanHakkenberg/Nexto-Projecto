using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public IEnumerator DestroySelf() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}