using UnityEngine;
[CreateAssetMenu(fileName = "EnemyGrabbedState", menuName = "EnemyStates/Grabbed")]
public class EnemyGrabbedState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager Enemy)
    {
        Debug.Log("Enemy is Grabbed");
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
