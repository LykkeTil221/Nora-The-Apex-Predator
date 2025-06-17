using UnityEngine;

public class PlayerAirborneState : PlayerBaseState
{
    

    public override void EnterState(PlayerStateManager Player)
    {
        Debug.Log("airborne State");
    }
    public override void UpdateState(PlayerStateManager Player)
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

    }
}
