using UnityEngine;
[CreateAssetMenu(fileName = "PlayerVariableContainer", menuName = "PlayerVarialeContainer")]
public class PlayerVariableContainer : ScriptableObject
{
    public Rigidbody Rigidbody;
    public Transform PlayerTransform;

    public float PunchDuration;
    public float PunchStartupEnd;

    public float DodgeDuration;

    public float GrappleDuration;
    public float GrappleStartupEnd;

    public float JumpStrength;

    public float AirAttackJumpStrength;
    public float AirAttackEndDuration;
    public float AirAttackTimeBeforeSlamDown;
    public float AirAttackDownSpeed;

    public float MoveSpeed;
    public float MaxMoveSpeed;
    public float RotateSpeed;

    public float GroundDrag;
    public float AirDrag;
}
