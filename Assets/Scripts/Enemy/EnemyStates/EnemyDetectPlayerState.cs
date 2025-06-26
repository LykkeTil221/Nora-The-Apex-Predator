using UnityEngine;

public class EnemyDetectPlayerState : EnemyBaseState
{
    private float timer;
    private float exclamTime = 0.5f;
    public override void EnterState(EnemyStateManager Enemy)
    {
        Enemy.ExplamationMark.SetActive(true);
        timer = exclamTime;
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
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Enemy.ExplamationMark.SetActive(false);
            Enemy.SwitchToNeutralState();
        }

        Vector3 directionToPlayer = (Enemy.EnemyStats.playerObject.GameObject.transform.position - Enemy.transform.position).normalized;
        Enemy.transform.rotation = Quaternion.Euler(0f, Quaternion.Slerp(Enemy.transform.rotation, Quaternion.LookRotation(directionToPlayer), Enemy.EnemyStats.RotateSpeed * Time.deltaTime).eulerAngles.y, 0f);
    }
}
