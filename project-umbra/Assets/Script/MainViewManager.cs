using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class MainViewManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject mainView;
    public GameObject eventPanel;
    public RectTransform dunia1;
    public RectTransform dunia2;
    public TextMeshProUGUI namaPlanet;
    public Button visitBtn;
    public Image visitImg;
    public GameObject debugPanel;

    GameObject menuBtn;
    GameObject saveMenu;
    GameObject loadMenu;
    GameObject settingsMenu;
    private float dunia1Origin;
    private float dunia2Origin;
    private bool isDunia1;
    private const float transitionTime = .75f;
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
        dunia1Origin = dunia1.anchoredPosition.x;
        dunia2Origin = dunia2.anchoredPosition.x;
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

        if (Input.GetKeyDown(KeyCode.F7))
        {
            if (!debugPanel.activeInHierarchy)
            {
                OpenDebugPanel();
            }
        }
    }

    public void OpenMenu()
    {
        mainView.SetActive(false);
        menu.SetActive(true);
        GameManager.Instance.timeManager.PauseTime();
    }

    public void CloseMenu()
    {
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

    public void VisitWorld()
    {
        GameManager.Instance.timeManager.PauseTime();
        if (isDunia1)
        {
            SceneManager.LoadSceneAsync("Dunia1");
        }
        else
        {
            SceneManager.LoadSceneAsync("Dunia2");
        }
    }

    public void FastForward()
    {
        GameManager.Instance.timeManager.FastForwardTime();
    }

    public void Dunia1Clicked()
    {
        dunia2.DOAnchorPosX(1200, 0.8f).SetEase(Ease.InOutQuart);
        Sequence seq = DOTween.Sequence();
        seq.Append(dunia1.DOAnchorPosX(0, transitionTime).SetEase(Ease.InOutQuart));
        seq.Append(dunia1.DOSizeDelta(new Vector2(400f, 80f), transitionTime).SetEase(Ease.InOutQuart));
        namaPlanet.text = "EARTH";
        seq.Append(namaPlanet.DOFade(1f, 1f));
        seq.Append(visitImg.DOFade(1f, 1f));
        seq.OnComplete(() =>
        {
            visitBtn.interactable = true;
        });
        isDunia1 = true;
    }
    public void Dunia2Clicked()
    {
        dunia1.DOAnchorPosX(-1200, .8f).SetEase(Ease.InOutQuart);
        Sequence seq = DOTween.Sequence();
        seq.Append(dunia2.DOAnchorPosX(0, transitionTime).SetEase(Ease.InOutQuart));
        seq.Append(dunia2.DOSizeDelta(new Vector2(400f, 80f), transitionTime).SetEase(Ease.InOutQuart));
        namaPlanet.text = "THE MYTHTERRA";
        seq.Append(namaPlanet.DOFade(1f, 1f));
        seq.Append(visitImg.DOFade(1f, 1f));
        seq.OnComplete(() =>
        {
            visitBtn.interactable = true;
        });
        isDunia1 = false;
    }
    public void GoBack()
    {
        if (isDunia1)
        {
            namaPlanet.DOFade(0f, 0.3f);
            dunia1.DOSizeDelta(new Vector2(250f, 50f), 1f).SetEase(Ease.InOutQuart);
            Sequence seq = DOTween.Sequence();
            seq.Append(dunia1.DOAnchorPosX(dunia1Origin, 1f).SetEase(Ease.InOutQuart));
            dunia2.DOAnchorPosX(dunia2Origin, 1f).SetEase(Ease.InOutQuart);
        }
        else
        {
            namaPlanet.DOFade(0f, 0.3f);
            dunia2.DOSizeDelta(new Vector2(250f, 50f), 1f).SetEase(Ease.InOutQuart);
            Sequence seq = DOTween.Sequence();
            seq.Append(dunia2.DOAnchorPosX(dunia2Origin, 1f).SetEase(Ease.InOutQuart));
            dunia1.DOAnchorPosX(dunia1Origin, 1f).SetEase(Ease.InOutQuart);
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
}
