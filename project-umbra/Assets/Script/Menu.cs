using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public GameObject menu;
    public GameObject mainView;

    void Start()
    {
        mainView.SetActive(true);
        menu.SetActive(false);
    }

    public void openMenu()
    {
        mainView.SetActive(false);
        menu.SetActive(true);
    }

    public void closeMenu()
    {
        mainView.SetActive(true);
        menu.SetActive(false);
    }
}
