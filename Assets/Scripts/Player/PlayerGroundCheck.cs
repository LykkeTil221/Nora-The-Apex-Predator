using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public PlayerStateManager stateManager;

    [SerializeField] private Vector3 GCYPoint;
    [SerializeField] private float GCPositionModifier;
    [SerializeField] private LayerMask isGroundLayer;
    [SerializeField] private float maxDistanceForGroundCheck;

    [SerializeField] private Transform FR;
    [SerializeField] private Transform FL;
    [SerializeField] private Transform BR;
    [SerializeField] private Transform BL;
    private void Update()
    {
        GroundCheckFunction();
    }

    private void GroundCheckFunction()
    {
        Vector3 direction = Vector3.down;
        Vector3 origin1 = transform.position + FR.position;
        Vector3 origin2 = transform.position + FL.position;
        Vector3 origin3 = transform.position + BR.position;
        Vector3 origin4 = transform.position + BL.position;

        //Debug.DrawRay(origin2, direction * maxDistanceForGroundCheck.Value, Color.red);

        bool isGrounded1 = Physics.Raycast(FR.position, direction, maxDistanceForGroundCheck, isGroundLayer);
        Debug.DrawRay(origin1, direction * maxDistanceForGroundCheck, Color.red);
        bool isGrounded2 = Physics.Raycast(FL.position, direction, maxDistanceForGroundCheck, isGroundLayer);
        Debug.DrawRay(origin2, direction * maxDistanceForGroundCheck, Color.red);
        bool isGrounded3 = Physics.Raycast(BR.position, direction, maxDistanceForGroundCheck, isGroundLayer);
        Debug.DrawRay(origin3, direction * maxDistanceForGroundCheck, Color.red);
        bool isGrounded4 = Physics.Raycast(BL.position, direction, maxDistanceForGroundCheck, isGroundLayer);
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
