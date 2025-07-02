using UnityEngine;

public class PlayerGrabbingState : PlayerBaseState
{
    public EnemyStateManager Enemy;
    private float timer;
    public override void EnterState(PlayerStateManager Player)
    {
        Debug.Log("Grabbing state");
        Player.grappleState.hasGrabbedEnemy = false;
        Player.GrappleCollider.transform.position = Enemy.transform.position;
        Player.PlayerGrappleArmRigidBody.linearVelocity = Vector3.zero;
        Player.PlayerGrappleArmRigidBody.linearVelocity = Vector3.zero;
        Enemy.Rigidbody.isKinematic = true;

    }


    public override void UpdateState(PlayerStateManager Player)
    {
        if (Player.IsGrounded)
        {
            Player.Rigidbody.linearDamping = Player.PlayerVars.GroundDrag;
        }
        else
        {
            Player.Rigidbody.linearDamping = 0;
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
        Player.SwitchState(Player.grappleState);
        Player.grappleState.hasGrabbedEnemy = false;
        Player.grappleState.timer = Player.PlayerVars.GrappleIdleEnd;
        Enemy.SwitchToNeutralState();
        Enemy = null;
        Player.grappleState.Enemy = null;
        Enemy.Rigidbody.isKinematic = false;
    }
    public override void Stun(PlayerStateManager Player)
    {
        Player.GrappleCollider.SetActive(false);
        Enemy.SwitchToNeutralState();
        Enemy = null;
        Player.grappleState.Enemy = null;
        Enemy.Rigidbody.isKinematic = false;
    }
}
