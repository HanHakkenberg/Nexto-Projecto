using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour {

	public List<GameObject> candies;
	public List<GameObject> used;
	public int currRound;

	bool wrong;

	void Start () {
	}
	
	void Update () {
		if(Input.GetButtonDown("Map"))
		{
			Erase();
		}
	}

	void Erase()
	{
		if(!wrong)
		{
			currRound++;
		}
		wrong = false;
		for(int i = used.Count - 1; i >= 0; i--)
		{
			used.Remove(used[i]);
		}
		Round();
	}
	public void Round()
	{
		int amount = 2 + currRound;

		for(int i = 0; i < amount; i++)
		{
			used.Add(candies[Random.Range(0, candies.Count)]);
		}
		StartCoroutine(StartGame());
	}
	IEnumerator StartGame()
	{
		for(int i = 0; i < used.Count; i++)
		{

			used[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(2.5f,2.5f,2.5f,2.5f));
			yield return new WaitForSeconds(0.7f);
			used[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1,1,1,1));
			yield return new WaitForSeconds(0.5f);
		}
	}
	public void Check(string currCandy)
	{
		if(used[0].name == currCandy)
		{
			used.Remove(used[0]);
			
			if(used.Count == 0)
			{
				Erase();
			}

			//play "CORRECT" sound
		}
		else
		{
			wrong = true;
			Erase();
		}
	}
}
