using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventData))]
public class EventDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EventData data = (EventData)target;

        data.IDEvent = EditorGUILayout.TextField("ID Event", data.IDEvent);
        data.namaEvent = EditorGUILayout.TextField("Nama Event", data.namaEvent);
        data.jenisEvent = (EventType)EditorGUILayout.EnumPopup("Jenis Event", data.jenisEvent);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Minimal Attributes", EditorStyles.boldLabel);
        data.yearInMarblesMin = EditorGUILayout.IntField("Year In Marbles Min", data.yearInMarblesMin);
        data.intelligenceMin = EditorGUILayout.FloatField("Intelligence Min", data.intelligenceMin);
        data.strengthMin = EditorGUILayout.FloatField("Strength Min", data.strengthMin);
        data.charmMin = EditorGUILayout.FloatField("Charm Min", data.charmMin);
        data.luckMin = EditorGUILayout.FloatField("Luck Min", data.luckMin);

        if (data.jenisEvent == EventType.Encounter)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Encounter Settings", EditorStyles.boldLabel);
            data.jobRequirement = (Jobs)EditorGUILayout.EnumPopup("Job Requirement", data.jobRequirement);
            data.goodAligned = EditorGUILayout.FloatField("Good Aligned Chance", data.goodAligned);
            data.evilAligned = EditorGUILayout.FloatField("Evil Aligned Chance", data.evilAligned);
        }
        else if (data.jenisEvent == EventType.Spawn)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Spawn Settings", EditorStyles.boldLabel);
            data.spawnLocation = EditorGUILayout.TextField("Spawn Location", data.spawnLocation);
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Rewards", EditorStyles.boldLabel);
        data.intelligenceReward = EditorGUILayout.FloatField("Intelligence Reward", data.intelligenceReward);
        data.strengthReward = EditorGUILayout.FloatField("Strength Reward", data.strengthReward);
        data.charmReward = EditorGUILayout.FloatField("Charm Reward", data.charmReward);
        data.luckReward = EditorGUILayout.FloatField("Luck Reward", data.luckReward);

        if (data.jenisEvent == EventType.Encounter)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Punishment", EditorStyles.boldLabel);
            data.intelligencePunishment = EditorGUILayout.FloatField("Intelligence Punishment", data.intelligencePunishment);
            data.strengthPunishment = EditorGUILayout.FloatField("Strength Punishment", data.strengthPunishment);
            data.charmPunishment = EditorGUILayout.FloatField("Charm Punishment", data.charmPunishment);
            data.luckPunishment = EditorGUILayout.FloatField("Luck Punishment", data.luckPunishment);
        }

        EditorGUILayout.LabelField("Hidden Attribute", EditorStyles.boldLabel);
        data.intelligenceHidden = EditorGUILayout.FloatField("Intelligence Reward", data.intelligenceHidden);
        data.strengthHidden = EditorGUILayout.FloatField("Strength Reward", data.strengthHidden);
        data.charmHidden = EditorGUILayout.FloatField("Charm Reward", data.charmHidden);
        data.luckHidden = EditorGUILayout.FloatField("Luck Reward", data.luckHidden);        

        if (data.jenisEvent == EventType.Encounter)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Outcome Description", EditorStyles.boldLabel);
            data.winDescription = EditorGUILayout.TextField("Win Description", data.winDescription);
            data.loseDescription = EditorGUILayout.TextField("Lose Description", data.loseDescription);
        }

        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }
}
