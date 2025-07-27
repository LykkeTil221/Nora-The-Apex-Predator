using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LockDamageManager : MonoBehaviour
{
    public bool isFruit;
    [SerializeField] private float Health;
 
    [SerializeField] private List<string> AcceptableAttacks;
    [SerializeField] private bool Discriminates;

    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem hitParticle;
    [HideInInspector] public bool isDestroyed;

    [SerializeField] GameObject visual;
    [SerializeField] Collider PhysicsCollider;
    [SerializeField] Collider damageCollider;

    float timer;
    [SerializeField] private float DeathTime = 1;

    [SerializeField] private int HitParticleAmount;
    [SerializeField] private int DestroyedParticleAmount;
    public void TakeDamage(float damage, float stun, string attackID)
    {
        if (isDestroyed) return;
        if (Discriminates)
        {
            if (AcceptableAttacks.Contains(attackID))
            {
                ObjectIsHit();
                Health -= damage;
                if (Health <= 0)
                {
                    DestroyObject();
                }
            }
            else
            {
                Debug.Log("attack did nothing");
            }
        }
        else
        {
            ObjectIsHit();
            Health -= damage;
            if (Health <= 0)
            {
                DestroyObject();
            }
        }
        
    }
    private void ObjectIsHit()
    {
        animator.playbackTime = 0;
        animator.Play("CrystalIdle");
        animator.Play("CrystalHit");
        hitParticle.Emit(HitParticleAmount);
    }

    private void DestroyObject()
    {
        isDestroyed = true;
        visual.SetActive(false);
        hitParticle.Emit(DestroyedParticleAmount);
        timer = DeathTime;
        PhysicsCollider.enabled = false;
        damageCollider.enabled = false;
    }
    private void Update()
    {
        if (isDestroyed)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
