using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerVariableContainer PlayerVars;

    public Vector3 MoveVector;

    PlayerBaseState currentState;
    public PlayerGroundedState groundedState = new PlayerGroundedState();
    public PlayerAirborneState airborneState = new PlayerAirborneState();
    public PlayerDodgeState dodgeState = new PlayerDodgeState();
    public PlayerAttackState attackState = new PlayerAttackState();
    public PlayerGrappleState grappleState = new PlayerGrappleState();
    public PlayerAttackAirState airAttackState = new PlayerAttackAirState();
    public PlayerStunned stunState = new PlayerStunned();
    public PlayerGrabbingState grabbingState = new PlayerGrabbingState();

    public PlayerSolarPulseState solarPulseState = new PlayerSolarPulseState();
    public PlayerFireBall fireBallState = new PlayerFireBall();

    public Rigidbody Rigidbody;
    public bool IsGrounded = true;
    public PlayerEnergy EnergyManager;
    public PlayerDamageManager HealthManager;

    public Camera PlayerCamera;
    public Vector3 ForceDirection;
    public Vector3 MoveDirection;

    [SerializeField] private MeshRenderer playerRenderer;
    [SerializeField] private Material regularMaterial;
    [SerializeField] private Material startupMaterial;
    [SerializeField] private Material actionMaterial;
    [SerializeField] private Material endMaterial;
    [SerializeField] private Material stunMaterial;

    public GameObject LeftArmCollider;
    public GameObject RightArmCollider;
    public GameObject AirAttackCollider;
    public GameObject GrappleCollider;
    public GameObject SolarPulseCollider;
    public GameObject FireBall;

    public float extraHearts;
    public float currentHeartAmount;
    public float CurrentMaxHealth;
    public float CurrentPlayerHealth;
    public float CurrentPlayerUnstoppable;

    public Transform projectileThrowPoint;

    [SerializeField] GameObjectScrub PlayerReference;

    public Rigidbody PlayerGrappleArmRigidBody;

    [SerializeField] public PlayerAttackVariables Attacks;
    [SerializeField] public string AbsorbAttackName;

    public PlayerUnlockManager unlockManager;
    public PlayerEnergy energy;

    public PlayerBaseState currentLeftSpecial;
    public PlayerBaseState currentRightSpecial;

    public Transform currentSpawnPosition;
    private void Awake()
    {
        SetMaxHealth();
        
        CurrentPlayerUnstoppable = PlayerVars.Unstoppable;

        //currentLeftSpecial = solarPulseState;
        //currentRightSpecial = fireBallState;

        PlayerCheckPoint.setCheckpoint += SetCheckpoint;
        PlayerRespawnManager.RespawnPlayer += OnPlayerRespawn;
    }
    private void Start()
    {
        PlayerReference.GameObject = gameObject;
        print("GroundedState");
        currentState = groundedState;

        currentState.EnterState(this);

        CurrentPlayerHealth = PlayerVars.PlayerStartingHearts * PlayerVars.HeartValue;
        CurrentPlayerUnstoppable = PlayerVars.Unstoppable;
    }
    private void Update()
    {
        currentState.UpdateState(this);

        MoveDirection = GetCameraforward(PlayerCamera) * MoveVector.y + GetCameraRight(PlayerCamera) * MoveVector.x;

        ForceDirection += MoveVector.x * GetCameraRight(PlayerCamera) * PlayerVars.MoveSpeed;
        ForceDirection += MoveVector.y * GetCameraforward(PlayerCamera) * PlayerVars.MoveSpeed;
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        MoveVector = context.ReadValue<Vector2>();
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void SwitchToNeutralState()
    {
        if (IsGrounded)
        {
            SwitchState(groundedState);
        }
        else
        {
            SwitchState(airborneState);
        }
    }

    public void ChangePlayerMaterial(int State)
    {
        if(State == 0)
        {
            playerRenderer.material = regularMaterial;
        }
        if (State == 1)
        {
            playerRenderer.material = startupMaterial;
        }
        if (State == 2)
        {
            playerRenderer.material = actionMaterial;
        }
        if (State == 3)
        {
            playerRenderer.material = endMaterial;
        }
        if(State == 4)
        {
            playerRenderer.material = stunMaterial;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollissionEnter(this,collision);
    }

    public  void Jump(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Jump Input");
        currentState.Jump(this);
    }
    public void Dodge(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Dodge input");
        currentState.Dodge(this);
    }
    public void LeftPunch(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Left Punch Input");
        currentState.LeftPunch(this);
    }
    public void RightPunch(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Right Punch Input");
        currentState.RightPunch(this);
    }
    public void LeftSpecial(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        if (currentLeftSpecial == null) return;
        print("LeftSpecial input");
        if (currentState == groundedState || currentState == airborneState)
        {
            SwitchState(currentLeftSpecial);
        }
        else if ( currentState == currentLeftSpecial)
        {
            currentState.LeftSpecial(this);
        }
    }
    public void RightSpecial(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        if (currentRightSpecial == null) return;
        print("Right Special input");
        if (currentState == groundedState || currentState == airborneState)
        {
            SwitchState(currentRightSpecial);
        }
        else if ( currentState == currentRightSpecial)
        {
            currentState.RightSpecial(this);
        }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Interact Input");
        currentState.Interact(this);
    }
    public void Cancel(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        print("Cancel Input");
        currentState.Cancel(this);
    }
    public void Stun()
    {
        currentState.Stun(this);
    }

    private Vector3 GetCameraforward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    public void GrabHitEnemy(EnemyStateManager Enemy)
    {
        grappleState.EnemyIsGrabbed(Enemy);
    }
    public void GrabObject(GameObject grabbedObject)
    {
        Debug.Log(grabbedObject + " is grabbed");
        grappleState.ObjectIsGrabbed(grabbedObject);
    }
    public void GrabbedbjectIsDefeated()
    {
       // grabbingState.con
    }
    public void PlayerStunned()
    {
        currentState.Cancel(this);
        SwitchState(stunState);
    }

    public void SetMaxHealth()
    {
        currentHeartAmount = PlayerVars.PlayerStartingHearts + extraHearts;
        CurrentMaxHealth = currentHeartAmount * PlayerVars.HeartValue;
        CurrentPlayerHealth = CurrentMaxHealth;
    }

    private void SetCheckpoint(Transform spawnpoint)
    {
        currentSpawnPosition = spawnpoint;
    }

    public void OnPlayerRespawn()
    {
        SetMaxHealth();
        CurrentPlayerUnstoppable = PlayerVars.Unstoppable;
        CurrentPlayerHealth = PlayerVars.PlayerStartingHearts * PlayerVars.HeartValue;
        CurrentPlayerUnstoppable = PlayerVars.Unstoppable;
        gameObject.transform.position = currentSpawnPosition.transform.position;
        gameObject.transform.rotation = currentSpawnPosition.transform.rotation;
        SwitchToNeutralState();
    }
}
