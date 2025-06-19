using UnityEngine;

public class PlayerGrappleState : PlayerBaseState
{
    private float timer;
    public override void EnterState(PlayerStateManager Player)
    {
        timer = Player.PlayerVars.GrappleDuration;
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Player.SwitchToNeutralState();
        }
    }

    public override void OnCollissionEnter(PlayerStateManager Player, Collision collision)
    {

    }
    public override void Dodge(PlayerStateManager Player)
    {
        if (timer < Player.PlayerVars.GrappleStartupEnd)
        {
            Player.SwitchState(Player.dodgeState);
        }
    }

    public override void Interact(PlayerStateManager Player)
    {

    }

    public override void Jump(PlayerStateManager Player)
    {

    }

    public override void LeftPunch(PlayerStateManager Player)
    {

    }

    public override void LeftSpecial(PlayerStateManager Player)
    {

    }
    public override void RightPunch(PlayerStateManager Player)
    {

    }

    public override void RightSpecial(PlayerStateManager Player)
    {

    }
    public override void Cancel(PlayerStateManager Player)
    {
        if (timer < Player.PlayerVars.GrappleStartupEnd)
        {
            Player.SwitchState(Player.groundedState);
        }
    }
}