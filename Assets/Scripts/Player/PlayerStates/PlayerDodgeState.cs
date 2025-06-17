using UnityEngine;

public class PlayerDodgeState : PlayerBaseState
{
    private float timer;
    private float DodgeDuration = 1;

    

    public override void EnterState(PlayerStateManager Player)
    {
        Debug.Log("Hello from the dodge state!");
        timer = DodgeDuration;
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
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

    }
}
