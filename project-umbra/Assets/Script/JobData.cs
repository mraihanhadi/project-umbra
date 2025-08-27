using UnityEngine;

public enum AlignmentPrequisites
{
    None,
    Good,
    Evil
}

[CreateAssetMenu(fileName = "NewJob", menuName = "Job/Job Data")]
public class JobData : ScriptableObject
{
    public string jobId;
    public string jobName;
    public AlignmentPrequisites alignmentPrequisites;
    [Header("Stats Addition")]
    public float intelligence;
    public float strength;
    public float charisma;
    public float luck;
    [Space]
    public bool multipleChosen;

}
