using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class EarthManager : MonoBehaviour
{
    public Image npcImage;
    public TextMeshProUGUI infoText;
    public int divinePowerCost = 100;
    private CharacterInstance currentInstance;
    private GameManager gameManagerInstance;

    void Start()
    {
        gameManagerInstance = GameManager.Instance;
    }
    public void DisplayCharacter(CharacterInstance character)
    {
        currentInstance = character;
        npcImage.sprite = character.Sprite;

        infoText.text =
            $"Name: {character.Name}\n" +
            $"Gender: {character.Gender}\n" +
            $"Type: {character.Rarity}\n" +
            $"Alignment: {character.alignment}\n" +
            $"Intelligence: {character.intelligence:F0}\n" +
            $"Strength: {character.strength:F0}\n" +
            $"Charm: {character.charm:F0}\n" +
            $"Luck: {character.luck:F0}\n" +
            $"Special Characteristic: {character.Special}";
    }

    public void SendCharacter()
    {
        if (gameManagerInstance.currencyManager.divinePower >= divinePowerCost)
        {
            gameManagerInstance.currencyManager.DecreaseDivinePower(divinePowerCost);
            if (currentInstance != null)
            {
                GameManager.Instance.characterManager.AddChosen(currentInstance);
                Debug.Log($"Sent character: {currentInstance} to CharacterManager");
            }
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
            Debug.Log("Tidak cukup");
        } 
    }

    public void GoBack()
    {
        GameManager.Instance.timeManager.isPaused = false;
        SceneManager.LoadSceneAsync(1);
    }
}
