using UnityEngine;
[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/PlayerStats")]
public class PlayerVariableContainer : ScriptableObject
{
    public Rigidbody Rigidbody;

    [Header("Player Stats")]
    public float PlayerHealth;
    public float PlayerEnergy;
    public float Unstoppable;
    public float stunDuration;
    public float IFrames;
    [Header("Punch variables")]
    public float PunchDuration;
    public float PunchActionEnd;
    public float PunchStartupEnd;
    public float PunchForwardSpeed;
    [Header("Dodge variables")]
    public float DodgeLungeForce;
    public float DodgeActionEnd;
    public float DodgeDuration;
    public float EnergyCost;
    [Header("Grapple variables")]
    public float GrappleDuration;
    public float GrappleStartupEnd;
    public float GrappleActionEnd;
    public float GrappleIdleEnd;
    public float GrappleReturnEnd;
    public float GrappleOutSpeed;
    public float GrappleReturnSpeed;
    [Header("Absorb variables")]
    public float AbsorbAttackDuration;
    [Header("Jump variables")]
    public float JumpStrength;
    [Header("Air attack variables")]
    public float AirAttackJumpStrength;
    public float AirAttackEndDuration;
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

    
}
