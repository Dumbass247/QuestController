using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NPCQuest))]
public class NPCQuestEditor : Editor
{
    SerializedProperty questTypeProp;
    SerializedProperty questEnemyProp;
    SerializedProperty questKillAmountProp;
    SerializedProperty questKillTurnInProp;
    SerializedProperty questFetchItemNameProp;
    SerializedProperty questItemPickUpProp;
    SerializedProperty questFetchItemQuantityProp;
    SerializedProperty questFetchItemDropOffProp;
    SerializedProperty questDeliveryItemNameProp;
    SerializedProperty questDeliveryItemQuantityProp;
    SerializedProperty questDeliveryItemDropOffProp;
    SerializedProperty fetchQuestTextProp;
    SerializedProperty deliveryQuestTextProp;
    SerializedProperty killQuestTextProp;

    // Add this line to declare a serialized property for the QuestManager
    SerializedProperty questManagerProp;

    private void OnEnable()
    {
        questTypeProp = serializedObject.FindProperty("_questType");
        questEnemyProp = serializedObject.FindProperty("questEnemy");
        questKillAmountProp = serializedObject.FindProperty("questKillAmount");
        questKillTurnInProp = serializedObject.FindProperty("questKillTurnIn");
        questFetchItemNameProp = serializedObject.FindProperty("questFetchItemName");
        questItemPickUpProp = serializedObject.FindProperty("questItemPickUp");
        questFetchItemQuantityProp = serializedObject.FindProperty("questFetchItemQuantity");
        questFetchItemDropOffProp = serializedObject.FindProperty("questFetchItemDropOff");
        questDeliveryItemNameProp = serializedObject.FindProperty("questDeliveryItemName");
        questDeliveryItemQuantityProp = serializedObject.FindProperty("questDeliveryItemQuantity");
        questDeliveryItemDropOffProp = serializedObject.FindProperty("questDeliveryItemDropOff");
        fetchQuestTextProp = serializedObject.FindProperty("fetchQuestText");
        deliveryQuestTextProp = serializedObject.FindProperty("deliveryQuestText");
        killQuestTextProp = serializedObject.FindProperty("killQuestText");

        // Add this line to find the serialized property for the QuestManager
        questManagerProp = serializedObject.FindProperty("questManager");
    }

    public override void OnInspectorGUI()
    {
        // Update the serialized object
        serializedObject.Update();

        NPCQuest npcQuest = (NPCQuest)target;
        NPCQuest.QuestType questType = (NPCQuest.QuestType)questTypeProp.enumValueIndex;

        // Display default inspector properties except for _questType
        EditorGUI.BeginChangeCheck();
        DrawPropertiesExcluding(serializedObject, "_questType");
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            return;
        }

        // Display the questType property with a dropdown
        EditorGUILayout.PropertyField(questTypeProp);

        // Display fields based on the selected quest type
        switch (questType)
        {
            case NPCQuest.QuestType.Kill:
                EditorGUILayout.PropertyField(questEnemyProp);
                EditorGUILayout.PropertyField(questKillAmountProp);
                EditorGUILayout.PropertyField(questKillTurnInProp);
                EditorGUILayout.PropertyField(killQuestTextProp);
                break;
            case NPCQuest.QuestType.Fetch:
                EditorGUILayout.PropertyField(questFetchItemNameProp);
                EditorGUILayout.PropertyField(questItemPickUpProp, new GUIContent("Location to receive items"));
                EditorGUILayout.PropertyField(questFetchItemQuantityProp);
                EditorGUILayout.PropertyField(questFetchItemDropOffProp);
                EditorGUILayout.PropertyField(fetchQuestTextProp);
                break;
            case NPCQuest.QuestType.Delivery:
                EditorGUILayout.PropertyField(questDeliveryItemNameProp);
                EditorGUILayout.PropertyField(questDeliveryItemQuantityProp);
                EditorGUILayout.PropertyField(questDeliveryItemDropOffProp);
                EditorGUILayout.PropertyField(deliveryQuestTextProp);
                break;
        }

        EditorGUILayout.Space();

        // Display the QuestManager property
        EditorGUILayout.PropertyField(questManagerProp);

        // Add a button to push quest info to the QuestJournal
        if (GUILayout.Button("Add Quest Entry"))
        {
            if (npcQuest.questManager != null)
            {
                npcQuest.questManager.AddQuestEntry(npcQuest);
            }
            else
            {
                Debug.LogError("QuestManager not assigned.");
            }
        }

        // Apply changes to the serialized object
        serializedObject.ApplyModifiedProperties();

        // Apply the changes to the serialized object
        serializedObject.ApplyModifiedProperties();
    }
}




