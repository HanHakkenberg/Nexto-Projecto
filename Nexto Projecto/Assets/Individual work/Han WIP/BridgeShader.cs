using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeShader : MonoBehaviour {
    [SerializeField] Renderer rend;
    [SerializeField] float amount;
    [SerializeField] float Addspeed;

    public void StartShader() {
        StartCoroutine(Shader());
    }

    IEnumerator Shader() {
        while(0 <= amount) {
            amount -= Addspeed * Time.deltaTime;
            rend.material.SetFloat("_SliceAmount", amount);
            yield return null;
        }
    }
}
