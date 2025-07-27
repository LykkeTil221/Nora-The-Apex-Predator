using UnityEngine;
using SnuggleMoth.Library.Core.Wrappers;
public class HitBox : MonoBehaviour
{
    [SerializeField] private string attackName;
    [SerializeField] PlayerAttackVariables attackVariable;
    [SerializeField] EgenFil DamageType;
    [SerializeField] private float knockBack;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.GetComponent<HurtBox>())
        {
            float damageMultiplier = 1f;
            if (other.GetComponent<HurtBox>().ResistanceType != null) damageMultiplier = other.GetComponent<HurtBox>().ResistanceType.GetResistance(DamageType);
            other.GetComponent<HurtBox>().TakeDamageFuncion(attackVariable.Attack[attackName].x * damageMultiplier, attackVariable.Attack[attackName].y, knockBack , attackName, transform);
        }
        if (other.GetComponent<PlayerCheckPoint>())
        {
            other.GetComponent<PlayerCheckPoint>().ActivateCheckPoint();
        }
    }
}
