using UnityEngine;

public class PlayerAirborneState : PlayerBaseState
{
    

    public override void EnterState(PlayerStateManager Player)
    {
        Debug.Log("Hello from the airborne State");
    }
    public override void UpdateState(PlayerStateManager Player)
    {
        
        if (Player.IsGrounded)
        {
            Debug.Log("player is grounded");
            Player.SwitchState(Player.groundedState);
        }
    }

    public override void OnCollissionEnter(PlayerStateManager Player, Collision collision)
    {

    }
    public override void Dodge(PlayerStateManager Player)
    {

    }

    public override void Interact(PlayerStateManager Player)
    {

    }

    public override void Jump(PlayerStateManager Player)
    {

    }

    public override void LeftPunch(PlayerStateManager Player)
    {
        Player.SwitchState(Player.airAttackState);
    }

    public override void LeftSpecial(PlayerStateManager Player)
    {

    }

    

    public override void RightPunch(PlayerStateManager Player)
    {
        Player.SwitchState(Player.airAttackState);
    }

    public override void RightSpecial(PlayerStateManager Player)
    {

    }

    public override void Cancel(PlayerStateManager Player)
    {

    }
}
