using UnityEngine;
[CreateAssetMenu(fileName = "EnemyStunnedState", menuName = "EnemyStates/StunnedState")]
public class EnemyStunnedState : EnemyBaseState
{
    private float timer;
    public override void EnterState(EnemyStateManager Enemy)
    {
        timer = Enemy.EnemyStats.StunDuration;
        Enemy.ChangeMaterial(4);
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
                Enemy.ChangeMaterial(0);
            }
        }
        else
        {
            Enemy.Rigidbody.linearDamping = Enemy.EnemyStats.AirDrag;
        }

    }
}
