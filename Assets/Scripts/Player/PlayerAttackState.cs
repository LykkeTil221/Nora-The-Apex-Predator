using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public bool wasLastInputLeft;
    private float timer;
    public override void EnterState(PlayerStateManager Player)
    {
        if (wasLastInputLeft)
        {
            Debug.Log("Left Hook");
        }
        else
        {
            Debug.Log("Right Hook");
        }
        timer = Player.PlayerVars.PunchDuration;
        Player.ChangePlayerMaterial(1);
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        timer -= Time.deltaTime;

        
        

        if(timer < Player.PlayerVars.PunchActionEnd)
        {
            Player.ChangePlayerMaterial(3);
        }
        else if(timer < Player.PlayerVars.PunchStartupEnd)
        {
            Player.ChangePlayerMaterial(2);
        }

        if (timer < 0)
        {
            Player.ChangePlayerMaterial(0);
            Player.SwitchToNeutralState();
        }
    }

    public override void FixedUpdateState(PlayerStateManager Player)
    {

    }

    public override void OnCollissionEnter(PlayerStateManager Player, Collision collision)
    {

    }
    public override void Dodge(PlayerStateManager Player)
    {
        if (timer > Player.PlayerVars.PunchStartupEnd)
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
        if (!wasLastInputLeft && timer < Player.PlayerVars.PunchStartupEnd)
        {
            Player.SwitchState(Player.attackState);
            Player.attackState.wasLastInputLeft = true;
        }
        else if(!wasLastInputLeft)
        {
            Player.SwitchState(Player.grappleState);
        }
    }

    public override void LeftSpecial(PlayerStateManager Player)
    {

    }
    public override void RightPunch(PlayerStateManager Player)
    {
        if (wasLastInputLeft && timer < Player.PlayerVars.PunchStartupEnd)
        {
            Player.SwitchState(Player.attackState);
            Player.attackState.wasLastInputLeft = false;
        }
        else if(wasLastInputLeft)
        {
            Player.SwitchState(Player.grappleState);
        }
    }

    public override void RightSpecial(PlayerStateManager Player)
    {

    }
    public override void Cancel(PlayerStateManager Player)
    {
        if(timer > Player.PlayerVars.PunchStartupEnd)
        {
            Player.SwitchState(Player.groundedState);
        }
    }
}