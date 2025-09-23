using System;
using UnityEngine;

public enum JobConditionType
{
    None,
    IfHeroExists,
    IfNoHero,
    IfDreadPrinceExists,
    IfNoDreadPrince,
    ForceIfNoDreadPrince,
    ForceIfNoHero
}

public enum AlignmentType
{
    Good,
    Evil
}

public enum Rarity
{
    Common,
    Rare
}

[System.Serializable]
public class JobChance
{
    public JobData job;
    public int baseChance;
    public AlignmentType alignment;
    public JobConditionType condition;
    public int conditionBonus;
}

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Characters/Character Data")]
public class CharacterData : ScriptableObject
{
    public string chosenName;
    public string Gender;
    public Rarity rarity;
    public int goodAlignmentChance = 50; //example: means 50% good
    public Stats intelligence;
    public Stats strength;
    public Stats charm;
    public Stats luck;
    public JobChance[] possibleJob;
    public JobData chosenJob;
    public string specialCharacteristic;
    public Sprite characterSprite;
    public Sprite headshot;
}
