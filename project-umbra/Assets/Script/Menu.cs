using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public GameObject menu;
    public GameObject mainView;
    GameObject menuBtn;
    GameObject saveMenu;
    GameObject loadMenu;
    GameObject settingsMenu;
    void Start()
    {
        menuBtn = menu.transform.Find("MenuBtn").gameObject;
        saveMenu = menu.transform.Find("SaveMenu").gameObject;
        loadMenu = menu.transform.Find("LoadMenu").gameObject;
        settingsMenu = menu.transform.Find("SettingsMenu").gameObject;
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
            if (!menu.activeInHierarchy) //Jika menu tidak aktif
            {
                OpenMenu();
            }
            else
            {
                if (!menuBtn.activeInHierarchy)
                {
                    Debug.Log(55);
                    BackToMenu();
                }
                else
                {
                    CloseMenu();
                }
            }
        }
    }

    public void OpenMenu()
    {
        mainView.SetActive(false);
        menu.SetActive(true);
        GameManager.Instance.timeManager.isPaused = true;
    }

    public void CloseMenu()
    {
        mainView.SetActive(true);
        menu.SetActive(false);
        GameManager.Instance.timeManager.isPaused = false;
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
}
