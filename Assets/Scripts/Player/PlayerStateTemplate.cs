using UnityEngine;

public class PlayerStateTemplate : PlayerBaseState
{
    public override void EnterState(PlayerStateManager Player)
    {

    }

    public override void UpdateState(PlayerStateManager Player)
    {

    }

    public override void OnCollissionEnter(PlayerStateManager Player, Collision collision)
    {

    }
    public override void Dodge(PlayerStateManager Player)
    {
        throw new System.NotImplementedException();
    }

    public override void Interact(PlayerStateManager Player)
    {
        throw new System.NotImplementedException();
    }

    public override void Jump(PlayerStateManager Player)
    {
        throw new System.NotImplementedException();
    }

    public override void LeftPunch(PlayerStateManager Player)
    {
        throw new System.NotImplementedException();
    }

    public override void LeftSpecial(PlayerStateManager Player)
    {
        throw new System.NotImplementedException();
    }
    public override void RightPunch(PlayerStateManager Player)
    {
        throw new System.NotImplementedException();
    }

    public override void RightSpecial(PlayerStateManager Player)
    {
        throw new System.NotImplementedException();
    }
    public override void Cancel(PlayerStateManager Player)
    {
        throw new System.NotImplementedException();
    }
}
