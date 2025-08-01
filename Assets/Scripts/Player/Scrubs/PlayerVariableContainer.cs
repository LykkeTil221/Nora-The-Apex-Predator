using UnityEngine;
[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/PlayerStats")]
public class PlayerVariableContainer : ScriptableObject
{
    public Rigidbody Rigidbody;

    [Header("Player Stats")]
    public float PlayerStartingHearts;
    public float HeartValue;
    public float Unstoppable;
    public float stunDuration;
    public float IFrames;
    [Header("Energy variables")]
    public float PlayerEnergy;
    public float PlayerEnergyGainMMultiplier;
    public float TimeUntilEnergyRecovery;
    public float ExtraEnergyPerUpgrade;
    [Header("Punch variables")]
    public float PunchDuration;
    public float PunchActionEnd;
    public float PunchStartupEnd;
    public float PunchForwardSpeed;
    [Header("Dodge variables")]
    public float DodgeLungeForce;
    public float DodgeActionEnd;
    public float DodgeDuration;
    public float DodgeEnergyCost;
    [Header("Grapple variables")]
    public float GrappleDuration;
    public float GrappleStartupEnd;
    public float GrappleActionEnd;
    public float GrappleIdleEnd;
    public float GrappleReturnEnd;
    public float GrappleOutSpeed;
    public float GrappleReturnSpeed;
    public float GrappleUnstoppableNegativeBonus;
    [Header("Absorb variables")]
    public float AbsorbAttackDuration;
    public float absorbedHealthDivider;
    [Header("Jump variables")]
    public float JumpStrength;
    [Header("Air attack variables")]
    public float AirAttackJumpStrength;
    public float AirAttackEndDuration;
    public float AirAttackActionEnd;
    public float AirAttackTimeBeforeSlamDown;
    public float AirAttackDownSpeed;
    [Header("Move variables")]
    public float MoveSpeed;
    public float MaxMoveSpeed;
    public float RotateSpeed;
    public float SlowingDownSpeed;
    [Header("Drag variables")]
    public float GroundDrag;
    public float AirDrag;
    [Header("Additional state based Unstoppable Values")]
    public float DodgeUnstoppable;
    [Header("EssenseValue")]
    public int HealthEssenceValue;
    public int EnergyEssenceValue;
    [Header("SolarPulseVariables")]
    public float SolarPulseDuration;
    public float SolarPulseStartupEnd;
    public float SolarPulseActionEnd;
    public float SolarPulseEnergyCost;
    [Header("FireBallVariables")]
    public float FireBallDuration;
    public float FireBallStartUpEnd;
    public float FireBallActionEnd;
    public float FireBallEnergyCost;
    public float FireBallLaunchForce;
    }
