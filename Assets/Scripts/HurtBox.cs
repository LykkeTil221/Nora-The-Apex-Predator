using UnityEngine;
using UnityEngine.Events;
public class HurtBox : MonoBehaviour
{
    public UnityEvent<Vector3, string, Transform> TakeDamage;
    //public UnityEvent<float, float, string, float> TakeDamage;
    public NyFil ResistanceType;
    public void TakeDamageFuncion(float damage, float stun, float knockBack, string attackID, Transform transform)
    {
        Debug.Log("Took " + damage + " damage");
        TakeDamage.Invoke(new Vector3(damage, stun, knockBack), attackID, transform);
    }
}
