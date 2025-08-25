using UnityEngine;

public enum Jobs
{
    None,
    Courier,
    Merchant,
    BladeForHire,
    Spy,
    Chef,
    Advisor,
    Hero,
    Charlatan,
    Witch,
    DreadPrince
}

[CreateAssetMenu(fileName = "NewEvent", menuName = "Event/Event Data")]
public class EventData : ScriptableObject
{
    public string IDEvent;
    public string namaEvent;
    public string jenisEvent;
    [Header("Jobs Requirement")]
    public Jobs jobRequirement;
    [Header("Minimal Attributes")]
    public int yearInMarblesMin;
    public float intelligenceMin;
    public float strengthMin;
    public float charmMin;
    public float luckMin;
    [Header("Chance (%) Per Month")]
    public float goodAligned;
    public float evilAligned;
    [Header("Reward")]
    public float intelligenceReward;
    public float strengthReward;
    public float charmReward;
    public float luckReward;
    [Header("Punishment")]
    public float intelligencePunishment;
    public float strengthPunishment;
    public float charmPunishment;
    public float luckPunishment;
    [Header("Encounter Hidden Attribute")]
    public float intelligenceHidden;
    public float strengthHidden;
    public float charmHidden;
    public float luckHidden;
    [Header("Outcome Description")]
    public string winDescription;
    public string loseDescription;
    [Space]
    public bool repeatable;
}
