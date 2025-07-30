using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool hasEssence;
    private bool hasBeenDefeated;
    [SerializeField] EnemyStateManager EnemyToSpawn;
    private EnemyStateManager Enemy;
    [HideInInspector] public bool isBattleCage;
    public BattleRoomController battleCage;
    private bool isSpawning;
    private float timer;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private ParticleSystem spawningParticle;
    [SerializeField] private ParticleSystem finishedSpawningParticle;
    [SerializeField] private int finishSpawnParticleCount;
    private void Awake()
    {
        Enemy = Instantiate(EnemyToSpawn, transform);
        Enemy.gameObject.SetActive(false);
        
        PlayerDamageManager.gameOver += GameOver;
        
        if(hasEssence)Enemy.hasEssence = true;
       
    }

    private void Start()
    {
        if (isBattleCage) 
        {
            PlayerCheckPoint.RespawnEnemies += ResetSpawner;
        }
        else
        {
            StartSpawning();
            PlayerCheckPoint.RespawnEnemies += StartSpawning;
        }
        
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

    public void ResetSpawner()
    {
        Enemy.gameObject.SetActive(false);
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
        if (hasEssence)
        {
            hasBeenDefeated = true;
            PlayerCheckPoint.RespawnEnemies -= StartSpawning;
            PlayerDamageManager.gameOver -= GameOver;
            PlayerCheckPoint.RespawnEnemies -= ResetSpawner;
        }
    }

    private void GameOver(PlayerStateManager player)
    {
        if (battleCage == null) return;
        battleCage.ReAddSpawnerOnGameOver(this);
    }
    private void OnDisable()
    {
        PlayerCheckPoint.RespawnEnemies -= StartSpawning;
        PlayerDamageManager.gameOver -= GameOver;
        PlayerCheckPoint.RespawnEnemies -= ResetSpawner;
    }
}
