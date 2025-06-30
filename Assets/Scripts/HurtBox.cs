using UnityEngine;
using UnityEngine.Events;
public class HurtBox : MonoBehaviour
{
    public UnityEvent<float, float, string> TakeDamage;
    public void TakeDamageFuncion(float damage, float stun, string attackID)
    {
        Debug.Log("Took " + damage + " damage");
        TakeDamage.Invoke(damage, stun, attackID);
    }
}
