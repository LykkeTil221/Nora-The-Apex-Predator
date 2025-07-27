using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFireBall", menuName = "EnemyStates /Attacks /FireBall")]
public class EnemyFireBallThrow : EnemyBaseState
{
    private bool hasThrownBall;
    private float timer;
    [SerializeField] float FireBallDuration;
    [SerializeField] float FireBallStartupEnd;
    [SerializeField] float FireBallActionEnd;
    [SerializeField] int NumberOfThrows;
    private int currentNumberOfThrows;
    [SerializeField] float timeUntilNextAttack;
    [SerializeField] GameObject Fireball;
    public override void EnterState(EnemyStateManager Enemy)
    {
        timer = FireBallDuration;
        currentNumberOfThrows = NumberOfThrows;
        Enemy.ChangeMaterial(1);
    }

    public override void FixedUpdate(EnemyStateManager Enemy)
    {

    }

    public override void OnCollission(EnemyStateManager Enemy)
    {
 
    }

    public override void Stun(EnemyStateManager Enemy)
    {
        StateEnd(Enemy);
    }

    public override void Update(EnemyStateManager Enemy)
    {
        Debug.Log("Fire pidgeon ball");
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(currentNumberOfThrows > 0)
            {
                Debug.Log("Enemy Throwing again");
                timer = FireBallDuration;
                currentNumberOfThrows-= 1;
                hasThrownBall = false;
            }
            else
            {
                StateEnd(Enemy);
                Enemy.ChangeMaterial(0);
            }
        }
        else if(timer <= FireBallActionEnd)
        {
            Enemy.ChangeMaterial(3);
        }
        else if(timer <= FireBallStartupEnd)
        {
            //Instantiate fireball
            if (!hasThrownBall)
            {
                Debug.Log("Enemy Threw FireBall");
                hasThrownBall = true;
                GameObject newFireBall = Instantiate(Fireball, Enemy.projectileThrowPoint.transform.position, Enemy.projectileThrowPoint.transform.rotation);
                Enemy.ChangeMaterial(2);

            }

            //Pidgeon can rotate
            Vector3 directionToPlayer = (Enemy.EnemyStats.playerObject.GameObject.transform.position - Enemy.transform.position).normalized;
            Enemy.transform.rotation = Quaternion.Euler(0f, Quaternion.Slerp(Enemy.transform.rotation, Quaternion.LookRotation(directionToPlayer), Enemy.EnemyStats.RotateSpeed * Time.deltaTime).eulerAngles.y, 0f);
        }
    }

    private void StateEnd(EnemyStateManager Enemy)
    {
        Enemy.timeBetweenAttacks = timeUntilNextAttack;
        Enemy.SwitchToNeutralState();
        hasThrownBall=false;
    }
}
