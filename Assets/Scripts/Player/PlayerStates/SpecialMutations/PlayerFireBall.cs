using UnityEngine;
using Unity.Collections;
public class PlayerFireBall : PlayerBaseState
{
    private float timer;
    private bool hasSpentEnergy;
    private bool hasShotBall;
    public override void EnterState(PlayerStateManager Player)
    {
        if (Player.EnergyManager.CurrentPlayerEnergy < Player.PlayerVars.FireBallEnergyCost)
        {
            Player.SwitchToNeutralState();
            Debug.Log("Not enough energy for FireBall");
        }
        else
        {
            Debug.Log("Doing FireBal");
            timer = Player.PlayerVars.FireBallDuration;
            Player.ChangePlayerMaterial(1);
        }

            
    }


    public override void UpdateState(PlayerStateManager Player)
    {
        timer -= Time.deltaTime;

        if( timer is <= 0)
        {
            CancelState(Player, true);
        }
        else if(timer <= Player.PlayerVars.FireBallActionEnd)
        {
            Player.ChangePlayerMaterial(3);
        }
        else if(timer <= Player.PlayerVars.FireBallStartUpEnd)
        {
            Player.ChangePlayerMaterial(2);
            if (!hasSpentEnergy)
            {
                Player.EnergyManager.SpendEnergy(Player.PlayerVars.FireBallEnergyCost);
                hasSpentEnergy = true;
            }
            
            if (!hasShotBall)
            {
                GameObject fireBall = Object.Instantiate(Player.FireBall, Player.projectileThrowPoint.transform.position, Player.projectileThrowPoint.transform.rotation);
                fireBall.GetComponent<Rigidbody>().AddForce(fireBall.transform.forward * Player.PlayerVars.FireBallLaunchForce);
                hasShotBall = true;
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
        if (timer > Player.PlayerVars.FireBallStartUpEnd)
        {
            CancelState(Player, false);
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
        if(timer > Player.PlayerVars.FireBallStartUpEnd)
        {
            CancelState(Player, true);
        }
    }
    public override void Stun(PlayerStateManager Player)
    {
        CancelState(Player, true);
    }
    private void CancelState(PlayerStateManager Player, bool changeState)
    {
        Player.ChangePlayerMaterial(0);
        hasSpentEnergy = false;
        if (changeState) Player.SwitchToNeutralState();
        hasShotBall = false;
    }
}
