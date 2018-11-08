using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundTransition : MonoBehaviour
{

    public Color skyboxColor;
    private Color lerpColor;
    private bool canChangeColor;

    public void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            if (RenderSettings.skybox.HasProperty("_Tint"))
                if (!RenderSettings.skybox.GetColor("_Tint").Equals(skyboxColor))
                    StartCoroutine(SceneTransition());
        }
    }

    public IEnumerator SceneTransition()
    {
        if (RenderSettings.skybox.HasProperty("_Tint"))
        {
            lerpColor = Color.Lerp(RenderSettings.skybox.GetColor("_Tint"), skyboxColor, 5f * Time.deltaTime);
            RenderSettings.skybox.SetColor("_Tint", lerpColor);
        }
        yield break;
    }
}

