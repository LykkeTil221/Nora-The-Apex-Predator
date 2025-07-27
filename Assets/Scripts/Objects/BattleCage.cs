using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class BattleCage : MonoBehaviour
{
    [SerializeField] private List <EnemySpawner> enemySpawners;
    [SerializeField] private GameObject TheBattleCage;
    [SerializeField] private Animator animator;
    private void Start()
    {
        TheBattleCage.SetActive(false);
        PlayerDamageManager.gameOver += ResetBattleCage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !TheBattleCage.activeSelf)
        {
            StartBattleCage();
            animator.Play(0,0,0);
        }
    }

    private void StartBattleCage()
    {
        TheBattleCage.SetActive(true);
        for (int i = 0; i < enemySpawners.Count; i++)
        {
            enemySpawners[i].isBattleCage = true;
            enemySpawners[i].battleCage = this;
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
        if(enemySpawners.Count == 0)
        {
            animator.Play("BattleCageDefeated");
            StartCoroutine(TurnOffBattleCage());
        }
    }

    private IEnumerator TurnOffBattleCage()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

    }

    private void ResetBattleCage(PlayerStateManager player)
    {
        TheBattleCage.SetActive(false);
    }

    public void ReAddSpawnerOnGameOver(EnemySpawner spawner)
    {
        if (!enemySpawners.Contains(spawner))
        {
            enemySpawners.Add(spawner);
        }
    }
}
