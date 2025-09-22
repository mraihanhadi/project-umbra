using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class CharacterInstance
{
    public CharacterData baseData;
    public float intelligence;
    public float strength;
    public float charm;
    public float luck;
    public AlignmentType alignment;
    [SerializeField] private string currentLocation;
    public CharacterInstance(CharacterData baseData)
    {
        this.baseData = baseData;

        intelligence = baseData.intelligence.GetRandomValue();
        strength = baseData.strength.GetRandomValue();
        charm = baseData.charm.GetRandomValue();
        luck = baseData.luck.GetRandomValue();

        int roll = UnityEngine.Random.Range(0, 100);
        alignment = roll < baseData.goodAlignmentChance ? AlignmentType.Good : AlignmentType.Evil;
    }

    public string Name => baseData.chosenName;
    public Sprite Sprite => baseData.characterSprite;
    public Rarity Rarity => baseData.rarity;
    public string Special => baseData.specialCharacteristic;
    public string Gender => baseData.Gender;
    public string CurrentLocation => currentLocation;
    public List<string> triggeredEventIDs = new List<string>();
    public JobData assignedJob;
    public void SetCurrentLocation(string location)
    {
        currentLocation = location;
    }
}
