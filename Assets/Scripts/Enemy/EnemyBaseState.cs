using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager Enemy);
    public abstract void Update(EnemyStateManager Enemy);
    public abstract void OnCollission(EnemyStateManager Enemy);
}
