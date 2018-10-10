using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DonutPuzzle : MonoBehaviour {
    
    public TextMeshProUGUI timeText;
    public int time;
    public bool finished;
    bool failed;
    public bool puzzleActive = true;
    public GameObject manager;

    void Start () 
    {
        StartPuzzle();
        //ToStart();
    }
    void ToStart()
    {
        StartCoroutine(Countdown());
    }
	
	void Update () 
    {
        Finish();
        StartTimer();
    }

    public IEnumerator Countdown()
    {
        time -= 1;
        timeText.text = time.ToString();
        timeText.GetComponent<Animator>().SetTrigger("TimeDown");
        yield return new WaitForSeconds(1);
        if (!finished)
        {
            ToStart();
        }
    }
    void StartTimer()
    {
        if(Input.GetButtonDown("SwitchKey") && puzzleActive)
        {
            ToStart();
        }
    }

    public void StartPuzzle()
    {
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
        if(time <= 0)
        {
            failed = true;
        }
    }
}
