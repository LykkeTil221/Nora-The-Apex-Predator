using UnityEngine;

public class PlayerGrappleState : PlayerBaseState
{
    private float timer;
    private bool hasGrabbedEnemy;
    public override void EnterState(PlayerStateManager Player)
    {
        timer = Player.PlayerVars.GrappleDuration;
        Player.ChangePlayerMaterial(1);
        Player.GrappleCollider.SetActive(true);
        Player.GrappleCollider.transform.position = Player.transform.position;
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        if (hasGrabbedEnemy) return;
        if (timer < Player.PlayerVars.GrappleActionEnd)
        {
            Player.ChangePlayerMaterial(3);
           
        }
        else if (timer < Player.PlayerVars.GrappleStartupEnd)
        {          
            Player.ChangePlayerMaterial(2);

        }

        if(timer < Player.PlayerVars.GrappleIdleEnd)
        {
            Player.GrappleCollider.transform.position += Vector3.forward * 10;
        }

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Player.SwitchToNeutralState();
            Player.ChangePlayerMaterial(0);
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
            Player.ChangePlayerMaterial(0);
        }
    }

    public override void FixedUpdateState(PlayerStateManager Player)
    {

    }

    public void EnemyIsGrabbed(EnemyStateManager GrabbedEnemy)
    {
        hasGrabbedEnemy = true;
    }
}