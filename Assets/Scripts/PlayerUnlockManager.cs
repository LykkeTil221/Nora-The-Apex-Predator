using UnityEngine;

public class PlayerUnlockManager : MonoBehaviour
{
    [SerializeField] private PlayerStateManager Player;
    public int HealthEssenceAmount;
    public int EnergyEssenseAmount;
    [SerializeField] UIHeartManager uiHeartManager;
    public bool unlockedFireBall;
    public bool unlockedSolarPulse;
    public void CollectEssence(bool isHealthEssense, int collectedEssense)
    {
        if (isHealthEssense)
        {
            HealthEssenceAmount += collectedEssense;
            if(HealthEssenceAmount >= Player.PlayerVars.HealthEssenceValue)
            {
                HealthEssenceAmount -= Player.PlayerVars.HealthEssenceValue;
                UnlockNewHeart();
            }
            Debug.Log("Current Health essense = " + HealthEssenceAmount);
        }
        else
        {
            EnergyEssenseAmount += collectedEssense;
            if(EnergyEssenseAmount >= Player.PlayerVars.EnergyEssenceValue)
            {
                EnergyEssenseAmount -= Player.PlayerVars.EnergyEssenceValue;
                UnlockMoreEnergy();
            }
        }
    }
    public void UnlockMoreEnergy()
    {
        Player.energy.ExtraEnergy += Player.PlayerVars.ExtraEnergyPerUpgrade;
        Player.energy.SetMaxEnergy();
    }
    public void UnlockNewHeart()
    {
        Player.extraHearts += 1;
        Player.SetMaxHealth();
        uiHeartManager.DrawHearts();
        uiHeartManager.UpdateHearts();
    }

    public void UnlockSolarPulse()
    {
        unlockedSolarPulse = true;
        Player.currentLeftSpecial = Player.solarPulseState;
    }

    public void UnlockFireBall()
    {
        Player.currentRightSpecial = Player.fireBallState;
        unlockedFireBall = true;
    }
}
