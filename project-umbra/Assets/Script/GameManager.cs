using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PendingEvent
{
    public CharacterInstance character;
    public string cityName;
}

[SerializeField]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TimeManager timeManager;
    public CharacterManager characterManager;
    public EventManager eventManager;
    public CurrencyManager currencyManager;
    public CityManager cityManager;
    [System.NonSerialized] 
    public PendingEvent nextSpawnEvent = null;
    void Start()
    {
        nextSpawnEvent = null;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
