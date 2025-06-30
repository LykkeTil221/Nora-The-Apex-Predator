using UnityEngine;

public class PlayerStunned : PlayerBaseState
{
    private float timer;

    public override void EnterState(PlayerStateManager Player)
    {
        timer = Player.PlayerVars.stunDuration;
        Player.ChangePlayerMaterial(4);
    }


    public override void UpdateState(PlayerStateManager Player)
    {
        if (Player.IsGrounded)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                Player.SwitchToNeutralState();
                Player.ChangePlayerMaterial(0);
            }
            Player.Rigidbody.linearDamping = Player.PlayerVars.GroundDrag;
        }
        else
        {
            Player.Rigidbody.linearDamping = Player.PlayerVars.AirDrag;
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
