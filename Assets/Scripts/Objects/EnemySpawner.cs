using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyStateManager EnemyToSpawn;
    private EnemyStateManager Enemy;
    public bool isBattleCage;

    private void Start()
    {
        Enemy = Instantiate(EnemyToSpawn, transform);
        Enemy.transform.rotation = transform.rotation;
        Enemy.spawner = this;
        PlayerCheckPoint.RespawnEnemies += ReSpawnEnemy;
        Enemy.SwitchToNeutralState();
    }

    public void KillEnemy()
    {
        Enemy.transform.position = transform.position;
        Enemy.transform.rotation = transform.rotation;
        Enemy.gameObject.SetActive(false);
        if (isBattleCage) { Destroy(gameObject); }
    }

    
    public void ReSpawnEnemy()
    {
        Enemy.transform.position = transform.position;
        Enemy.transform.rotation = transform.rotation;
        Enemy.gameObject.SetActive(true);
        Enemy.SwitchToNeutralState();
        Enemy.PlayerIsDetected = false;
        Enemy.ExclamationMark.SetActive(false);
        Enemy.currentHealth = Enemy.EnemyStats.Health;
        Enemy.currentAttack = 0;
        Enemy.currentAttackState = Enemy.Attacks[Enemy.currentAttack];
    }
}
