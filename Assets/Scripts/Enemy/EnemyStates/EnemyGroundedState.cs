using UnityEngine;

public class EnemyGroundedState : EnemyBaseState
{

    public override void EnterState(EnemyStateManager Enemy)
    {
        Enemy.Rigidbody.linearDamping = Enemy.EnemyStats.GroundDrag;
    }

    public override void OnCollission(EnemyStateManager Enemy)
    {

    }

    public override void Update(EnemyStateManager Enemy)
    {


        if (!Enemy.IsGrounded)
        {
            Enemy.SwitchState(Enemy.AirborneState);
        }
    }

    public override void FixedUpdate(EnemyStateManager Enemy)
    {
        // Move
        if (!Enemy.PlayerIsDetected) return;
        if (Vector3.Distance(Enemy.transform.position, Enemy.EnemyStats.playerObject.GameObject.transform.position) < Enemy.EnemyStats.SweetSpotRange.x)
        {
            Enemy.Rigidbody.AddForce(-Enemy.transform.forward * Enemy.EnemyStats.MoveSpeed, ForceMode.Force);
        }
        else if (Vector3.Distance(Enemy.transform.position, Enemy.EnemyStats.playerObject.GameObject.transform.position) > Enemy.EnemyStats.SweetSpotRange.y)
        {
            Enemy.Rigidbody.AddForce(Enemy.transform.forward * Enemy.EnemyStats.MoveSpeed, ForceMode.Force);
        }
        else
        {
            Debug.Log("Enemy is in sweetspot");
            Enemy.PerformNextAttack();
        }

        

        // Rotate
        Vector3 directionToPlayer = (Enemy.EnemyStats.playerObject.GameObject.transform.position - Enemy.transform.position).normalized;
        Enemy.transform.rotation = Quaternion.Euler(0f, Quaternion.Slerp(Enemy.transform.rotation, Quaternion.LookRotation(directionToPlayer), Enemy.EnemyStats.RotateSpeed * Time.deltaTime).eulerAngles.y, 0f);
    }
    
    public override void Stun(EnemyStateManager Enemy)
    {

    }
}
