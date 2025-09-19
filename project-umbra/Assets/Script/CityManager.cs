using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class CityData
{
    public string cityName;
    public List<CharacterInstance> residents = new List<CharacterInstance>();
    public float hope;
    public float dread;
}

public class CityManager : MonoBehaviour
{
    public List<CityData> allCities = new List<CityData>(10);
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

    public void AddCharacterToCity(string cityName, CharacterInstance character)
    {
        string target = cityName.Replace(" ", "").ToLower();
        CityData cityData = allCities.Find(c => c.cityName.Replace(" ", "").ToLower() == target);
        if (cityData == null)
        {
            Debug.LogWarning($"City {cityName} not found in CityManager!");
            return;
        }
        cityData.residents.Add(character);
        Debug.Log($"Character {character.Name} added to {cityData.cityName}");
    }
}
