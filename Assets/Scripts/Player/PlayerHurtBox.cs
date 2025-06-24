using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHurtBox : MonoBehaviour
{
    [SerializeField] private PlayerStateManager playerManager;
    public void TakeDamage(int damage)
    {
        Debug.Log("Player took " + damage + " damage");
        playerManager.CurrentPlayerHealth -= damage;
        if (playerManager.CurrentPlayerHealth <= 0)
        {
            Debug.Log("Player is Defeated");
            SceneManager.LoadScene(0);
        }
    }
}
