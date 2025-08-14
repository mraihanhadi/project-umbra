using Microsoft.Unity.VisualStudio.Editor;
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
    }
    public void Dunia2Clicked()
    {
        dunia1.DOAnchorPosX(-1200, 1f).SetEase(Ease.InOutQuart);
        Sequence seq = DOTween.Sequence();
        seq.Append(dunia2.DOAnchorPosX(0, 1f).SetEase(Ease.InOutQuart));
        seq.Append(dunia2.DOSizeDelta(new Vector2(400f, 80f), 1f).SetEase(Ease.InOutQuart));
        namaPlanet.text = "THE MYTHTERRA";
        seq.Append(namaPlanet.DOFade(1f, 1f));
    }
}
