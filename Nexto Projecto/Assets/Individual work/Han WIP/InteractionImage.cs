using System.Collections;
using UnityEngine;

public class InteractionImage : MonoBehaviour {
    [SerializeField] MeshRenderer myInteractionImage;
    [SerializeField] Transform toLook;
    [SerializeField] float convertionToSpeed;
    [SerializeField] float convertionFromSpeed;

    private void Update() {
        toLook.LookAt(CutsceneManager.cutsceneManager.mainCam.transform);
    }


    public void Interact() {
        StopAllCoroutines();
        StartCoroutine(Visable());
    }

    public void Deinteract() {
        StopAllCoroutines();
        StartCoroutine(Invisable());
    }

    IEnumerator Visable() {
        while(myInteractionImage.material.color.a < 0.99f) {
            myInteractionImage.material.color = new Color(myInteractionImage.material.color.r, myInteractionImage.material.color.g, myInteractionImage.material.color.b, myInteractionImage.material.color.a + convertionToSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Invisable() {
        while(myInteractionImage.material.color.a > 0.01f) {
            myInteractionImage.material.color = new Color(myInteractionImage.material.color.r, myInteractionImage.material.color.g, myInteractionImage.material.color.b, myInteractionImage.material.color.a - convertionFromSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
