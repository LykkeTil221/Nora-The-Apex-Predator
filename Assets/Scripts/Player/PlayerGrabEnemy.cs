using UnityEngine;
using UnityEngine.Events;
public class PlayerGrabEnemy : MonoBehaviour
{
    [SerializeField] UnityEvent<EnemyStateManager> GrabEnemy;
    [SerializeField] UnityEvent<GameObject> GrabObject;
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
        if (other.CompareTag("Object"))
        {
            Debug.Log("Arm hit obect");
            GrabObject.Invoke(other.transform.parent.gameObject);
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
