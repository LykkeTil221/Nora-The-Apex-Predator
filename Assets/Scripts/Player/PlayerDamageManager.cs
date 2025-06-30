using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDamageManager : MonoBehaviour
{
    [SerializeField] private PlayerStateManager Player;
    [SerializeField] private float timer;
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
            //Midlertidig
            SceneManager.LoadScene(0);
        }
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
