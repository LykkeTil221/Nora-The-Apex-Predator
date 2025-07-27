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
    public void TakeDamage(Vector3 damageStunKnockBack, string attackID, Transform direction)
    {
        if (isDestroyed) return;
        if (Discriminates)
        {
            if (AcceptableAttacks.Contains(attackID))
            {
                ObjectIsHit(direction);
                Health -= damageStunKnockBack.x;
                if (Health <= 0)
                {
                    DestroyObject(direction);
                }
            }
            else
            {
                Debug.Log("attack did nothing");
            }
        }
        else
        {
            ObjectIsHit(direction);
            Health -= damageStunKnockBack.x;
            if (Health <= 0)
            {
                DestroyObject(direction);
            }
        }
        
    }
    private void ObjectIsHit(Transform direction)
    {
        animator.playbackTime = 0;
        animator.Play("CrystalIdle");
        animator.Play("CrystalHit");
        hitParticle.transform.rotation = direction.rotation;

        hitParticle.Emit(HitParticleAmount);
    }

    private void DestroyObject(Transform direction)
    {
        isDestroyed = true;
        visual.SetActive(false);
        hitParticle.transform.rotation = direction.rotation;
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
