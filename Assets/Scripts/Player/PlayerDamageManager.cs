using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageManager : MonoBehaviour
{
    [SerializeField] private PlayerStateManager Player;
    [SerializeField] private float timer;
    [SerializeField] UIHeartManager heartManager;

    public delegate void GameOver(PlayerStateManager player);
    public static GameOver gameOver;
    public void TakeDamage(float damage, float stun, string attackID)
    {
        if (timer > 0) return;        
        timer = Player.PlayerVars.IFrames;
        Debug.Log("Player took" + damage + "damage with" + stun + "stun");
        Player.CurrentPlayerHealth -= damage;
        if(stun > Player.CurrentPlayerUnstoppable)
        {
            Debug.Log("Stunned");
            Player.PlayerStunned();
        }

        if(Player.CurrentPlayerHealth <= 0)
        {
            Debug.Log("Player is defeated");
            gameOver.Invoke(Player);
            Player.gameObject.SetActive(false);
        }
        heartManager.UpdateHearts();
    }
    public void HealHeallth(float healthGain)
    {
        Player.CurrentPlayerHealth += healthGain;
        if(Player.CurrentPlayerHealth > Player.CurrentMaxHealth)
        {
            Player.CurrentPlayerHealth = Player.CurrentMaxHealth;
        }
        heartManager.UpdateHearts();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
