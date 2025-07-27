using UnityEngine;

public class EnemyDamageManager : MonoBehaviour
{
    [SerializeField] EnemyStateManager Enemy;
    public void TakeDamage(Vector3 damageStunKnockBack, string attackID, Transform direction)
    {
        Enemy.currentHealth -= damageStunKnockBack.x;
        if(damageStunKnockBack.y > Enemy.EnemyStats.Unstoppable)
        {
            Enemy.Stunned();
            KnockBack(damageStunKnockBack.z, direction.forward);
        }
        if(Enemy.currentHealth <= 0)
        {
            Enemy.OnEnemyDeath();
        }


    }

    private void KnockBack(float knockBack, Vector3 direction)
    {
        Enemy.Rigidbody.AddForce(direction * knockBack, ForceMode.Impulse);
    }
}
