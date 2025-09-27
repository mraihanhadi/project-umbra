using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class MainViewManager : MonoBehaviour
{
    public GameObject mainView;
    public Button dunia1Btn;
    public Button dunia2Btn;
    public RectTransform dunia1;
    public RectTransform dunia2;
    public TextMeshProUGUI namaPlanet;
    public Button visitBtn;
    public Button goBackBtn;
    public Image visitImg;
    public Image goBackImg;
    private float dunia1Origin;
    private float dunia2Origin;
    private bool isDunia1;
    private const float transitionTime = .75f;
    void Start()
    {
        dunia1Origin = dunia1.anchoredPosition.x;
        dunia2Origin = dunia2.anchoredPosition.x;
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
        dunia1Btn.interactable = false;
        dunia2Btn.interactable = false;
        dunia2.DOAnchorPosX(1200, 0.8f).SetEase(Ease.InOutQuart);
        Sequence seq = DOTween.Sequence();
        seq.Append(dunia1.DOAnchorPosX(0, transitionTime).SetEase(Ease.InOutQuart));
        seq.Append(dunia1.DOSizeDelta(new Vector2(400f, 80f), transitionTime).SetEase(Ease.InOutQuart));
        namaPlanet.text = "EARTH";
        seq.Append(namaPlanet.DOFade(1f, 1f));
        seq.Append(visitImg.DOFade(1f, 1f));
        seq.Append(goBackImg.DOFade(1f, 1f));
        seq.OnComplete(() =>
        {
            visitBtn.interactable = true;
            goBackBtn.interactable = true;
        });
        isDunia1 = true;
    }
    public void Dunia2Clicked()
    {
        dunia1Btn.interactable = false;
        dunia2Btn.interactable = false;
        dunia1.DOAnchorPosX(-1200, .8f).SetEase(Ease.InOutQuart);
        Sequence seq = DOTween.Sequence();
        seq.Append(dunia2.DOAnchorPosX(0, transitionTime).SetEase(Ease.InOutQuart));
        seq.Append(dunia2.DOSizeDelta(new Vector2(400f, 80f), transitionTime).SetEase(Ease.InOutQuart));
        namaPlanet.text = "THE MYTHTERRA";
        seq.Append(namaPlanet.DOFade(1f, 1f));
        seq.Append(visitImg.DOFade(1f, 1f));
        seq.Append(goBackImg.DOFade(1f, 1f));
        seq.OnComplete(() =>
        {
            visitBtn.interactable = true;
            goBackBtn.interactable = true;
        });
        isDunia1 = false;
    }
    public void GoBack()
    {
        visitBtn.interactable = false;
        goBackBtn.interactable = false;
        visitImg.DOFade(0f, 1f);
        goBackImg.DOFade(0f, 1f);
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
            seq.OnComplete(() =>
            {
                visitBtn.interactable = false;
                goBackBtn.interactable = false;
            });
        }
        dunia1Btn.interactable = true;
        dunia2Btn.interactable = true;
    }
    public void SetActiveMainView(bool value)
    {
        mainView.SetActive(value);
    }
}
