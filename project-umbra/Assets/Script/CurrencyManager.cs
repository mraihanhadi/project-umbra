using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrencyManager : MonoBehaviour
{
    public int divinePower = 0;
    public int faith = 100;
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI faithText;

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
        GameObject foundDivinePower = GameObject.Find("DivinePower");
        GameObject foundFaith = GameObject.Find("Faith");
        if (foundDivinePower != null && foundFaith != null)
        {
            currencyText = foundDivinePower.GetComponent<TextMeshProUGUI>();
            faithText = foundFaith.GetComponent<TextMeshProUGUI>();
            UpdateText();
        }
        else
        {
            Debug.LogWarning("Currency text or faith text not found in this scene!");
            currencyText = null;
            faithText = null;
        }
    }

    public void IncreaseDivinePower()
    {
        divinePower += faith;
        UpdateText();
    }
    public void DecreaseDivinePower(int amount)
    {
        divinePower -= amount;
    }
    public void IncreaseFaith(int amount)
    {
        if (faith + amount > 100)
        {
            faith = 100;
        }
        else
        {
            faith += amount;
        }
        UpdateText();
    }
    public void DecreaseFaith(int amount)
    {
        if (faith - amount < 0)
        {
            faith = 0;
        }
        else
        {
            faith -= amount;
        }
        UpdateText();
    }
    public void UpdateText()
    {
        currencyText.text = "" + divinePower;
        faithText.text = faith+"%";
    }
}
