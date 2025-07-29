using UnityEngine;

[System.Serializable]
public class Stats
{
    public float min;
    public float max;

    public float GetRandomValue()
    {
        return Random.Range(min, max);
    }
}
