using UnityEngine;
public class PlayerCheckPoint : MonoBehaviour
{
    public delegate void RespawnDelegate();
    public static RespawnDelegate RespawnEnemies;
    public Transform spawnPoint;
    [SerializeField] string Name;
    [SerializeField] float seconds;
    public delegate void SetCheckpoint(Transform spawnPoint);
    public static SetCheckpoint setCheckpoint;
    public delegate void DisplayCheckPointName(float seconds, string text);
    public static DisplayCheckPointName displayCheckPointName;
    public delegate void MaxOutPlayerHealth(float health);
    public static MaxOutPlayerHealth maxPlayerHealth;
    public delegate void MaxOutPlayerEnergy();
    public static MaxOutPlayerEnergy maxPlayerEnergy;   
    public void ActivateCheckPoint()
    {
        RespawnEnemies.Invoke();
        setCheckpoint.Invoke(spawnPoint);
        displayCheckPointName.Invoke(seconds, Name);
        maxPlayerHealth.Invoke(100);
        maxPlayerEnergy.Invoke();
    }
}
