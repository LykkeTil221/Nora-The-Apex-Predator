using UnityEngine;

public class EnemyGroundCheck : MonoBehaviour
{
    public EnemyStateManager stateManager;

    [SerializeField] private Vector3 GCYPoint;
    [SerializeField] private float GCPositionModifier;
    [SerializeField] private LayerMask isGroundLayer;
    [SerializeField] private float maxDistanceForGroundCheck;
    private void Update()
    {
        GroundCheckFunction();
    }

    private void GroundCheckFunction()
    {
        Vector3 direction = Vector3.down;
        Vector3 origin1 = transform.position + new Vector3(-GCYPoint.x, GCYPoint.y, GCYPoint.z);
        Vector3 origin2 = transform.position + new Vector3(GCYPoint.x, GCYPoint.y, GCYPoint.z);
        Vector3 origin3 = transform.position + new Vector3(-GCYPoint.x, GCYPoint.y, -GCYPoint.z);
        Vector3 origin4 = transform.position + new Vector3(GCYPoint.x, GCYPoint.y, -GCYPoint.z);

        //Debug.DrawRay(origin2, direction * maxDistanceForGroundCheck.Value, Color.red);

        bool isGrounded1 = Physics.Raycast(origin1, direction, maxDistanceForGroundCheck, isGroundLayer);
        Debug.DrawRay(origin1, direction * maxDistanceForGroundCheck, Color.red);
        bool isGrounded2 = Physics.Raycast(origin2, direction, maxDistanceForGroundCheck, isGroundLayer);
        Debug.DrawRay(origin2, direction * maxDistanceForGroundCheck, Color.red);
        bool isGrounded3 = Physics.Raycast(origin3, direction, maxDistanceForGroundCheck, isGroundLayer);
        Debug.DrawRay(origin3, direction * maxDistanceForGroundCheck, Color.red);
        bool isGrounded4 = Physics.Raycast(origin4, direction, maxDistanceForGroundCheck, isGroundLayer);
        Debug.DrawRay(origin4, direction * maxDistanceForGroundCheck, Color.red);

        if (isGrounded1 || isGrounded2 || isGrounded3 || isGrounded4)
        {
            stateManager.IsGrounded = true;
        }
        else
        {
            stateManager.IsGrounded = false;
        }
    }
}
