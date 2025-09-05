using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityManager : MonoBehaviour
{
    private string clcikedCity;
    public Sprite[] cityImage;
    public GameObject city;
    public SpriteRenderer currentCityImg;
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
        GameObject foundCity = GameObject.Find("City");
        if (foundCity != null)
        {
            city = foundCity;
            currentCityImg = city.GetComponent<SpriteRenderer>();
            UpdateCity();
        }
        else
        {
            Debug.LogWarning("Map Not Found");
            city = null;
        }
    }

    void UpdateCity()
    {
        currentCityImg.sprite = FindSprite(clcikedCity);
        if (currentCityImg.sprite != null)
        {
            Debug.Log("Tidak Ada Sprite");
        }
    }

    public void SetClickedCity(string city)
    {
        clcikedCity = city;
    }

    Sprite FindSprite(string name)
    {
        string target = name.Replace(" ", "").ToLower() + "_0";
        foreach (var sprite in cityImage)
        {
            if (sprite != null && sprite.name.Replace(" ", "").ToLower() == target)
            {
                return sprite;
            }
        }
        return null;
    }
}
