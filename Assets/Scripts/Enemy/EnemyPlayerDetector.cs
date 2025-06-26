using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour
{
    [SerializeField] EnemyStateManager enemyStateManager;
    private float timer;
    private void Update()
    {
        if (!enemyStateManager.PlayerIsDetected)
        {
            if(Vector3.Distance(transform.position, enemyStateManager.EnemyStats.playerObject.GameObject.transform.position) < enemyStateManager.EnemyStats.SweetSpotRange.z)
            {
                enemyStateManager.PlayerIsDetected = true;
                timer = enemyStateManager.EnemyStats.attentionSpan;
            }    
        }
        else
        {
            timer -= Time.deltaTime;

            if(timer < 0)
            {
                if (Vector3.Distance(transform.position, enemyStateManager.EnemyStats.playerObject.GameObject.transform.position) < enemyStateManager.EnemyStats.SweetSpotRange.z)
                {
                    timer = enemyStateManager.EnemyStats.attentionSpan;
                }
                else
                {
                    enemyStateManager.PlayerIsDetected = false;
                }
            }
        }
    }
}
