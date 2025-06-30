using UnityEngine;
using UnityEngine.Events;
public class PlayerGrabEnemy : MonoBehaviour
{
    [SerializeField] UnityEvent<EnemyStateManager> GrabEnemy;
    private EnemyStateManager currentGrabbedEnemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentGrabbedEnemy = other.GetComponent<EnemyStateManager>();
            GrabEnemy.Invoke(currentGrabbedEnemy);
        }
    }

    public void ReleaseEnemy()
    {
        currentGrabbedEnemy.SwitchToNeutralState();
    }
}
