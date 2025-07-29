using UnityEngine;
using System.Collections.Generic;
public class BattleRoomController : MonoBehaviour
{
    [SerializeField] List<EnemySpawner> enemySpawners;
    public delegate void BattleRoomDoorDelegate(bool open);
    public static BattleRoomDoorDelegate openBattleDoor;

    public Collider trigger;
    private void Awake()
    {
        for (int i = 0; i < enemySpawners.Count; i++)
        {
            enemySpawners[i].isBattleCage = true;
            enemySpawners[i].battleCage = this;
        }
    }
    private void Start()
    {
        PlayerDamageManager.gameOver += DeactivateBattleRoom;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateBattleRoom();
        }
    }

    private void ActivateBattleRoom()
    {
        openBattleDoor.Invoke(false);
        trigger.enabled = false;
        for (int i = 0; i < enemySpawners.Count; i++)
        {
            enemySpawners[i].StartSpawning();
        }
    }
    public void RemoveSpawnerFromList(EnemySpawner spawner)
    {
        enemySpawners.Remove(spawner);
        CheckEnemyStatus();
    }
    private void CheckEnemyStatus()
    {
        if (enemySpawners.Count == 0)
        {
            BattleRoomIsDefeated();
        }
    }
    public void ReAddSpawnerOnGameOver(EnemySpawner spawner)
    {
        if (!enemySpawners.Contains(spawner))
        {
            enemySpawners.Add(spawner);
        }
    }

    private void DeactivateBattleRoom(PlayerStateManager player)
    {
        openBattleDoor.Invoke(true);
        trigger.enabled = true;
    }
    private void BattleRoomIsDefeated()
    {
        openBattleDoor.Invoke(true);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        PlayerDamageManager.gameOver -= DeactivateBattleRoom;
    }
}
