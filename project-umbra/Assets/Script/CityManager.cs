using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject chosenList;
    public GameObject chosenContent;
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
        var allObjs = Resources.FindObjectsOfTypeAll<GameObject>();
        GameObject foundList = allObjs.FirstOrDefault(go => go.name == "ChosenList");
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
        if (foundList != null)
        {
            chosenList = foundList;
            UpdateList();
        }
        else
        {
            Debug.LogWarning("Chosen List not found");
        }
    }

    void UpdateCity()
    {
        currentCityImg.sprite = FindSprite(clcikedCity);
        if (currentCityImg.sprite == null)
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
        string target = name.Replace(" ", "").ToLower();
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
        character.SetCurrentLocation(cityName);
        Debug.Log($"Character {character.Name} added to {cityData.cityName}");
    }

    public void UpdateList()
    {
        Transform contentParent = Resources.FindObjectsOfTypeAll<Transform>()
            .FirstOrDefault(t => t.name == "Content");
        if (contentParent == null)
        {
            Debug.LogWarning("Content container not found!");
            return;
        }

        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        var characters = GameManager.Instance.characterManager.sentChosenInstance;

        foreach (var ch in characters)
        {
            GameObject entry = Instantiate(chosenContent, contentParent);
            entry.transform.localScale = Vector3.one;

            var headshotImg = entry.transform.Find("Headshot")?.GetComponent<Image>();
            var nameText = entry.transform.Find("Name")?.GetComponent<TextMeshProUGUI>();
            var locText = entry.transform.Find("Location")?.GetComponent<TextMeshProUGUI>();
            var viewBtn = entry.transform.Find("View")?.GetComponent<Button>();

            if (headshotImg != null) headshotImg.sprite = ch.Headshot;
            if (nameText != null) nameText.text = ch.Name;
            if (locText != null) locText.text = ch.CurrentLocation;

            if (viewBtn != null)
            {
                viewBtn.onClick.RemoveAllListeners();
                viewBtn.onClick.AddListener(() =>
                {
                    Debug.Log($"View {ch.Name} in {ch.CurrentLocation}");
                });
            }
        }
    }
}
