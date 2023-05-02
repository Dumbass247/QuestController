using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuest : MonoBehaviour
{
    [System.Serializable]
    public class NPCQuestJournalEntry
    {
        public string questName;
        public QuestType questType;
        public bool questCompleted;
        public string questText;

        // Additional fields based on the quest type
        public GameObject questEnemy;
        public int questKillAmount;
        public GameObject questKillTurnIn;
        public string questFetchItemName;
        public GameObject questItemPickUp;
        public int questFetchItemQuantity;
        public GameObject questFetchItemDropOff;
        public string questDeliveryItemName;
        public int questDeliveryItemQuantity;
        public GameObject questDeliveryItemDropOff;
    }

    [Header("General Information")]
    [SerializeField] private string _name;

    [Header("Quest Information")]
    [SerializeField] private string _questName;
    [SerializeField][Tooltip("Optional Field for extra info on quest")] private string _questDescription;

    [SerializeField][Tooltip("Type of quest: fetch, kill, or delivery")] private QuestType _questType;

    public string questName => _questName;
    public QuestType questType => _questType;

    [HideInInspector][SerializeField] public QuestManager questManager;
    public NPCQuestJournalEntry GetQuestJournalEntry()
    {
        NPCQuestJournalEntry journalEntry = new NPCQuestJournalEntry();
        journalEntry.questName = _questName;
        journalEntry.questType = _questType;
        journalEntry.questCompleted = false;

        switch (_questType)
        {
            case QuestType.Kill:
                journalEntry.questEnemy = questEnemy;
                journalEntry.questKillAmount = questKillAmount;
                journalEntry.questKillTurnIn = questKillTurnIn;
                journalEntry.questText = killQuestText;
                break;
            case QuestType.Fetch:
                journalEntry.questFetchItemName = questFetchItemName;
                journalEntry.questItemPickUp = questItemPickUp;
                journalEntry.questFetchItemQuantity = questFetchItemQuantity;
                journalEntry.questFetchItemDropOff = questFetchItemDropOff;
                journalEntry.questText = fetchQuestText;
                break;
            case QuestType.Delivery:
                journalEntry.questDeliveryItemName = questDeliveryItemName;
                journalEntry.questDeliveryItemQuantity = questDeliveryItemQuantity;
                journalEntry.questDeliveryItemDropOff = questDeliveryItemDropOff;
                journalEntry.questText = deliveryQuestText;
                break;
        }

        return journalEntry;
    }


    [HideInInspector][SerializeField][Tooltip("Name of Quest item")] public string questFetchItemName;
    [HideInInspector][SerializeField][Tooltip("Location to receive items")] public GameObject questItemPickUp;
    [HideInInspector][SerializeField][Tooltip("Number of needed items for turn in")][Range(1, 20)] public int questFetchItemQuantity;
    [HideInInspector][SerializeField][Tooltip("Location to turn in the quest")] public GameObject questFetchItemDropOff;
    [HideInInspector][SerializeField][Tooltip("Text NPC will share about the quest when the player interacts with them")][TextArea()] public string fetchQuestText;

    [HideInInspector][SerializeField][Tooltip("Name of Quest item")] public string questDeliveryItemName;
    [HideInInspector][SerializeField][Tooltip("Number of needed items for turn in")][Range(1, 20)] public int questDeliveryItemQuantity;
    [HideInInspector][SerializeField][Tooltip("Location to turn in the quest")] public GameObject questDeliveryItemDropOff;
    [HideInInspector][SerializeField][Tooltip("Text NPC will share about the quest when the player interacts with them")][TextArea()] public string deliveryQuestText;

    [HideInInspector][SerializeField][Tooltip("Enemy GameObject")] public GameObject questEnemy;
    [HideInInspector][SerializeField][Tooltip("Number of needed kills")][Range(1, 50)] public int questKillAmount;
    [HideInInspector][SerializeField][Tooltip("Location to turn in Kill quest")] public GameObject questKillTurnIn;
    [HideInInspector][SerializeField][Tooltip("Text NPC will share about the quest when the player interacts with them")][TextArea()] public string killQuestText;

    public enum QuestType
    {
        Kill,
        Fetch,
        Delivery
    }

    public void AddQuestEntry()
    {
        QuestManager questManager = FindObjectOfType<QuestManager>();
        if (questManager != null)
        {
            questManager.AddQuestEntry(this);
        }
        else
        {
            Debug.LogWarning("QuestManager not found in the scene.");
        }
    }
}
