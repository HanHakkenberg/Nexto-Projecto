using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public List<QuestTemplate> inactive = new List<QuestTemplate>();
	public List<QuestTemplate> finished = new List<QuestTemplate>();
    public List<Sprite> questStatusIcon = new List<Sprite>(); 

    public QuestTemplate currentActiveQuest;
    public Dialogue alreadyHasQuestDialogue;

    public static QuestManager questManager;

	private void Awake() {
		if(questManager == null)
		questManager = this;
		else
		Destroy(this);
	}

    private void Start()
    {
        StartCoroutine(UpdateQuestStatus());
    }

    /// <summary>
    /// icons in order:
    /// 0 = green "!" (not started)
    /// 1 = yellow "?"(started but not completed)
    /// 2 = yellow "!" (not started, not avaiable right now)
    /// 3 = green "V" (completed)
    /// </summary>
    /// 
    public IEnumerator UpdateQuestStatus()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            yield return new WaitForSeconds(0.2f);
            if (currentActiveQuest != null)
            {
                if (currentActiveQuest.finished)                
                    currentActiveQuest.questStatusDisplay.sprite = questStatusIcon[3];                
                else              
                    currentActiveQuest.questStatusDisplay.sprite = questStatusIcon[1];               

                for(int o = 0; o < inactive.Count; o++)               
                    inactive[o].questStatusDisplay.sprite = questStatusIcon[2];               
            }

            if(currentActiveQuest == null)
            for (int o = 0; o < inactive.Count; o++)            
                inactive[o].questStatusDisplay.sprite = questStatusIcon[0];            
        }
    }
}
