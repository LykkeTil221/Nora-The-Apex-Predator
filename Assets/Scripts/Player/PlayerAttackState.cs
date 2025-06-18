using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public bool wasLastInputLeft;
    private float timer;
    private float PunchDuration = 1;
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
        timer = PunchDuration;
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        timer -= Time.deltaTime;

        
        if(timer <= 0)
        {
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
        if (!wasLastInputLeft && timer < 0.7f)
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
        if (wasLastInputLeft && timer < 0.7f)
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

    }
}