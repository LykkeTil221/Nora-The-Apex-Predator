using UnityEngine;
using UnityEngine.Events;
public class HurtBox : MonoBehaviour
{
    public UnityEvent<float, float> TakeDamage;
    public void TakeDamageFuncion(float damage, float stun)
    {
        Debug.Log("Took " + damage + " damage");
        TakeDamage.Invoke(damage, stun);
    }
}
