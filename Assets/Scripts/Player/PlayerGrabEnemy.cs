using UnityEngine;
using UnityEngine.Events;
public class PlayerGrabEnemy : MonoBehaviour
{
    [SerializeField] UnityEvent<EnemyStateManager> GrabEnemy;
    public EnemyStateManager currentGrabbedEnemy;
    [SerializeField] private Transform player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentGrabbedEnemy = other.transform.parent.GetComponent<EnemyStateManager>();
            GrabEnemy.Invoke(currentGrabbedEnemy);
            currentGrabbedEnemy.SwitchState(currentGrabbedEnemy.GrabbedState);
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,player.position.y, transform.position.z);
    }

    public void ReleaseEnemy()
    {
        currentGrabbedEnemy.SwitchToNeutralState();
    }
}
