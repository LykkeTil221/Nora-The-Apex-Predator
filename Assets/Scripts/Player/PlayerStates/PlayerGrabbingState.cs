using UnityEngine;

public class PlayerGrabbingState : PlayerBaseState
{
    public EnemyStateManager Enemy;
    public GameObject Object;
    private float timer;
    public override void EnterState(PlayerStateManager Player)
    {
        if(Enemy != null)
        {
            Player.grappleState.hasGrabbedEnemy = false;
            Player.GrappleCollider.transform.position = Enemy.transform.position;
            Enemy.Rigidbody.isKinematic = true;
        }
        if(Object != null)
        {
            Player.grappleState.hasGrabbedObject = false;
            Player.GrappleCollider.transform.position = Object.transform.position;
        }
        Debug.Log("Grabbing state");
        
        
        Player.PlayerGrappleArmRigidBody.linearVelocity = Vector3.zero;
        Player.PlayerGrappleArmRigidBody.linearVelocity = Vector3.zero;
        

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
        if (Enemy != null)
        {
            Enemy.Rigidbody.isKinematic = false;
            Enemy.SwitchToNeutralState();
            Enemy = null;
        }
            
        Player.SwitchState(Player.grappleState);
        Player.grappleState.hasGrabbedEnemy = false;
        Player.grappleState.timer = Player.PlayerVars.GrappleIdleEnd;
        
        Player.grappleState.Enemy = null;
        Player.grappleState.hasGrabbedObject = false;
        Player.grappleState.Object = null;
    }
    public override void Stun(PlayerStateManager Player)
    {
        if (Enemy != null)
        {
            Enemy.Rigidbody.isKinematic = false;
            Enemy.SwitchToNeutralState();
            Enemy = null;
        }
        Player.GrappleCollider.SetActive(false);
        Enemy.SwitchToNeutralState();
        Player.grappleState.Enemy = null;
        Player.grappleState.hasGrabbedObject = false;
        Player.grappleState.Object = null;
    }
}
