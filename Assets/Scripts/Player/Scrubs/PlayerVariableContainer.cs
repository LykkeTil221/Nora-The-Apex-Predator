using UnityEngine;
[CreateAssetMenu(fileName = "PlayerVariableContainer", menuName = "PlayerVarialeContainer")]
public class PlayerVariableContainer : ScriptableObject
{
    public Rigidbody Rigidbody;
    public Transform PlayerTransform;

    public float PunchDuration;
    public float PunchActionEnd;
    public float PunchStartupEnd;
    public int PunchDamage;

    public float DodgeLungeForce;
    public float DodgeActionEnd;
    public float DodgeDuration;

    public float GrappleDuration;
    public float GrappleStartupEnd;
    public float GrappleActionEnd;

    public float JumpStrength;

    public float AirAttackJumpStrength;
    public float AirAttackEndDuration;
    public float AirAttackTimeBeforeSlamDown;
    public float AirAttackDownSpeed;
    public int AirAttackDamage;

    public float MoveSpeed;
    public float MaxMoveSpeed;
    public float RotateSpeed;
    public float SlowingDownSpeed;

    public float GroundDrag;
    public float AirDrag;

    public float AttackForwardSpeed;
}
