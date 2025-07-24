using UnityEngine;

public class DestroyObjectOnCollission : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.parent.gameObject);
    }
}
