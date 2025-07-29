using UnityEngine;

public enum AlignmentType
{
    Good,
    Evil
}

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Characters/Character Data")]
public class CharacterData : ScriptableObject
{
    public string chosenName;
    public string Gender;
    public string rarity;
    public int goodAlignmentChance = 50; //example: means 50% good
    public Stats intelligence;
    public Stats strength;
    public Stats charm;
    public Stats luck;
    public string specialCharacteristic;
    public Sprite characterSprite;
}
