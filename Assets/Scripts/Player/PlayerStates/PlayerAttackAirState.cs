using UnityEngine;

public class PlayerAttackAirState : PlayerBaseState
{
    private float timer;
    private bool hasHitGround;
    public bool attackLeft;
    public override void EnterState(PlayerStateManager Player)
    {
        Debug.Log("Hello from the air attack state");
        hasHitGround = false;
        Player.Rigidbody.linearVelocity = new Vector3(Player.Rigidbody.linearVelocity.x, 0, Player.Rigidbody.linearVelocity.z);
        Player.Rigidbody.AddForce(Vector3.up * Player.PlayerVars.AirAttackJumpStrength, ForceMode.Impulse);
        timer = 0;
        Player.ChangePlayerMaterial(1);
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        if (Player.IsGrounded && !hasHitGround)
        {
            Debug.Log("SLAM!!!");
            hasHitGround=true;
            
            timer = Player.PlayerVars.AirAttackEndDuration;
            Player.ChangePlayerMaterial(2);
            Player.Rigidbody.linearVelocity = Vector3.zero;
            Player.AirAttackCollider.SetActive(true);
        }

        if (hasHitGround)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                Player.AirAttackCollider.SetActive(false);
                Player.SwitchToNeutralState();
                Player.ChangePlayerMaterial(0);
            }
            else if(timer <= Player.PlayerVars.AirAttackActionEnd)
            {
                Player.AirAttackCollider.SetActive(false);
            }
        }
        else
        {
            timer += Time.deltaTime;
            if(timer > Player.PlayerVars.AirAttackTimeBeforeSlamDown)
            {
                Player.Rigidbody.AddForce(Vector3.down * Player.PlayerVars.AirAttackDownSpeed, ForceMode.Force);
            }
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
        if (!attackLeft)
        {
            Player.SwitchState(Player.grappleState);
        }
    }

    public override void LeftSpecial(PlayerStateManager Player)
    {

    }
    public override void RightPunch(PlayerStateManager Player)
    {
        if (attackLeft)
        {
            Player.SwitchState(Player.grappleState);
        }
    }

    public override void RightSpecial(PlayerStateManager Player)
    {

    }
    public override void Cancel(PlayerStateManager Player)
    {
        Player.AirAttackCollider.SetActive(false);
        Player.SwitchToNeutralState();
    }
    public override void Stun(PlayerStateManager Player)
    {
        Player.AirAttackCollider.SetActive(false);
    }
}
