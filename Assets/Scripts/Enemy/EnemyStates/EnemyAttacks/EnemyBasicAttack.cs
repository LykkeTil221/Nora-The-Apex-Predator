using UnityEngine;
[CreateAssetMenu(fileName = "EnemyBasicAttack", menuName = "EnemyStates/Attacks/BasicAttack")]
public class EnemyBasicAttack : EnemyBaseState
{
    private float timer;
    [SerializeField] float AttackDuration;
    [SerializeField] float AttackStartupEnd;
    [SerializeField] float AttackActionEnd;
    public override void EnterState(EnemyStateManager Enemy)
    {
        Debug.Log("Enemy entered basic attack state ??");
        timer = AttackDuration;
    }

    public override void FixedUpdate(EnemyStateManager Enemy)
    {

    }

    public override void OnCollission(EnemyStateManager Enemy)
    {

    }

    public override void Stun(EnemyStateManager Enemy)
    {
        Enemy.AttackCollider.SetActive(false);
    }

    public override void Update(EnemyStateManager Enemy)
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Enemy.SwitchToNeutralState();
        }
        else if(timer <= AttackActionEnd)
        {
            Enemy.AttackCollider.SetActive(false);
        }
        else if(timer <= AttackStartupEnd)
        {
            Enemy.AttackCollider.SetActive(true);
        }
    }
}
