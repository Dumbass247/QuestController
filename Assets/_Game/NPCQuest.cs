using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuest : MonoBehaviour
{
    [Header("General Information")]
    [SerializeField] private string _name;

    [Header("Quest Information")]
    [SerializeField] private string _questName;
    [SerializeField][Tooltip("Optional Field for extra info on quest")] private string _questDescription;
     
    [SerializeField][Tooltip("Type of quest: fetch, kill, or delivery")] private QuestType _questType;
    //Fetch Quest Inspector
    [HideInInspector][SerializeField][Tooltip("Name of Quest item")] private string _questFetchItemName;
    [HideInInspector][SerializeField][Tooltip("Location to receive items")] private string _questItemPickUp;
    [HideInInspector][SerializeField][Tooltip("Number of needed items for turn in")][Range(1, 20)] private int _questFetchItemQuantity;
    [HideInInspector][SerializeField][Tooltip("Location to turn in the quest")] private GameObject _questFetchItemDropOff;
    [HideInInspector][SerializeField][Tooltip("Text NPC will share about the quest when the player interacts with them")][TextArea()] private string _FetchQuestText;
    //Delivery Quest Inspector
    [HideInInspector][SerializeField][Tooltip("Name of Quest item")] private string _questDeliveryItemName;
    [HideInInspector][SerializeField][Tooltip("Number of needed items for turn in")][Range(1, 20)] private int _questDeliveryItemQuantity;
    [HideInInspector][SerializeField][Tooltip("Location to turn in the quest")] private GameObject _questDeliveryItemDropOff;
    [HideInInspector][SerializeField][Tooltip("Text NPC will share about the quest when the player interacts with them")][TextArea()] private string _DeliveryQuestText;
    //Kill Quest Inspector
    [HideInInspector][SerializeField][Tooltip("Enemy GameObject")] private GameObject _questEnemy;
    [HideInInspector][SerializeField][Tooltip("Number of needed kills")][Range(1, 50)] private int _questKillAmount;
    [HideInInspector][SerializeField][Tooltip("Location to turn in Kill quest")] private GameObject _questKillTurnIn;
    [HideInInspector][SerializeField][Tooltip("Text NPC will share about the quest when the player interacts with them")][TextArea()] private string _KillQuestText;

    public enum QuestType
    {
        Kill,
        Fetch,
        Delivery
    }
}

