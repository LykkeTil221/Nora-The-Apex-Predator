using UnityEngine;

public class PlayerDodgeState : PlayerBaseState
{
    private float timer;

    

    public override void EnterState(PlayerStateManager Player)
    {
        if(Player.PlayerVars.DodgeEnergyCost > Player.EnergyManager.CurrentPlayerEnergy)
        {
            Player.SwitchToNeutralState();
        }
        else
        {
            Player.EnergyManager.SpendEnergy(Player.PlayerVars.DodgeEnergyCost);
            Player.CurrentPlayerUnstoppable += Player.PlayerVars.DodgeUnstoppable;
            Debug.Log("Hello from the dodge state!");
            timer = Player.PlayerVars.DodgeDuration;

            if (Player.MoveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Player.MoveDirection, Vector3.up);

                Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, toRotation, 10000 * Time.deltaTime);
            }

            Player.Rigidbody.AddForce(Player.transform.forward * Player.PlayerVars.DodgeLungeForce, ForceMode.Impulse);
        }
        
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Player.SwitchState(Player.groundedState);
            Player.CurrentPlayerUnstoppable -= Player.PlayerVars.DodgeUnstoppable;
        }
        if(timer < Player.PlayerVars.DodgeActionEnd && !Player.IsGrounded)
        {
            Player.SwitchToNeutralState();
            Player.CurrentPlayerUnstoppable -= Player.PlayerVars.DodgeUnstoppable;
        }


    }
    public override void FixedUpdateState(PlayerStateManager Player)
    {
        if(timer > Player.PlayerVars.DodgeActionEnd)
        {

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
        Player.CurrentPlayerUnstoppable -= Player.PlayerVars.DodgeUnstoppable;
    }
    public override void Stun(PlayerStateManager Player)
    {

    }
}
