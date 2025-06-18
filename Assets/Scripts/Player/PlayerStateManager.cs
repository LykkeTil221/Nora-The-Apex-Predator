using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerGroundedState groundedState = new PlayerGroundedState();
    public PlayerAirborneState airborneState = new PlayerAirborneState();
    public PlayerDodgeState dodgeState = new PlayerDodgeState();
    public PlayerAttackState attackState = new PlayerAttackState();
    public PlayerGrappleState grappleState = new PlayerGrappleState();

    private void Start()
    {
        print("GroundedState");
        currentState = groundedState;

        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
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
