using UnityEngine;
using SnuggleMoth.Library.Core.Wrappers;
public class HitBox : MonoBehaviour
{
    [SerializeField] private string attackName;
    [SerializeField] PlayerAttackVariables attackVariable;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.GetComponent<HurtBox>())
        {
            other.GetComponent<HurtBox>().TakeDamageFuncion(attackVariable.Attack[attackName].x, attackVariable.Attack[attackName].y, attackName);
        }        
    }
}
