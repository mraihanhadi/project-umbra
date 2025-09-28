using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MytherraManager : MonoBehaviour
{
    [SerializeField]
    private string cityName;

    public void VisitCity(string city)
    {
        cityName = city;
        GameManager.Instance.cityManager.SetClickedCity(cityName);
        SceneManager.LoadSceneAsync("Map");
    }
    public void GoBackMainView()
    {
        SceneManager.LoadSceneAsync("Main_View");
    }

}
