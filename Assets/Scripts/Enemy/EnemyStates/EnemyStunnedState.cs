using UnityEngine;

public class EnemyStunnedState : EnemyBaseState
{
    private float timer;
    public override void EnterState(EnemyStateManager Enemy)
    {
        timer = Enemy.EnemyStats.StunDuration;
    }

    public override void FixedUpdate(EnemyStateManager Enemy)
    {

    }

    public override void OnCollission(EnemyStateManager Enemy)
    {

    }

    public override void Stun(EnemyStateManager Enemy)
    {
        timer = Enemy.EnemyStats.StunDuration;
    }

    public override void Update(EnemyStateManager Enemy)
    {
        if (Enemy.IsGrounded)
        {
            Enemy.Rigidbody.linearDamping = Enemy.EnemyStats.GroundDrag;
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                Enemy.SwitchToNeutralState();
            }
        }
        else
        {
            Enemy.Rigidbody.linearDamping = Enemy.EnemyStats.AirDrag;
        }

    }
}
