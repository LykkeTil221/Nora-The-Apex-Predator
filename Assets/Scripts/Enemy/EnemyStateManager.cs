using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    public bool IsGrounded;

    public EnemyGroundedState GroundedState = new EnemyGroundedState();
    public EnemyAirborneState AirborneState = new EnemyAirborneState();

    public Rigidbody Rigidbody;
    //public PlayerGroundedState groundedState = new PlayerGroundedState();
    private void Start()
    {
        currentState = GroundedState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollission(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
