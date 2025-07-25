using UnityEngine;
public class PlayerCheckPoint : MonoBehaviour
{
    public delegate void RespawnDelegate();
    public static RespawnDelegate RespawnEnemies;

    
    public void ActivateCheckPoint()
    {
        RespawnEnemies.Invoke();
    }
}
