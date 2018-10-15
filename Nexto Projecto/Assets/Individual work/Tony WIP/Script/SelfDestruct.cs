using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float selfDestructTimer;

	void Update () {

        selfDestructTimer -= Time.deltaTime;

        if (selfDestructTimer < 0)
            Destroy(this);
	}
}
