using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyStateManager EnemyToSpawn;
    private EnemyStateManager Enemy;
    [HideInInspector] public bool isBattleCage;
    public BattleCage battleCage;
    private bool isSpawning;
    private float timer;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private ParticleSystem spawningParticle;
    [SerializeField] private ParticleSystem finishedSpawningParticle;
    [SerializeField] private int finishSpawnParticleCount;
    private void Start()
    {
        Enemy = Instantiate(EnemyToSpawn, transform);
        Enemy.gameObject.SetActive(false);
        StartSpawning();
        PlayerCheckPoint.RespawnEnemies += StartSpawning;
        

        PlayerDamageManager.gameOver += GameOver;
    }

    private void Update()
    {
        if (!isSpawning) return;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnEnemy();
            spawningParticle.Stop();
            spawningParticle.Clear();
            finishedSpawningParticle.Emit(finishSpawnParticleCount);
            isSpawning = false;
        }
    }

    public void StartSpawning()
    {
        spawningParticle.Play();
        Enemy.gameObject.SetActive(false);
        timer = timeToSpawn;
        isSpawning = true;
    }

    private void SpawnEnemy()
    {

        Enemy.transform.rotation = transform.rotation;
        Enemy.spawner = this;
        Enemy.SwitchToNeutralState();
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

    public void KillEnemy()
    {
        Enemy.transform.position = transform.position;
        Enemy.transform.rotation = transform.rotation;
        Enemy.gameObject.SetActive(false);
        if (isBattleCage) 
        {
            battleCage.RemoveSpawnerFromList(this);
        }
    }

    private void GameOver(PlayerStateManager player)
    {
        battleCage.ReAddSpawnerOnGameOver(this);
    }

}
