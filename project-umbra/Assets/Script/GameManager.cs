using UnityEngine;
using UnityEngine.SceneManagement;

[SerializeField]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TimeManager timeManager;
    public CharacterManager characterManager;
    public EventManager eventManager;
    public CurrencyManager currencyManager;
    public CityManager cityManager;
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
