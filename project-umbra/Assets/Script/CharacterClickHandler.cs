using UnityEngine;

public class CharacterClickHandler : MonoBehaviour
{
    public CharacterData characterData;
    public CharacterProfile profile;
    public GameObject profileUI;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = characterData.characterSprite;
    }
    private void OnMouseDown()
    {
        profileUI.SetActive(true);
        CharacterInstance characterInstance = new CharacterInstance(characterData);
        profile.DisplayCharacter(characterInstance);
    }
}
