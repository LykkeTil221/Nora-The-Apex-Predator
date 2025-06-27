using UnityEngine;

public class EnemyDamageManager : MonoBehaviour
{
    [SerializeField] EnemyStateManager Enemy;
    public void TakeDamage(float damage, float stun)
    {
        Enemy.currentHealth -= damage;
        if(stun > Enemy.EnemyStats.Unstoppable)
        {
            //Enemy is stunned.
        }
        if(Enemy.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
