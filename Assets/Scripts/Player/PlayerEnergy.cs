using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] private PlayerVariableContainer PlayerStats;
    [SerializeField] public float MaxPlayerEnergy;
    [SerializeField] public float ExtraEnergy;
    [SerializeField] private float Wheel1Max;
    [SerializeField] private float Wheel1Min;
    [SerializeField] private float Wheel2Max;
    [SerializeField] private float Wheel2Min;
    [SerializeField] private float Wheel3Max;
    [SerializeField] private float Wheel3Min;
    [SerializeField] public float CurrentPlayerEnergy;
    float timer;
    [SerializeField] private UIPlayerEnergy UIenergyWheel1;
    [SerializeField] public UIPlayerEnergy UIenergyWheel2;
    [SerializeField] public UIPlayerEnergy UIenergyWheel3;

    [SerializeField] private GameObject Wheel2;
    [SerializeField] private GameObject Wheel3;
    private void Awake()
    {
        SetMaxEnergy();
    }
    private void Start()
    {
        PlayerCheckPoint.maxPlayerEnergy += SetMaxEnergy;
    }
    public void SetMaxEnergy()
    {
        MaxPlayerEnergy = PlayerStats.PlayerEnergy + ExtraEnergy;
        CurrentPlayerEnergy = MaxPlayerEnergy;
        UIenergyWheel1.SetMaxEnergy(Wheel1Min, Wheel1Max);
        UIenergyWheel2.SetMaxEnergy(Wheel2Min, Wheel2Max);
        UIenergyWheel3.SetMaxEnergy(Wheel3Min, Wheel3Max);

        UIenergyWheel1.SetEnergy(CurrentPlayerEnergy);
        UIenergyWheel2.SetEnergy(CurrentPlayerEnergy);
        UIenergyWheel3.SetEnergy(CurrentPlayerEnergy);
        if (MaxPlayerEnergy <= Wheel2Min)
        {
            Wheel2.SetActive(false);
        }
        else
        {
            Wheel2.SetActive(true);
        }
        if (MaxPlayerEnergy <= Wheel3Min)
        {
            Wheel3.SetActive(false);
        }
        else
        {
            Wheel3.SetActive(false);
        }
    }
    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        if (timer <= 0 && CurrentPlayerEnergy < MaxPlayerEnergy)
        {
            CurrentPlayerEnergy += PlayerStats.PlayerEnergyGainMMultiplier * Time.deltaTime;
            UIenergyWheel1.SetEnergy(CurrentPlayerEnergy);
            UIenergyWheel2.SetEnergy(CurrentPlayerEnergy);
            UIenergyWheel3.SetEnergy(CurrentPlayerEnergy);
        }
        if (CurrentPlayerEnergy > MaxPlayerEnergy) 
        {
            CurrentPlayerEnergy = MaxPlayerEnergy;
            UIenergyWheel1.SetEnergy(CurrentPlayerEnergy);
            UIenergyWheel2.SetEnergy(CurrentPlayerEnergy);
            UIenergyWheel3.SetEnergy(CurrentPlayerEnergy);
        }
    }
    public void SpendEnergy(float spentEnergy)
    {
        CurrentPlayerEnergy -= spentEnergy;
        timer = PlayerStats.TimeUntilEnergyRecovery;
        UIenergyWheel1.SetEnergy(CurrentPlayerEnergy);
        UIenergyWheel2.SetEnergy(CurrentPlayerEnergy);
        UIenergyWheel3.SetEnergy(CurrentPlayerEnergy);
        if (CurrentPlayerEnergy < 0) CurrentPlayerEnergy = 0;
    }

    public void GainEnergy(float GainedEnergy)
    {
        if (CurrentPlayerEnergy == MaxPlayerEnergy) return;
        CurrentPlayerEnergy += GainedEnergy;
        UIenergyWheel1.SetEnergy(CurrentPlayerEnergy);
        UIenergyWheel2.SetEnergy(CurrentPlayerEnergy);
        UIenergyWheel3.SetEnergy(CurrentPlayerEnergy);
        if (CurrentPlayerEnergy > MaxPlayerEnergy)
        {
            CurrentPlayerEnergy = MaxPlayerEnergy;
            UIenergyWheel1.SetEnergy(CurrentPlayerEnergy);
            UIenergyWheel2.SetEnergy(CurrentPlayerEnergy);
            UIenergyWheel3.SetEnergy(CurrentPlayerEnergy);
        }
        timer = 0;
    }

    public void MaxGainEnergy()
    {
        if (CurrentPlayerEnergy == MaxPlayerEnergy) return;
        CurrentPlayerEnergy = MaxPlayerEnergy;
        timer = 0;
        UIenergyWheel1.SetEnergy(CurrentPlayerEnergy);
        UIenergyWheel2.SetEnergy(CurrentPlayerEnergy);
        UIenergyWheel3.SetEnergy(CurrentPlayerEnergy);
    }
}
