using System;
using System.Linq;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public CharacterManager characterManager;
    [Header("All Event Data")]
    public EventData[] allEvents;

    public void TestTriggerEvents()
    {
        TriggerEvents("DAI-101", "Ayanto Koji");
    }

    public void TriggerEvents(string fullEventID, string characterName)
    {
        CharacterInstance charEvent = characterManager.sentChosenInstance
            .Find(s => s.Name == characterName);

        if (charEvent == null)
        {
            Debug.LogWarning($"Character {characterName} not found.");
            return;
        }

        string[] parts = fullEventID.Split('-');
        if (parts.Length != 2)
        {
            Debug.LogWarning($"Event ID format incorrect: {fullEventID}");
            return;
        }

        string eventType = parts[0];
        string eventID = fullEventID;
        EventData eventData = allEvents.FirstOrDefault(e => e.IDEvent == eventID);

        if (eventData == null)
        {
            Debug.LogWarning($"Event {eventID} not found.");
            return;
        }

        charEvent.intelligence += eventData.intelligenceReward;
        charEvent.strength += eventData.strengthReward;
        charEvent.charm += eventData.charmReward;
        charEvent.luck += eventData.luckReward;

        Debug.Log($"Applied event {eventData.namaEvent} to character {charEvent.Name}");
    }
}
