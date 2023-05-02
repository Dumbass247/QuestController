using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestJournal))]
public class QuestJournalEditor : Editor
{
    public override void OnInspectorGUI()
    {
        QuestJournal questJournal = (QuestJournal)target;

        EditorGUI.BeginChangeCheck();

        EditorGUILayout.LabelField("Quest Entries", EditorStyles.boldLabel);

        for (int i = 0; i < questJournal.QuestEntries.Count; i++)
        {
            NPCQuest.NPCQuestJournalEntry entry = questJournal.QuestEntries[i];

            EditorGUILayout.LabelField(entry.questName, EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Quest Type", entry.questType.ToString());
            entry.questCompleted = EditorGUILayout.Toggle("Completed", entry.questCompleted);
            EditorGUILayout.LabelField("Quest Text", entry.questText);

            switch (entry.questType)
            {
                case NPCQuest.QuestType.Kill:
                    EditorGUILayout.ObjectField("Quest Enemy", entry.questEnemy, typeof(GameObject), true);
                    EditorGUILayout.IntField("Quest Kill Amount", entry.questKillAmount);
                    EditorGUILayout.ObjectField("Quest Kill Turn In", entry.questKillTurnIn, typeof(GameObject), true);
                    break;
                case NPCQuest.QuestType.Fetch:
                    EditorGUILayout.TextField("Quest Fetch Item Name", entry.questFetchItemName);
                    EditorGUILayout.ObjectField("Quest Item Pick Up", entry.questItemPickUp, typeof(GameObject), true);
                    EditorGUILayout.IntField("Quest Fetch Item Quantity", entry.questFetchItemQuantity);
                    EditorGUILayout.ObjectField("Quest Fetch Item Drop Off", entry.questFetchItemDropOff, typeof(GameObject), true);
                    break;
                case NPCQuest.QuestType.Delivery:
                    EditorGUILayout.TextField("Quest Delivery Item Name", entry.questDeliveryItemName);
                    EditorGUILayout.IntField("Quest Delivery Item Quantity", entry.questDeliveryItemQuantity);
                    EditorGUILayout.ObjectField("Quest Delivery Item Drop Off", entry.questDeliveryItemDropOff, typeof(GameObject), true);
                    break;
            }

            if (entry.questCompleted)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Remove Quest", GUILayout.Width(120)))
                {
                    questJournal.QuestEntries.RemoveAt(i);
                }
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.Space();
        }

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(questJournal);
        }
    }
}

