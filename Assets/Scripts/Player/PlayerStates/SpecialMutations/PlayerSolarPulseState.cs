using UnityEngine;

public class PlayerSolarPulseState : PlayerBaseState
{
    private float timer;
    private bool hasSpentEnergy;
    public override void EnterState(PlayerStateManager Player)
    {
        if(Player.EnergyManager.CurrentPlayerEnergy < Player.PlayerVars.SolarPulseEnergyCost)
        {
            Player.SwitchToNeutralState();
            Debug.Log("Not enough energy for Solar Pulse");
        }
        else
        {
            //Do the thing
            Debug.Log("Doing Solar Pulse");
            timer = Player.PlayerVars.SolarPulseDuration;
            Player.ChangePlayerMaterial(1);
            
        }
    }


    public override void UpdateState(PlayerStateManager Player)
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            CancelState(Player, true);
        }
        else if (timer <= Player.PlayerVars.SolarPulseActionEnd)
        {
            Player.ChangePlayerMaterial(3);
            Player.SolarPulseCollider.SetActive(false);
        }
        else if (timer <= Player.PlayerVars.SolarPulseStartupEnd)
        {
            Player.ChangePlayerMaterial(2);
            Player.SolarPulseCollider.SetActive(true);
            if (!hasSpentEnergy)
            {
                Player.EnergyManager.SpendEnergy(Player.PlayerVars.SolarPulseEnergyCost);
                hasSpentEnergy = true;
            }
        }

        if (Player.IsGrounded)
        {
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
        if (timer > Player.PlayerVars.SolarPulseStartupEnd)
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
        if(timer > Player.PlayerVars.SolarPulseStartupEnd) CancelState(Player, true);

    }
    public override void Stun(PlayerStateManager Player)
    {
        CancelState(Player, true);
    }

    private void CancelState(PlayerStateManager Player, bool SwitchState)
    {
        Player.ChangePlayerMaterial(0);
        
        timer = 0;
        Player.SolarPulseCollider.SetActive(false);
        hasSpentEnergy = false;
        if(SwitchState) Player.SwitchToNeutralState();
    }
}
