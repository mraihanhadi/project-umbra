using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public List<CharacterInstance> allChosen = new List<CharacterInstance>();

    public void AddChosen(CharacterData baseData)
    {
        CharacterInstance newChosen = new CharacterInstance(baseData);
        allChosen.Add(newChosen);
    }
}
