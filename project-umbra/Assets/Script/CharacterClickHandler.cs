using UnityEngine;

public class CharacterClickHandler : MonoBehaviour
{
    public CharacterData minatoData;
    public CharacterProfile profile;
    public GameObject profileUI;

    public void showProfile()
    {
        profileUI.SetActive(true);
        CharacterInstance characterInstance = new CharacterInstance(minatoData);
        profile.DisplayCharacter(characterInstance);
    }
}
