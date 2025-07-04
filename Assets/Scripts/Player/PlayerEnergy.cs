using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] private PlayerVariableContainer PlayerStats;
    [SerializeField] private float MaxPlayerEnergy;
    [SerializeField] public float CurrentPlayerEnergy;
    float timer;
    private void Start()
    {
        MaxPlayerEnergy = PlayerStats.PlayerEnergy;
        CurrentPlayerEnergy = MaxPlayerEnergy;
    }
    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        if (timer <= 0 && CurrentPlayerEnergy < MaxPlayerEnergy) CurrentPlayerEnergy += PlayerStats.PlayerEnergyGainMMultiplier * Time.deltaTime;
        if(CurrentPlayerEnergy > MaxPlayerEnergy) CurrentPlayerEnergy = MaxPlayerEnergy;
    }
    public void SpendEnergy(float spentEnergy)
    {
        CurrentPlayerEnergy -= spentEnergy;
        timer = PlayerStats.TimeUntilEnergyRecovery;
    }

    public void GainEnergy(float GainedEnergy)
    {
        CurrentPlayerEnergy += GainedEnergy;
        if (CurrentPlayerEnergy > MaxPlayerEnergy) CurrentPlayerEnergy = MaxPlayerEnergy;
        timer = 0;
    }

    public void MaxGainEnergy()
    {
        CurrentPlayerEnergy = MaxPlayerEnergy;
        timer = 0;
    }
}
