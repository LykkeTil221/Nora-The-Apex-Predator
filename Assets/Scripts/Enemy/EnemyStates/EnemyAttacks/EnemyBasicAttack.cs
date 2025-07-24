using UnityEngine;

public class EnemyBasicAttack : EnemyBaseState
{
    public override void EnterState(EnemyStateManager Enemy)
    {
        Debug.Log("Enemy entered basic attack state ??");
    }

    public override void FixedUpdate(EnemyStateManager Enemy)
    {

    }

    public override void OnCollission(EnemyStateManager Enemy)
    {

    }

    public override void Stun(EnemyStateManager Enemy)
    {

    }

    public override void Update(EnemyStateManager Enemy)
    {

    }
}
