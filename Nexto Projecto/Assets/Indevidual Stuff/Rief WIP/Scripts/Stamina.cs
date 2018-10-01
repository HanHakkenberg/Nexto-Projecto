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
    public int maxStamina;
    public static bool isRunning;
    bool waitToRegen;
    float regenTimer = 3;


    void Start () 
	{
        FartCount();
    }

	void FartCount()
	{
		fartStamina = beginFarts.Count;
    }
	
	void Update ()
	{
        AddFart();
        FartUpdate();
        StaminaUpdate();
        AbilityUse(1);
        StaminaTest();
    }

	void FartUpdate()
	{
        if (!inCombat && OptionManager.inGame)
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

    void StaminaTest()
    {
        if (Input.GetButton("Space"))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
    void StaminaUpdate()
    {
        if(staCurrLoad < 0)
        {
            staCurrLoad = 0;
        }

        if(isRunning){
            if (staCurrLoad >= runStamina)
            {
                staminaOrb[staCurrLoad].fillAmount -= loadTime * Time.deltaTime;
                if (staminaOrb[staCurrLoad].fillAmount <= 0)
                {
                    staCurrLoad--;
                }
            }
        }
        else
        {
            if(staCurrLoad <= maxStamina && waitToRegen == false)
            {
                staminaOrb[staCurrLoad].fillAmount += loadTime * Time.deltaTime;

                if(staminaOrb[staCurrLoad].fillAmount >= 1 && staCurrLoad <4)
                {
                    staCurrLoad++;
                }
            }
        }

        if(staCurrLoad <= -1)
        {
            waitToRegen = true;
            regenTimer = 3;
        }

        regenTimer -= Time.deltaTime;
        if(regenTimer <= 0)
        {
            regenTimer = 0;
            waitToRegen = false;
        }
    }

    void AbilityUse(int _AbilityCost)
    {
        if(Input.GetButtonDown("SwitchKey") && currentLoad>=1 && _AbilityCost <= currentLoad && OptionManager.inGame) //remove input once implemented
        {
            inCombat = true;
            Combat();
            currentLoad -= _AbilityCost;
            FartRefresh();
            
        }
    }
    void Combat()
    {
        combatTimer = 3;
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

	public void AddFart()
	{
		if(Input.GetButtonDown("Shift")) //remove input once implemented
		{
            beginFarts.Add(obtainableFarts[0]);
            obtainableFarts.Remove(obtainableFarts[0]);
            FartCount();
        }
	}
    public void ResetFarts()
    {
        currentLoad = 0;
    }
}
