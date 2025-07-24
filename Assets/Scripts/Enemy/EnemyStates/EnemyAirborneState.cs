using UnityEngine;
[CreateAssetMenu(fileName = "EnemyAirborneState", menuName = "EnemyStates/AirborneState")]
public class EnemyAirborneState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager Enemy)
    {
        Enemy.Rigidbody.linearDamping = Enemy.EnemyStats.AirDrag;
    }

    public override void OnCollission(EnemyStateManager Enemy)
    {

    }

    public override void Update(EnemyStateManager Enemy)
    {
        if (Enemy.IsGrounded)
        {
            Enemy.SwitchState(Enemy.GroundedState);
        }
    }

    public override void FixedUpdate(EnemyStateManager Enemy)
    {

    }

    public override void Stun(EnemyStateManager Enemy)
    {

    }
}
