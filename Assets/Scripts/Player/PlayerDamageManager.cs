using UnityEngine;

public class PlayerDamageManager : MonoBehaviour
{
    [SerializeField] private PlayerStateManager Player;
    public void TakeDamage(float damage, float stun)
    {
        Debug.Log("Player took" + damage + "damage with" + stun + "stun");
        Player.CurrentPlayerHealth -= damage;
        if(stun > Player.PlayerVars.Unstoppable)
        {
            Debug.Log("Stunned");
        }

        if(Player.CurrentPlayerHealth <= 0)
        {
            Debug.Log("Player is defeated");
        }
    }
}
