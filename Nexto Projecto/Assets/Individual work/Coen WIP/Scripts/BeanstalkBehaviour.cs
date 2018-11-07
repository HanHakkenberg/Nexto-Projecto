using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanstalkBehaviour : MonoBehaviour {

    [Header("Settings:")]
    public GameObject bean;
    public Animator tree;
    public int cutsceneID;

    private void OnTriggerEnter(Collider _C) {
        if (bean == null) return;

        if (_C.gameObject == bean) {
            Destroy(bean);
            SetTreeGrowth();
        }
    }

    private void SetTreeGrowth() {
        tree.SetTrigger("Grow");
        CutsceneManager.cutsceneManager.LoadStartCutscene(cutsceneID);
    }
}
