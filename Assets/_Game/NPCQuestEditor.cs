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
    SerializedProperty FetchQuestTextProp;
    SerializedProperty DeliveryQuestTextProp;
    SerializedProperty KillQuestTextProp;

    private void OnEnable()
    {
        questTypeProp = serializedObject.FindProperty("_questType");
        questEnemyProp = serializedObject.FindProperty("_questEnemy");
        questKillAmountProp = serializedObject.FindProperty("_questKillAmount");
        questKillTurnInProp = serializedObject.FindProperty("_questKillTurnIn");
        questFetchItemNameProp = serializedObject.FindProperty("_questFetchItemName");
        questItemPickUpProp = serializedObject.FindProperty("_questItemPickUp");
        questFetchItemQuantityProp = serializedObject.FindProperty("_questFetchItemQuantity");
        questFetchItemDropOffProp = serializedObject.FindProperty("_questFetchItemDropOff");
        questDeliveryItemNameProp = serializedObject.FindProperty("_questDeliveryItemName");
        questDeliveryItemQuantityProp = serializedObject.FindProperty("_questDeliveryItemQuantity");
        questDeliveryItemDropOffProp = serializedObject.FindProperty("_questDeliveryItemDropOff");
        FetchQuestTextProp = serializedObject.FindProperty("_FetchQuestText");
        DeliveryQuestTextProp = serializedObject.FindProperty("_DeliveryQuestText");
        KillQuestTextProp = serializedObject.FindProperty("_KillQuestText");
    }

    public override void OnInspectorGUI()
    {
        // Draw default inspector properties
        DrawDefaultInspector();

        // Update the serialized object
        serializedObject.Update();

        NPCQuest npcQuest = (NPCQuest)target;
        NPCQuest.QuestType questType = (NPCQuest.QuestType)questTypeProp.enumValueIndex;

        // Display fields based on the selected quest type
        switch (questType)
        {
            case NPCQuest.QuestType.Kill:
                EditorGUILayout.PropertyField(questEnemyProp);
                EditorGUILayout.PropertyField(questKillAmountProp);
                EditorGUILayout.PropertyField(questKillTurnInProp);
                EditorGUILayout.PropertyField(KillQuestTextProp);
                break;
            case NPCQuest.QuestType.Fetch:
                EditorGUILayout.PropertyField(questFetchItemNameProp);
                EditorGUILayout.PropertyField(questItemPickUpProp);
                EditorGUILayout.PropertyField(questFetchItemQuantityProp);
                EditorGUILayout.PropertyField(questFetchItemDropOffProp);
                EditorGUILayout.PropertyField(FetchQuestTextProp);
                break;
            case NPCQuest.QuestType.Delivery:
                EditorGUILayout.PropertyField(questDeliveryItemNameProp);
                EditorGUILayout.PropertyField(questDeliveryItemQuantityProp);
                EditorGUILayout.PropertyField(questDeliveryItemDropOffProp);
                EditorGUILayout.PropertyField(DeliveryQuestTextProp);
                break;
        }

        // Apply the changes to the serialized object
        serializedObject.ApplyModifiedProperties();
    }
}



