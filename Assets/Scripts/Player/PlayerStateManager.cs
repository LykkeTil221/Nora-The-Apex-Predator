using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerVariableContainer PlayerVars;

    public Vector3 MoveVector;

    PlayerBaseState currentState;
    public PlayerGroundedState groundedState = new PlayerGroundedState();
    public PlayerAirborneState airborneState = new PlayerAirborneState();
    public PlayerDodgeState dodgeState = new PlayerDodgeState();
    public PlayerAttackState attackState = new PlayerAttackState();
    public PlayerGrappleState grappleState = new PlayerGrappleState();
    public PlayerAttackAirState airAttackState = new PlayerAttackAirState();
    public Rigidbody Rigidbody;
    public bool IsGrounded = true;

    private void Start()
    {
        PlayerVars.PlayerTransform = transform;
        print("GroundedState");
        currentState = groundedState;

        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        MoveVector = context.ReadValue<Vector2>();
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void SwitchToNeutralState()
    {
        if (IsGrounded)
        {
            SwitchState(groundedState);
        }
        else
        {
            SwitchState(airborneState);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollissionEnter(this,collision);
    }

    public  void Jump(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Jump Input");
        currentState.Jump(this);
    }
    public void Dodge(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Dodge input");
        currentState.Dodge(this);
    }
    public void LeftPunch(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Left Punch Input");
        currentState.LeftPunch(this);
    }
    public void RightPunch(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Right Punch Input");
        currentState.RightPunch(this);
    }
    public void LeftSpecial(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("LeftSpecial input");
        currentState.LeftPunch(this);
    }
    public void RightSpecial(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Right Special input");
        currentState.RightSpecial(this);
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Interact Input");
        currentState.Interact(this);
    }
    public void Cancel(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Cancel Input");
        currentState.Cancel(this);
    }
}
