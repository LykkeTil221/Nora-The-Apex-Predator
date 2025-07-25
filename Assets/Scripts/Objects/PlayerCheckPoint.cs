using UnityEngine;
public class PlayerCheckPoint : MonoBehaviour
{
    public delegate void RespawnDelegate();
    public static RespawnDelegate RespawnEnemies;
    public Transform spawnPoint;

    public delegate void SetCheckpoint(Transform spawnPoint);
    public static SetCheckpoint setCheckpoint;
    
    public void ActivateCheckPoint()
    {
        RespawnEnemies.Invoke();
        setCheckpoint.Invoke(spawnPoint);
    }
}
