using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PendingEvent
{
    public CharacterInstance character;
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
    public GameObject debugPanel;
    public GameObject menu;
    public GameObject mainView;
    public GameObject eventPanel;
    public MainViewManager findMainViewManager;
    public MainViewManager mainViewManager;
    public GameObject scrollMenuUI;
    public CameraMovement uiOpen;
    GameObject opener;
    [SerializeField]
    GameObject menuBtn;
    [SerializeField]
    GameObject saveMenu;
    [SerializeField]
    GameObject loadMenu;
    [SerializeField]
    GameObject settingsMenu;
    void Start()
    {
        nextSpawnEvent = null;
        menuBtn.SetActive(true);
        saveMenu.SetActive(false);
        loadMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainView.SetActive(true);
        menu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menu.activeInHierarchy)
            {
                OpenMenu();
            }
            else
            {
                if (!menuBtn.activeInHierarchy)
                {
                    BackToMenu();
                }
                else
                {
                    CloseMenu();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            if (!debugPanel.activeInHierarchy)
            {
                OpenDebugPanel();
            }
        }
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
        findMainViewManager = FindFirstObjectByType<MainViewManager>();
        if (findMainViewManager != null)
        {
            mainViewManager = findMainViewManager;
        }
        else
        {
            Debug.Log("Not found main view");
            findMainViewManager = null;
            mainViewManager = null;
        }
    }
    public void OpenDebugPanel()
    {
        debugPanel.SetActive(true);
    }
    public void Debug1()
    {
        GameManager.Instance.currencyManager.IncreaseDivinePower(999);
    }
    public void CloseDebugPanel()
    {
        debugPanel.SetActive(false);
    }
    public void OpenMenu()
    {
        if (mainViewManager != null)
        {
            mainViewManager.SetActiveMainView(false);
        }
        mainView.SetActive(false);
        menu.SetActive(true);
        GameManager.Instance.timeManager.PauseTime();
    }

    public void CloseMenu()
    {
        if (mainViewManager != null)
        {
            mainViewManager.SetActiveMainView(true);
        }
        mainView.SetActive(true);
        menu.SetActive(false);
        GameManager.Instance.timeManager.ResumeTime();
    }

    void BackToMenu()
    {
        saveMenu.SetActive(false);
        loadMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainView.SetActive(false);
        menuBtn.SetActive(true);
    }

    public void OpenSaveMenu()
    {
        menuBtn.SetActive(false);
        saveMenu.SetActive(true);
        mainView.SetActive(true);
    }

    public void OpenLoadMenu()
    {
        menuBtn.SetActive(false);
        loadMenu.SetActive(true);
        mainView.SetActive(true);
    }

    public void OpenSettingsMenu()
    {
        menuBtn.SetActive(false);
        settingsMenu.SetActive(true);
        mainView.SetActive(true);
    }

    public void CloseEvent()
    {
        eventPanel.SetActive(false);
        GameManager.Instance.timeManager.ResumeTime();
    }

    public void OpenScrollMenuUI()
    {
        scrollMenuUI.SetActive(true);
    }

    public void CloseScrollMenuUI()
    {
        scrollMenuUI.SetActive(false);
    }

    public void OpenLogMenuUI()
    {
        scrollMenuUI.SetActive(true);
    }

    public void CloseLogMenuUI()
    {
        scrollMenuUI.SetActive(false);
    }
}
