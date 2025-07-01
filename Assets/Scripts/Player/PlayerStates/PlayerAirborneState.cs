using UnityEngine;

public class PlayerAirborneState : PlayerBaseState
{
    public bool didPlayerJump;
    private float timer;
    public override void EnterState(PlayerStateManager Player)
    {
        Player.Rigidbody.linearDamping = Player.PlayerVars.AirDrag;
        Debug.Log("Hello from the airborne State");
        if (didPlayerJump)
        {
            Player.Rigidbody.AddForce(Vector3.up * Player.PlayerVars.JumpStrength, ForceMode.Impulse);
            didPlayerJump = false;
        }
        
        timer = 0;
    }
    public override void UpdateState(PlayerStateManager Player)
    {
        timer += Time.deltaTime;
        if(timer > 0.1f && Player.IsGrounded)
        {
            Debug.Log("player is grounded");
            Player.SwitchState(Player.groundedState);
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
        Player.SwitchState(Player.airAttackState);
        Player.airAttackState.attackLeft = true;
    }

    public override void LeftSpecial(PlayerStateManager Player)
    {

    }

    

    public override void RightPunch(PlayerStateManager Player)
    {
        Player.SwitchState(Player.airAttackState);
        Player.airAttackState.attackLeft = false;
    }

    public override void RightSpecial(PlayerStateManager Player)
    {

    }

    public override void Cancel(PlayerStateManager Player)
    {

    }
}
