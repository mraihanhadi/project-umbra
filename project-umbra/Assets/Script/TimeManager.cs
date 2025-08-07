using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[SerializeField]
public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeUIText;
    public bool isPaused;
    public float moonsPerSun = 12f;
    public float moonInterval = 2f;
    public EventManager eventManager;
    private float suns = 0f;
    [SerializeField]
    private float moons = 0f;
    private float speedMultiplier = 1f;
    private float timer = 0f;
    [SerializeField]
    private bool isFastForward = false;
    private bool eventJustTriggered = false;

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
        GameObject foundUI = GameObject.Find("TimeText");
        if (foundUI != null)
        {
            timeUIText = foundUI.GetComponent<TextMeshProUGUI>();
            UpdateTimeUI();
        }
        else
        {
            Debug.LogWarning("Time UI not found in this scene!");
            timeUIText = null;
        }
    }


    void Update()
    {
        if (isPaused) return;
        timer += Time.deltaTime * speedMultiplier;
        if (timer >= moonInterval)
        {
            timer -= moonInterval;
            moons++;
            if (moons >= moonsPerSun)
            {
                moons = 0;
                suns++;
            }
            UpdateTimeUI();
            TryTriggerEventsForAllCharacters();
        }
    }

    void UpdateTimeUI()
    {
        if (timeUIText != null)
        {
            timeUIText.text = $"{suns} Suns {moons} Moons";
        }
    }

    public void PauseTime()
    {
        isPaused = true;
    }

    public void ResumeTime()
    {
        isPaused = false;
        eventJustTriggered = false;
    }

    public void FastForwardTime()
    {
        if (isFastForward)
        {
            speedMultiplier = 1f;
            isFastForward = false;
        }
        else
        {
            speedMultiplier = 2f;
            isFastForward = true;
        }
    }

    void TryTriggerEventsForAllCharacters()
    {
        if (eventJustTriggered) return;
        foreach (var character in eventManager.characterManager.sentChosenInstance)
        {
            foreach (var e in eventManager.allEvents)
            {
                if (!e.repeatable && character.triggeredEventIDs.Contains(e.IDEvent)) continue;
                if (suns < e.yearInMarblesMin) continue;
                if (character.intelligence < e.intelligenceMin || character.strength < e.strengthMin || character.charm < e.charmMin || character.luck < e.luckMin) continue;
                float chance = (character.alignment == AlignmentType.Good) ? e.goodAligned : e.evilAligned;
                float roll = Random.Range(0f, 100f);
                if (roll > chance) continue;
                character.triggeredEventIDs.Add(e.IDEvent);
                eventManager.TriggerEvents(e.IDEvent, character.Name);
                eventJustTriggered = true;
                return;
            }
        }
        if (eventManager.characterManager.sentChosenInstance == null) Debug.Log("Tidak ada character");
    }
}
