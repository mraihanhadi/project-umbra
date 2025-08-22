using UnityEngine;
using DG.Tweening;
using TMPro;

public class ClickedPlanet : MonoBehaviour
{
    public RectTransform dunia1;
    public RectTransform dunia2;
    public TextMeshProUGUI namaPlanet;
    private float dunia1Origin;
    private float dunia2Origin;
    private bool isDunia1;
    public void Start()
    {
        dunia1Origin = dunia1.anchoredPosition.x;
        dunia2Origin = dunia2.anchoredPosition.x;
    }
    public void Dunia1Clicked()
    {
        dunia2.DOAnchorPosX(1200, 1f).SetEase(Ease.InOutQuart);
        Sequence seq = DOTween.Sequence();
        seq.Append(dunia1.DOAnchorPosX(0, 1f).SetEase(Ease.InOutQuart));
        seq.Append(dunia1.DOSizeDelta(new Vector2(400f, 80f), 1f).SetEase(Ease.InOutQuart));
        namaPlanet.text = "EARTH";
        seq.Append(namaPlanet.DOFade(1f, 1f));
        isDunia1 = true;
    }
    public void Dunia2Clicked()
    {
        dunia1.DOAnchorPosX(-1200, 1f).SetEase(Ease.InOutQuart);
        Sequence seq = DOTween.Sequence();
        seq.Append(dunia2.DOAnchorPosX(0, 1f).SetEase(Ease.InOutQuart));
        seq.Append(dunia2.DOSizeDelta(new Vector2(400f, 80f), 1f).SetEase(Ease.InOutQuart));
        namaPlanet.text = "THE MYTHTERRA";
        seq.Append(namaPlanet.DOFade(1f, 1f));
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
}
