using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JobChoser
{
    public static JobData AssignJob(CharacterData data, AlignmentType alignment, 
                                    bool heroExists, bool dreadPrinceExists)
    {
        List<(JobData job, int weight)> validChances = new List<(JobData, int)>();

        foreach (var jc in data.possibleJob)
        {
            if (jc.alignment != alignment) continue;

            if (jc.condition == JobConditionType.ForceIfNoDreadPrince && !dreadPrinceExists)
            {
                return jc.job;
            }

            if (jc.condition == JobConditionType.ForceIfNoHero && !heroExists)
            {
                return jc.job;
            }

            int finalChance = jc.baseChance;
            switch (jc.condition)
            {
                case JobConditionType.IfHeroExists:
                    if (heroExists) finalChance += jc.conditionBonus;
                    break;
                case JobConditionType.IfNoHero:
                    if (!heroExists) finalChance += jc.conditionBonus;
                    break;
                case JobConditionType.IfDreadPrinceExists:
                    if (dreadPrinceExists) finalChance += jc.conditionBonus;
                    break;
                case JobConditionType.IfNoDreadPrince:
                    if (!dreadPrinceExists) finalChance += jc.conditionBonus;
                    break;
            }

            if (finalChance > 0)
                validChances.Add((jc.job, finalChance));
        }
        
        int totalWeight = validChances.Sum(x => x.weight);
        int roll = Random.Range(0, totalWeight);
        foreach (var entry in validChances)
        {
            if (roll < entry.weight) return entry.job;
            roll -= entry.weight;
        }

        return null;
    }
}
