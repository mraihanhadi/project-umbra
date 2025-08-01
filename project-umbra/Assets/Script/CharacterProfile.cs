using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class CharacterProfile : MonoBehaviour
{
    public Image npcImage;
    public TextMeshProUGUI infoText;
    private CharacterInstance currentInstance;
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
        if (currentInstance != null)
        {
            GameManager.Instance.characterManager.AddChosen(currentInstance);
            Debug.Log($"Sent character: {currentInstance} to CharacterManager");
        }
        SceneManager.LoadSceneAsync(1);
    }

    public void GoBack()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
