using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    public bool IsGrounded;

    public EnemyGroundedState GroundedState;
    public EnemyAirborneState AirborneState;
    public EnemyDetectPlayerState DetectState;
    public EnemyStunnedState StunnedState;
    public EnemyGrabbedState GrabbedState;

    [SerializeField] public EnemyBaseState[] Attacks;
    public EnemyBaseState currentAttackState;

    public Rigidbody Rigidbody;
    public EnemyVariablesScrub EnemyStats;

    public bool PlayerIsDetected;

    public float currentHealth;
    
    //public PlayerGroundedState groundedState = new PlayerGroundedState();

    public GameObject ExclamationMark;
    public int currentAttack = 0;

    public GameObject AttackCollider;

    public Transform projectileThrowPoint;

    public float timeBetweenAttacks;

    [HideInInspector]public EnemySpawner spawner;

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material regularMaterial;
    [SerializeField] private Material StartupMaterial;
    [SerializeField] private Material ActionMaterial;
    [SerializeField] private Material EndMaterial;
    [SerializeField] private Material StunnedMaterial;
    public bool isGrabbed;
    private void Awake()
    {
        currentAttackState = Attacks[currentAttack];
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
        if(timeBetweenAttacks >= 0)
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
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
        if (timeBetweenAttacks > 0) return;
        currentAttackState = Attacks[currentAttack]; 
        SwitchState(currentAttackState);
        currentAttack += 1;
        if (currentAttack >= Attacks.Length) currentAttack = 0;
    }

    public void OnEnemyDeath()
    {
        spawner.KillEnemy();
        ChangeMaterial(0);
        AttackCollider.SetActive(false);
        
    }

    public void ChangeMaterial(int state)
    {
        switch (state)
        {
            case 0:
                meshRenderer.material = regularMaterial;
                break;
            case 1:
                meshRenderer.material = StartupMaterial;
                break;
            case 2:
                meshRenderer.material = ActionMaterial;
                break;
            case 3:
                meshRenderer.material = EndMaterial;
                break;
            case 4:
                meshRenderer.material = StunnedMaterial;
                break;
        }
            
    }
}
