using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public GameObject interactImage;
    public Sprite typeImage;
    public Sprite resetImage;
    public Animator interactBool;


    public void OnTriggerEnter()
	{
        var tempColor = GetComponent<Image>().color;
        tempColor.a = 1f;
        interactImage.GetComponent<Image>().sprite = typeImage;
        interactImage.GetComponent<Image>().color = tempColor;
        interactBool.SetBool("Interaction", true);
		//glow toevoegen
    }

	public void OnTriggerExit()
	{
		var tempColor = GetComponent<Image>().color;
        tempColor.a = 0f;
        interactImage.GetComponent<Image>().sprite = resetImage;
		interactImage.GetComponent<Image>().color = tempColor;
		interactBool.SetBool("Interaction", false);
		//glow toevoegen
    }
}
