using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollectable : QuestTemplate {

    [Header("Visuals:")]
    public Sprite collectableSprite;
    public List<GameObject> toCollect = new List<GameObject>();

    internal int collectablesNeeded;

    protected override void Start()
    {
        base.Start();
        collectablesNeeded = toCollect.Count;
    }

    public void Update()
    {
        if (QuestManager.questManager.currentActiveQuest == this)
            if (collectablesNeeded <= GameManager.gameManager.questCollectables && !finished)
            {
                finished = true;
            }
    }

    public override void UpdateQuestStatus()
    {
        if (QuestManager.questManager.currentActiveQuest == this)
            if (collectablesNeeded <= GameManager.gameManager.questCollectables)
            {
                if(toCollect != null)
                   foreach(GameObject _LeftOver in toCollect)
                        if(_LeftOver != null)
                        _LeftOver.SetActive(false);
              
                StartCoroutine(GiveReward());
                return;
            }

        base.UpdateQuestStatus();

    }

    public override IEnumerator StartQuestTimer()
    {
        yield return StartCoroutine(base.StartQuestTimer());

        yield return new WaitForSeconds(0.1f);
        for(int i = 0; i < toCollect.Count; i++)
        {
            toCollect[i].SetActive(true);
        }

        GameManager.gameManager.questCollectablesText.text = GameManager.gameManager.questCollectables.ToString() + "/" + collectablesNeeded;
        GameManager.gameManager.questCollectableImage.sprite = collectableSprite;
        GameManager.gameManager.questCollectablesAnim.SetTrigger("In");
    }
}
