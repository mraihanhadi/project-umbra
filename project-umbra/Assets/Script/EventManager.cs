using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[SerializeField]
public class EventManager : MonoBehaviour
{
    public CharacterManager characterManager;
    [Header("All Event Data")]
    public EventData[] allEvents;
    public GameObject eventPanel;
    public TextMeshProUGUI judulEvent;
    public TextMeshProUGUI deskripsiEvent;
    public TimeManager timeManager;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        eventPanel = allObjects.FirstOrDefault(go => go.name == "EventPanel");
        GameObject foundUIJudul = allObjects.FirstOrDefault(go => go.name == "Judul");
        GameObject foundUIDeskripsi = allObjects.FirstOrDefault(go => go.name == "Deskripsi");
        if (eventPanel != null || foundUIJudul != null || foundUIDeskripsi != null)
        {
            judulEvent = foundUIJudul.GetComponent<TextMeshProUGUI>();
            deskripsiEvent = foundUIDeskripsi.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.Log("Event component not found");
            eventPanel = null;
            judulEvent = null;
            deskripsiEvent = null;
        }
    }

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
        eventPanel.SetActive(true);
        judulEvent.text = eventData.namaEvent;
        deskripsiEvent.text = eventData.winDescription;
        charEvent.intelligence += eventData.intelligenceReward;
        charEvent.strength += eventData.strengthReward;
        charEvent.charm += eventData.charmReward;
        charEvent.luck += eventData.luckReward;
        timeManager.PauseTime();

        Debug.Log($"Applied event {eventData.namaEvent} to character {charEvent.Name}");
    }
}
