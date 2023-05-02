using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private QuestJournal questJournal;

    public void AddQuestEntry(NPCQuest npcQuest)
    {
        if (questJournal != null)
        {
            questJournal.AddQuestEntry(npcQuest);
            Debug.Log("Quest entry added to the journal.");
        }
        else
        {
            Debug.LogWarning("QuestJournal not assigned in the QuestManager.");
        }
    }
}
