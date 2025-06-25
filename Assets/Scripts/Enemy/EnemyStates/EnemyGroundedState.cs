using UnityEngine;

public class EnemyGroundedState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager Enemy)
    {

    }

    public override void OnCollission(EnemyStateManager Enemy)
    {

    }

    public override void Update(EnemyStateManager Enemy)
    {
        if (!Enemy.IsGrounded)
        {
            Enemy.SwitchState(Enemy.AirborneState);
        }
    }
}
