using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public List<CharacterData> sentChosen = new List<CharacterData>();
    public List<CharacterInstance> sentChosenInstance = new List<CharacterInstance>();

    public void AddChosen(CharacterInstance instance)
    {
        if (!sentChosen.Any(c => c.chosenName == instance.Name))
        {
            sentChosen.Add(instance.baseData);
            sentChosenInstance.Add(instance);
        }
    }

    public bool IsChosenSent(string name)
    {
        return sentChosen.Any(c => c.chosenName == name);
    }
}
