using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerGroundedState groundedState = new PlayerGroundedState();
    public PlayerAirborneState airborneState = new PlayerAirborneState();
    public PlayerDodgeState dodgeState = new PlayerDodgeState();

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

    public  void Jump()
    {
        currentState.Jump(this);
    }
    public void Dodge()
    {
        currentState.Dodge(this);
    }
    public void LeftPunch()
    {
        currentState.LeftPunch(this);
    }
    public void RightPunch()
    {
        currentState.RightPunch(this);
    }
    public void LeftSpecial()
    {
        currentState.LeftPunch(this);
    }
    public void RightSpecial()
    {
        currentState.RightSpecial(this);
    }
    public void Interact()
    {
        currentState.Interact(this);
    }
    public void Cancel()
    {
        currentState.Cancel(this);
    }
}
