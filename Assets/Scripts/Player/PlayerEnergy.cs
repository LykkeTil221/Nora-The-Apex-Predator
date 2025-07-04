using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] private PlayerVariableContainer PlayerStats;
    [SerializeField] private float MaxPlayerEnergy;
    [SerializeField] public float CurrentPlayerEnergy;
    float timer;
    [SerializeField] private UIPlayerEnergy UIenergy;
    private void Start()
    {
        MaxPlayerEnergy = PlayerStats.PlayerEnergy;
        CurrentPlayerEnergy = MaxPlayerEnergy;
        UIenergy.SetMaxEnergy(MaxPlayerEnergy);
    }
    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        if (timer <= 0 && CurrentPlayerEnergy < MaxPlayerEnergy)
        {
            CurrentPlayerEnergy += PlayerStats.PlayerEnergyGainMMultiplier * Time.deltaTime;
            UIenergy.SetEnergy(CurrentPlayerEnergy);
        }
        if (CurrentPlayerEnergy > MaxPlayerEnergy) 
        {
            CurrentPlayerEnergy = MaxPlayerEnergy;
            UIenergy.SetEnergy(UIenergy.Slider.maxValue);
        }
    }
    public void SpendEnergy(float spentEnergy)
    {
        CurrentPlayerEnergy -= spentEnergy;
        timer = PlayerStats.TimeUntilEnergyRecovery;
        UIenergy.SetEnergy(CurrentPlayerEnergy);
        if(CurrentPlayerEnergy < 0) CurrentPlayerEnergy = 0;
    }

    public void GainEnergy(float GainedEnergy)
    {
        if (CurrentPlayerEnergy == MaxPlayerEnergy) return;
        CurrentPlayerEnergy += GainedEnergy;
        UIenergy.SetEnergy(CurrentPlayerEnergy);
        if (CurrentPlayerEnergy > MaxPlayerEnergy)
        {
            CurrentPlayerEnergy = MaxPlayerEnergy;
            UIenergy.SetEnergy(UIenergy.Slider.maxValue);
        }
        timer = 0;
    }

    public void MaxGainEnergy()
    {
        if (CurrentPlayerEnergy == MaxPlayerEnergy) return;
        CurrentPlayerEnergy = MaxPlayerEnergy;
        timer = 0;
        UIenergy.SetEnergy(UIenergy.Slider.maxValue);
    }
}
