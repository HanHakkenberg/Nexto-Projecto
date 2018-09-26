using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {

    public float loadTime;
    public int currentLoad;
    public int maxStamina;
    public Image fart;
    public List<Image> beginFarts = new List<Image>();
    public List<Image> obtainableFarts = new List<Image>();

    public Image staminaBar;
    public float staKill;


    void Start () 
	{
        FartCount();
    }

	void FartCount()
	{
		maxStamina = beginFarts.Count;
	}
	
	void Update ()
	{
        AddFart();
        FartUpdate();
    }

	void FartUpdate()
	{
        if (currentLoad < maxStamina)
        {
            beginFarts[currentLoad].fillAmount += loadTime * Time.deltaTime;
            if (beginFarts[currentLoad].fillAmount >= 1)
            {
                currentLoad++;
            }
        }
    }

	void AddFart()
	{
		if(Input.GetButtonDown("Space"))
		{
            beginFarts.Add(obtainableFarts[0]);
            obtainableFarts.Remove(obtainableFarts[0]);
            FartCount();
        }
	}

	public void AdjustBar()
	{
        staminaBar.fillAmount -= staKill * Time.deltaTime;
    }
}
