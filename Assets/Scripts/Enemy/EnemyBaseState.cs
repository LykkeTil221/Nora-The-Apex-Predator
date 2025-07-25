using UnityEngine;

public abstract class EnemyBaseState : ScriptableObject
{
    public abstract void EnterState(EnemyStateManager Enemy);
    public abstract void Update(EnemyStateManager Enemy);
    public abstract void FixedUpdate(EnemyStateManager Enemy);
    public abstract void OnCollission(EnemyStateManager Enemy);
    public abstract void Stun(EnemyStateManager Enemy);
}
