using UnityEngine;

public class LockDamageManager : MonoBehaviour
{
    [SerializeField] private float Health;
    [SerializeField] private string[] AcceptableAttacks;
    [SerializeField] private bool Discriminates;
    public void TakeDamage(float damage, float stun)
    {
        if (Discriminates)
        {

        }
        else
        {
            Health -= damage;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
