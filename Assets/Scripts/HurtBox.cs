using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField] private int Health = 4;
    public void TakeDamage(int damage)
    {
        Debug.Log("Took " + damage + " damage");
        Health -= damage;
        if(Health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
