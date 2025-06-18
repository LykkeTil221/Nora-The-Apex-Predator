using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager Player)
    {
        Debug.Log("Hello from the GroundedState!");
    }

    public override void UpdateState(PlayerStateManager Player)
    {

    }

    public override void OnCollissionEnter(PlayerStateManager Player, Collision collision)
    {

    }
    public override void Dodge(PlayerStateManager Player)
    {
        Player.SwitchState(Player.dodgeState);
    }

    public override void Interact(PlayerStateManager Player)
    {

    }

    public override void Jump(PlayerStateManager Player)
    {
        Player.SwitchState(Player.airborneState);
    }

    public override void LeftPunch(PlayerStateManager Player)
    {
        Player.SwitchState(Player.attackState);
        Player.attackState.wasLastInputLeft = true;
    }

    public override void LeftSpecial(PlayerStateManager Player)
    {

    }



    public override void RightPunch(PlayerStateManager Player)
    {
        Player.SwitchState(Player.attackState);
        Player.attackState.wasLastInputLeft = false;
    }

    public override void RightSpecial(PlayerStateManager Player)
    {

    }

    public override void Cancel(PlayerStateManager Player)
    {

    }
}
