using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MytherraManager : MonoBehaviour
{
    public GameObject scrollMenuUI;
    GameObject opener;
    [SerializeField]
    private string cityName;

    public void VisitCity(string city)
    {
        cityName = city;
        GameManager.Instance.cityManager.SetClickedCity(cityName);
        SceneManager.LoadSceneAsync("Map");
    }

    public void OpenScrollMenuUI()
    {
        opener = EventSystem.current ? EventSystem.current.currentSelectedGameObject : null;
        if (opener) opener.SetActive(false);
        scrollMenuUI.SetActive(true);
    }

    public void CloseScrollMenuUI()
    {
        scrollMenuUI.SetActive(false);
        if (opener) opener.SetActive(true);
        opener = null;
    }

    public void GoBackMainView()
    {
        SceneManager.LoadSceneAsync("Main_View");
    }

}
