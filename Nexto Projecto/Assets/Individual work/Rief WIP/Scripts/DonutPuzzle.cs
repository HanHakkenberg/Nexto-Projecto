using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DonutPuzzle : MonoBehaviour {
    
    public GameObject donutCanvas;
    public TextMeshProUGUI timeText;
    public int time;
    public int hit;
    public bool finished;
    public bool failed;
    bool busy;
    public bool puzzleActive = true;
    //public GameObject manager;

    void Start () 
    {
        time = 120;
        //StartPuzzle();
        //ToStart();
    }
    void ToStart()
    {
        StartCoroutine(Countdown());
    }
	
	void Update () 
    {
        Finish();
        Inputs();
        Failed();
    }

    public IEnumerator Countdown()
    {
        timeText.text = time.ToString();
        timeText.GetComponent<Animator>().SetTrigger("TimeDown");
        yield return new WaitForSeconds(1);
        time -= 1;
        if (!finished && time >=0)
        {
            ToStart();
        }
    }
    void Inputs()
    {
        if(Input.GetButtonDown("SwitchKey"))
        {
            if (puzzleActive)
            {
                ToStart();
                puzzleActive = false;
                busy = true;
            }
            if(failed)
            {
                timeText.text = "";
            }
            if(busy)
            {
                busy = false;
                time = 10;
            }
        }
    }

    public void StartPuzzle()
    {
        donutCanvas.SetActive(true);
        timeText.text = "Press K to start flying!";
        puzzleActive = true;
    }

    public void Finish()
    {
        if(finished)
        {
            timeText.text = "Press K to fly back!";
            puzzleActive = false;
        }
    }

    public void Failed()
    {
        if(time < 0)
        {
            failed = true;
            puzzleActive = false;
            StartCoroutine(DeactivateCanvas());
        }
    }
    IEnumerator DeactivateCanvas()
    {
        yield return new WaitForSeconds(5);
        donutCanvas.SetActive(false);
    }
}
