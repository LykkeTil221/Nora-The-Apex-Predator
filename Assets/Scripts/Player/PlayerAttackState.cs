using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public bool wasLastInputLeft;
    private float timer;
    private int currentCombo;
    private bool doOtherPunch;
    public override void EnterState(PlayerStateManager Player)
    {
        currentCombo += 1;
        Player.LeftArmCollider.SetActive(false);
        Player.RightArmCollider.SetActive(false);
        if (wasLastInputLeft)
        {
            Debug.Log("Left Hook");
        }
        else
        {
            Debug.Log("Right Hook");
        }
        timer = Player.PlayerVars.PunchDuration;
        Player.ChangePlayerMaterial(1);
        Debug.Log(currentCombo);
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        timer -= Time.deltaTime;

        if(timer > Player.PlayerVars.PunchStartupEnd)
        {
            if (Player.MoveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Player.MoveDirection, Vector3.up);

                Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, toRotation, Player.PlayerVars.RotateSpeed * Time.deltaTime);
            }
        }

        if(doOtherPunch && timer < Player.PlayerVars.PunchActionEnd)
        {
            if (!wasLastInputLeft)
            {
                Player.SwitchState(Player.attackState);
                Player.attackState.wasLastInputLeft = true;
            }
            else
            {
                Player.SwitchState(Player.attackState);
                Player.attackState.wasLastInputLeft = false;
            }
            doOtherPunch = false;
        }
        

        if(timer < Player.PlayerVars.PunchActionEnd)
        {
            Player.ChangePlayerMaterial(3);
            Player.LeftArmCollider.SetActive(false);
            Player.RightArmCollider.SetActive(false);
            Player.Rigidbody.linearVelocity = Vector3.zero;
        }
        else if(timer < Player.PlayerVars.PunchStartupEnd)
        {
            if (wasLastInputLeft)
            {
                Player.LeftArmCollider.SetActive(true);
            }
            else
            {
                Player.RightArmCollider.SetActive(true);
            }
            Player.ChangePlayerMaterial(2);

            Player.Rigidbody.AddForce(Player.transform.forward * Player.PlayerVars.PunchForwardSpeed,ForceMode.Impulse);
        }
        if (timer < Player.PlayerVars.PunchActionEnd && !Player.IsGrounded)
        {
            Player.SwitchToNeutralState();
            Player.ChangePlayerMaterial(0);
        }

        if (timer < 0)
        {
            Player.ChangePlayerMaterial(0);
            Player.SwitchToNeutralState();
            currentCombo = 0;
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
        if (timer > Player.PlayerVars.PunchStartupEnd)
        {
            Player.SwitchState(Player.dodgeState);
            currentCombo = 0;
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
        if (!wasLastInputLeft && timer < Player.PlayerVars.PunchStartupEnd)
        {
            doOtherPunch = true;
        }
        else if(!wasLastInputLeft && timer > Player.PlayerVars.PunchStartupEnd)
        {
            Player.SwitchState(Player.grappleState);
        }
    }

    public override void LeftSpecial(PlayerStateManager Player)
    {

    }
    public override void RightPunch(PlayerStateManager Player)
    {
        if (wasLastInputLeft && timer < Player.PlayerVars.PunchStartupEnd)
        {
            doOtherPunch = true;
        }
        else if(wasLastInputLeft && timer > Player.PlayerVars.PunchStartupEnd)
        {
            Player.SwitchState(Player.grappleState);
        }
    }

    public override void RightSpecial(PlayerStateManager Player)
    {

    }
    public override void Cancel(PlayerStateManager Player)
    {
        if(timer > Player.PlayerVars.PunchStartupEnd)
        {
            Player.SwitchState(Player.groundedState);
            Player.ChangePlayerMaterial(0);
            currentCombo = 0;
        }
    }
}