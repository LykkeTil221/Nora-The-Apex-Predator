using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager Player);
    public abstract void UpdateState(PlayerStateManager Player);
    public abstract void FixedUpdateState(PlayerStateManager Player);
    public abstract void OnCollissionEnter(PlayerStateManager Player,Collision collision);
    public abstract void Jump(PlayerStateManager Player);
    public abstract void Dodge(PlayerStateManager Player);
    public abstract void LeftPunch(PlayerStateManager Player);
    public abstract void RightPunch(PlayerStateManager Player);
    public abstract void LeftSpecial(PlayerStateManager Player);
    public abstract void RightSpecial(PlayerStateManager Player);
    public abstract void Interact(PlayerStateManager Player);
    public abstract void Cancel(PlayerStateManager Player);
}
