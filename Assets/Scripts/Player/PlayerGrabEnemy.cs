using UnityEngine;
using UnityEngine.Events;
public class PlayerGrabEnemy : MonoBehaviour
{
    [SerializeField] UnityEvent<EnemyStateManager> GrabEnemy;
    [SerializeField] UnityEvent<LockDamageManager> GrabObject;
    public EnemyStateManager currentGrabbedEnemy;
    public LockDamageManager currentGrabbedObject;
    [SerializeField] private Transform player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentGrabbedEnemy = other.transform.parent.GetComponent<EnemyStateManager>();
            GrabEnemy.Invoke(currentGrabbedEnemy);
            currentGrabbedEnemy.SwitchState(currentGrabbedEnemy.GrabbedState);
        }
        if (other.CompareTag("Object"))
        {
            Debug.Log("Arm hit obect");
            currentGrabbedObject = other.transform.parent.GetComponent<LockDamageManager>();
            GrabObject.Invoke(currentGrabbedObject);
        }
    }

    private void FixedUpdate()
    {
       // transform.position = new Vector3(transform.position.x,player.position.y, transform.position.z);
    }

    public void ReleaseEnemy()
    {
        currentGrabbedEnemy.SwitchState(currentGrabbedEnemy.GroundedState);
    }
}
