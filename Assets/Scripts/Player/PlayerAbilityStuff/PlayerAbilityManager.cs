using UnityEngine;
using System.Collections.Generic;
public class PlayerAbilityManager : MonoBehaviour
{
    public List<MUnlockData> unlockedMutations;

    public void AddMutation(MUnlockData absorbedMutation)
    {
        if (unlockedMutations.Contains(absorbedMutation)) return;
        unlockedMutations.Add(absorbedMutation);
    }
}
