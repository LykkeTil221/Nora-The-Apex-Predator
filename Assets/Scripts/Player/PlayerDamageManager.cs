using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageManager : MonoBehaviour
{
    [SerializeField] private PlayerStateManager Player;
    [SerializeField] private float timer;
    [SerializeField] UIHeartManager heartManager;

    public delegate void GameOver(PlayerStateManager player);
    public static GameOver gameOver;
    private void Start()
    {
        PlayerCheckPoint.maxPlayerHealth += HealHeallth;
    }
    public void TakeDamage(Vector3 damageStunKnockBack, string attackID, Transform direction)
    {
        if (timer > 0) return;        
        timer = Player.PlayerVars.IFrames;
        Debug.Log("Player took" + damageStunKnockBack.x + "damage with" + damageStunKnockBack.y + "stun");
        Player.CurrentPlayerHealth -= damageStunKnockBack.x;
        if(damageStunKnockBack.y > Player.CurrentPlayerUnstoppable)
        {
            Debug.Log("Stunned");
            Player.PlayerStunned();
            KnockBack(damageStunKnockBack.z, direction.forward);
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

    private void KnockBack(float knockBack, Vector3 direction)
    {
        Player.Rigidbody.AddForce(direction * knockBack, ForceMode.Impulse);
    }
}
