using UnityEngine;

public class PlayerGrappleState : PlayerBaseState
{
    public float timer;
    public bool hasGrabbedEnemy;
    private int ArmState;
    public EnemyStateManager Enemy;

    private PlayerStateManager stateManager;
    public override void EnterState(PlayerStateManager Player)
    {
        timer = Player.PlayerVars.GrappleDuration;
        Player.ChangePlayerMaterial(1);
        Player.PlayerGrappleArmRigidBody.linearVelocity = Vector3.zero;
        Player.GrappleCollider.transform.position = Player.transform.position;
        Player.GrappleCollider.transform.rotation = Player.transform.rotation;
        ArmState = 0;
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        if (hasGrabbedEnemy)
        {
            Player.grabbingState.Enemy = Enemy;
            Player.SwitchState(Player.grabbingState);
        }

        if (timer < Player.PlayerVars.GrappleActionEnd)
        {
            Player.ChangePlayerMaterial(3);

        }
        else if (timer < Player.PlayerVars.GrappleStartupEnd)
        {
            Player.ChangePlayerMaterial(2);
            Player.GrappleCollider.SetActive(true);

        }

        if (timer < Player.PlayerVars.GrappleStartupEnd && ArmState == 0)
        {
            Player.PlayerGrappleArmRigidBody.AddForce(Player.GrappleCollider.transform.forward * Player.PlayerVars.GrappleOutSpeed, ForceMode.Impulse);
            ArmState = 1;
        }
        if (timer < Player.PlayerVars.GrappleActionEnd && ArmState == 1)
        {
            Player.PlayerGrappleArmRigidBody.linearVelocity = Vector3.zero;
            ArmState = 2;
        }

        if (timer < Player.PlayerVars.GrappleIdleEnd && ArmState == 2)
        {
            Player.PlayerGrappleArmRigidBody.AddForce(-Player.GrappleCollider.transform.forward * Player.PlayerVars.GrappleReturnSpeed, ForceMode.Force);
            if (Vector3.Distance(Player.transform.position, Player.GrappleCollider.transform.position) < 3)
            {
                Player.GrappleCollider.SetActive(false);

            }
        }

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Player.SwitchToNeutralState();
            Player.ChangePlayerMaterial(0);
        }

        if (Player.IsGrounded)
        {
            Player.Rigidbody.linearDamping = Player.PlayerVars.GroundDrag;
        }
        else
        {
            Player.Rigidbody.linearDamping = 0;
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
            Player.GrappleCollider.SetActive(false);
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
        if (timer > Player.PlayerVars.GrappleStartupEnd)
        {
            Player.SwitchToNeutralState();
            Player.ChangePlayerMaterial(0);
            Player.GrappleCollider.SetActive(false);
        }
    }

    public override void FixedUpdateState(PlayerStateManager Player)
    {

    }

    public void EnemyIsGrabbed(EnemyStateManager GrabbedEnemy)
    {
        hasGrabbedEnemy = true;
        Enemy = GrabbedEnemy;
    }
    public override void Stun(PlayerStateManager Player)
    {

    }
}