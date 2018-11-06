using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRockBehaviour : MonoBehaviour {

    public GameObject rock;
    public ParticleSystem particles;
    public LayerMask mask;

    private bool gaveCollectable = false;

    private void OnTriggerEnter(Collider _C) {
        print(_C);
        if (gaveCollectable == false) {
            if (_C.gameObject.layer == gameObject.layer) {
                gaveCollectable = true;
                rock.SetActive(false);
                particles.Play();
                GameManager.gameManager.AddQuestCollectable(1);
            }
        }
    }
}
