using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    public bool IsGrounded;

    public EnemyGroundedState GroundedState = new EnemyGroundedState();
    public EnemyAirborneState AirborneState = new EnemyAirborneState();
    public EnemyDetectPlayerState DetectState = new EnemyDetectPlayerState();
    public EnemyStunnedState StunnedState = new EnemyStunnedState();
    public EnemyGrabbedState GrabbedState = new EnemyGrabbedState();

    public EnemyBaseState[] Attacks;
    public EnemyBaseState currentAttackState;

    public Rigidbody Rigidbody;
    public EnemyVariablesScrub EnemyStats;

    public bool PlayerIsDetected;

    public float currentHealth;
    
    //public PlayerGroundedState groundedState = new PlayerGroundedState();

    public GameObject ExplamationMark;
    public int currentAttack = 0;
    private void Awake()
    {
        //currentAttackState = Attacks[currentAttack];
    }
    private void Start()
    {
        currentState = GroundedState;
        currentHealth = EnemyStats.Health;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.Update(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate(this);
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

    public void Stunned()
    {
        SwitchState(StunnedState);
    }

    public void SwitchToNeutralState()
    {
        if (IsGrounded)
        {
            SwitchState(GroundedState);
        }
        else
        {
            SwitchState(AirborneState);
        }
    }

    public void PerformNextAttack()
    {
        currentAttackState = Attacks[currentAttack]; 
        currentAttack += 1;
        if (currentAttack > Attacks.Length) currentAttack = 0;
    }
}
