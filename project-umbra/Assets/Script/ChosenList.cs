using UnityEngine;
using UnityEngine.UI;

public class ChosenList : MonoBehaviour
{
    [SerializeField] private Button viewBtn;
    [SerializeField] private CharacterInstance data;
    void Awake()
    {
        viewBtn.onClick.AddListener(OnViewClicked);
    }
    void OnDestroy()
    {
        viewBtn.onClick.RemoveListener(OnViewClicked);
    }

    void OnViewClicked()
    {
        GameManager.Instance.ViewChosenStats(data);
    }

    public void SetData(CharacterInstance data)
    {
        this.data = data;
    }
}
