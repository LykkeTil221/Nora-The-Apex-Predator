using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LockDamageManager : MonoBehaviour
{
    [SerializeField] private float Health;
 
    [SerializeField] private List<string> AcceptableAttacks;
    [SerializeField] private bool Discriminates;
    public void TakeDamage(float damage, float stun, string attackID)
    {
        if (Discriminates)
        {
            if (AcceptableAttacks.Contains(attackID))
            {
                Health -= damage;
                if (Health <= 0)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("attack did nothing");
            }
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
