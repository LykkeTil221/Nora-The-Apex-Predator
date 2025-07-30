using UnityEngine;
using TMPro;
public class PlayerUnlockManager : MonoBehaviour
{
    [SerializeField] private PlayerStateManager Player;
    private int EssenceAmount;
    private int CrystalAmount;
    [SerializeField] private TextMeshProUGUI EssenceText;
    [SerializeField] private TextMeshProUGUI CrystalText;
    [SerializeField] UIHeartManager uiHeartManager;
    public bool unlockedFireBall;
    public bool unlockedSolarPulse;

    public delegate void UnlockMutationScreen(int number);
    public static UnlockMutationScreen UnlockMuationScreenActivate;
    public void CollectEssence( int collectedEssense)
    {
       EssenceAmount += collectedEssense;
        EssenceText.text = EssenceAmount.ToString();
    }

    public void CollectCrystal(int collectedCrystal)
    {
        CrystalAmount += collectedCrystal;
        CrystalText.text = CrystalAmount.ToString();
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
        if (unlockedSolarPulse) return;
        unlockedSolarPulse = true;
        Player.currentLeftSpecial = Player.solarPulseState;
        UnlockMuationScreenActivate.Invoke(0);
    }

    public void UnlockFireBall()
    {
        if(unlockedFireBall) return;
        Player.currentRightSpecial = Player.fireBallState;
        unlockedFireBall = true;
        UnlockMuationScreenActivate.Invoke(1);
    }
}
