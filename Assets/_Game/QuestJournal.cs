using System.Collections.Generic;
using UnityEngine;

public class QuestJournal : ScriptableObject
{
    [SerializeField]
    private List<NPCQuest.NPCQuestJournalEntry> questEntries = new List<NPCQuest.NPCQuestJournalEntry>();

    public List<NPCQuest.NPCQuestJournalEntry> QuestEntries => questEntries;

    public void AddQuestEntry(NPCQuest npcQuest)
    {
        NPCQuest.NPCQuestJournalEntry journalEntry = new NPCQuest.NPCQuestJournalEntry();
        journalEntry.questName = npcQuest.questName;
        journalEntry.questType = npcQuest.questType;
        journalEntry.questCompleted = false;

        switch (npcQuest.questType)
        {
            case NPCQuest.QuestType.Kill:
                journalEntry.questEnemy = npcQuest.questEnemy;
                journalEntry.questKillAmount = npcQuest.questKillAmount;
                journalEntry.questKillTurnIn = npcQuest.questKillTurnIn;
                journalEntry.questText = npcQuest.killQuestText;
                break;
            case NPCQuest.QuestType.Fetch:
                journalEntry.questFetchItemName = npcQuest.questFetchItemName;
                journalEntry.questItemPickUp = npcQuest.questItemPickUp;
                journalEntry.questFetchItemQuantity = npcQuest.questFetchItemQuantity;
                journalEntry.questFetchItemDropOff = npcQuest.questFetchItemDropOff;
                journalEntry.questText = npcQuest.fetchQuestText;
                break;
            case NPCQuest.QuestType.Delivery:
                journalEntry.questDeliveryItemName = npcQuest.questDeliveryItemName;
                journalEntry.questDeliveryItemQuantity = npcQuest.questDeliveryItemQuantity;
                journalEntry.questDeliveryItemDropOff = npcQuest.questDeliveryItemDropOff;
                journalEntry.questText = npcQuest.deliveryQuestText;
                break;
        }

        questEntries.Add(journalEntry);
    }
}






