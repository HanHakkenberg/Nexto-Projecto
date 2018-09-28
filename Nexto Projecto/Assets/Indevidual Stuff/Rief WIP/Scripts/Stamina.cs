using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {

    [Header("Farts")]
    public bool inCombat;
    public float loadTime;
    public int currentLoad;
    public int fartStamina;
    public List<Image> beginFarts = new List<Image>();
    public List<Image> obtainableFarts = new List<Image>();
    float combatTimer = 3;

    [Header("Run Stamina")]
    public List<Image> staminaOrb = new List<Image>();
    public int staCurrLoad;
    public int runStamina;


    void Start () 
	{
        FartCount();
        combatTimer = 3;
    }

	void FartCount()
	{
		fartStamina = beginFarts.Count;
        runStamina = staminaOrb.Count;
    }
	
	void Update ()
	{
        AddFart();
        FartUpdate();
        StaminaUpdate();
        //IncreaseBar();
        //DecreaseBar();
        TestAbility(1);
    }

	void FartUpdate()
	{
        if (!inCombat)
        {
            if (currentLoad < fartStamina)
            {
                beginFarts[currentLoad].fillAmount += loadTime * Time.deltaTime;
                if (beginFarts[currentLoad].fillAmount >= 1)
                {
                    currentLoad++;
                }
            }
        }

        combatTimer -= Time.deltaTime;
        if(combatTimer<= 0)
        {
            combatTimer = 0;
            inCombat = false;
        }
    }

    void StaminaUpdate()
    {
        if (Input.GetButton("Space"))
        {
            if (staCurrLoad < runStamina)
            {
                staminaOrb[staCurrLoad].fillAmount -= loadTime * Time.deltaTime;
                if (staminaOrb[staCurrLoad].fillAmount <= 0)
                {
                    staCurrLoad++;
                }
            }
        }
    }

    void TestAbility(int _AbilityCost)
    {
        if(Input.GetButtonDown("SwitchKey") && currentLoad>=1 && _AbilityCost <= currentLoad && OptionManager.inGame)
        {
            inCombat = true;
            Start();
            currentLoad -= _AbilityCost;
            FartRefresh();
            
        }
    }

    void FartRefresh()
    {
        for (int j = 0; j < beginFarts.Count; j++)
        {
            beginFarts[j].fillAmount = 0;
        }

        for (int i = 0; i < currentLoad; i++)
        {
            beginFarts[i].fillAmount = 1;
        }
    }

	void AddFart()
	{
		if(Input.GetButtonDown("Shift"))
		{
            beginFarts.Add(obtainableFarts[0]);
            obtainableFarts.Remove(obtainableFarts[0]);
            FartCount();
        }
	}

	/*public void DecreaseBar()
	{
        if (Input.GetButton("Space"))
        {
            if(staminaBar.fillAmount <=0)
            {
                //laat de baby kruipen tot een threshold, dan kan de baby weer lopen / rennen
            }
            else
            {
                staminaBar.fillAmount -= staValue * Time.deltaTime;
            }
        }
    }*/

    public void IncreaseBar()
    {
        
    }
}
