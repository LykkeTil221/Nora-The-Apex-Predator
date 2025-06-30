using UnityEngine;

public class EnemyDamageManager : MonoBehaviour
{
    [SerializeField] EnemyStateManager Enemy;
    public void TakeDamage(float damage, float stun, string attackID)
    {
        Enemy.currentHealth -= damage;
        if(stun > Enemy.EnemyStats.Unstoppable)
        {
            Enemy.Stunned();
        }
        if(Enemy.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
