using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeUIText;
    public bool isPaused;
    public float moonsPerSun = 12f;
    public float moonInterval = 2f;
    private float suns = 0f;
    [SerializeField]
    private float moons = 0f;
    private float speedMultiplier = 1f;
    private float timer = 0f;
    private bool isFastForward = false;

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
}
