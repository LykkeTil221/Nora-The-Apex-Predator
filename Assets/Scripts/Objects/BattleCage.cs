using UnityEngine;

public class BattleCage : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] enemySpawners;
    [SerializeField] private GameObject TheBattleCage;

    private void Start()
    {
        TheBattleCage.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartBattleCage();
        }
    }

    private void StartBattleCage()
    {
        TheBattleCage.SetActive(true);
        for (int i = 0; i < enemySpawners.Length; i++)
        {
            enemySpawners[i].isBattleCage = true;
        }
    }

    private void Update()
    {
        if (enemySpawners == null)
        {
            Destroy(gameObject);
        }
    }
}
