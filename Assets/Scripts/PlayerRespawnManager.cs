using UnityEngine;
using System.Collections;
public class PlayerRespawnManager : MonoBehaviour
{
    public delegate void RespawnPlayerDelegate();
    public static RespawnPlayerDelegate RespawnPlayer;
    private void Start()
    {
        PlayerDamageManager.gameOver += RespawnPlayerFunction;
    }

    private void RespawnPlayerFunction(PlayerStateManager player)
    {
        Debug.Log("Starting to respawn player");
        StartCoroutine(DelayedRespawn(player));
    }

    private IEnumerator DelayedRespawn(PlayerStateManager player)
    {
        yield return new WaitForSeconds(1);
        player.gameObject.SetActive(true);
        RespawnPlayer.Invoke();
        PlayerCheckPoint.RespawnEnemies.Invoke();
    }
}
