using UnityEngine;

public class PlayerGrabbingState : PlayerBaseState
{
    public EnemyStateManager Enemy;
    public bool HasGrabbedEnemy;
    public bool HasGrabbedObject;
    public GameObject Object;
    private float leftTimer;
    private float rightTimer;
    
    public override void EnterState(PlayerStateManager Player)
    {
        if(Enemy != null)
        {
            Player.grappleState.hasGrabbedEnemy = false;
            Player.GrappleCollider.transform.position = Enemy.transform.position;
            Enemy.Rigidbody.isKinematic = true;
        }
        if(Object != null)
        {
            Player.grappleState.hasGrabbedObject = false;
            Player.GrappleCollider.transform.position = Object.transform.position;
        }
        Debug.Log("Grabbing state");
        
        
        Player.PlayerGrappleArmRigidBody.linearVelocity = Vector3.zero;
        Player.PlayerGrappleArmRigidBody.linearVelocity = Vector3.zero;
        

    }


    public override void UpdateState(PlayerStateManager Player)
    {
        if (Player.IsGrounded)
        {
            Player.Rigidbody.linearDamping = Player.PlayerVars.GroundDrag;
        }
        else
        {
            Player.Rigidbody.linearDamping = 0;
        }

        if (leftTimer > 0) leftTimer -= Time.deltaTime;
        if (rightTimer > 0) rightTimer -= Time.deltaTime;

        if (HasGrabbedEnemy && !Enemy)
        {
            Consume(Player);
        }
        if(HasGrabbedObject && !Object)
        {
            Consume(Player);
        }
    }

    public override void FixedUpdateState(PlayerStateManager Player)
    {

    }

    public override void OnCollissionEnter(PlayerStateManager Player, Collision collision)
    {

    }
    public override void Dodge(PlayerStateManager Player)
    {

    }

    public override void Interact(PlayerStateManager Player)
    {

    }

    public override void Jump(PlayerStateManager Player)
    {

    }

    public override void LeftPunch(PlayerStateManager Player)
    {
        if (leftTimer <= 0)
        {
            Debug.Log("LeftAbsorb");
            leftTimer = Player.PlayerVars.AbsorbAttackDuration;
            if (Enemy != null) Enemy.gameObject.GetComponent<EnemyDamageManager>().TakeDamage(Player.Attacks.Attack[Player.AbsorbAttackName].x, Player.Attacks.Attack[Player.AbsorbAttackName].y, Player.AbsorbAttackName);
            if (Object != null) Object.gameObject.GetComponent<LockDamageManager>().TakeDamage(Player.Attacks.Attack[Player.AbsorbAttackName].x, Player.Attacks.Attack[Player.AbsorbAttackName].y, Player.AbsorbAttackName);
        }
    }

    public override void LeftSpecial(PlayerStateManager Player)
    {
        
    }
    public override void RightPunch(PlayerStateManager Player)
    {
        if (rightTimer <= 0)
        {
            Debug.Log("RightAbsorb");
            rightTimer = Player.PlayerVars.AbsorbAttackDuration;
            if (Enemy != null) Enemy.gameObject.GetComponent<EnemyDamageManager>().TakeDamage(Player.Attacks.Attack[Player.AbsorbAttackName].x, Player.Attacks.Attack[Player.AbsorbAttackName].y, Player.AbsorbAttackName);
            if (Object != null) Object.gameObject.GetComponent<LockDamageManager>().TakeDamage(Player.Attacks.Attack[Player.AbsorbAttackName].x, Player.Attacks.Attack[Player.AbsorbAttackName].y, Player.AbsorbAttackName);
        }
    }

    public override void RightSpecial(PlayerStateManager Player)
    {

    }
    public override void Cancel(PlayerStateManager Player)
    {
        if (Enemy != null)
        {
            Enemy.Rigidbody.isKinematic = false;
            Enemy.SwitchToNeutralState();
            Enemy = null;
        }
            
        Player.SwitchState(Player.grappleState);
        Player.grappleState.hasGrabbedEnemy = false;
        Player.grappleState.timer = Player.PlayerVars.GrappleIdleEnd;
        
        Player.grappleState.Enemy = null;
        Player.grappleState.hasGrabbedObject = false;
        Player.grappleState.Object = null;
        Object = null;
        HasGrabbedObject = false;
        HasGrabbedEnemy = false;
    }
    public override void Stun(PlayerStateManager Player)
    {
        if (Enemy != null)
        {
            Enemy.Rigidbody.isKinematic = false;
            Enemy.SwitchToNeutralState();
            Enemy = null;
        }
        Player.GrappleCollider.SetActive(false);
        Enemy.SwitchToNeutralState();
        Player.grappleState.Enemy = null;
        Player.grappleState.hasGrabbedObject = false;
        Player.grappleState.Object = null;
        Object = null;
        HasGrabbedObject = false;
        HasGrabbedEnemy = false;
    }

    private void Consume(PlayerStateManager Player)
    {
        if (HasGrabbedEnemy)
        {
            Player.EnergyManager.MaxGainEnergy();
            float healthGain = Enemy.EnemyStats.Health / Player.PlayerVars.absorbedHealthDivider;
            healthGain = Mathf.Round(healthGain * 10.0f) * 1f;
            Player.HealthManager.HealHeallth(healthGain);
            Debug.Log("PLayer healed " + healthGain);
        }
        if (HasGrabbedObject)
        {
            //Player.EnergyManager.GainEnergy(25);
            
        }

        if (Enemy != null)
        {
            Enemy.Rigidbody.isKinematic = false;
            Enemy.SwitchToNeutralState();
            Enemy = null;
        }

        Player.SwitchState(Player.grappleState);
        Player.grappleState.hasGrabbedEnemy = false;
        Player.grappleState.timer = Player.PlayerVars.GrappleIdleEnd;

        Player.grappleState.Enemy = null;
        Player.grappleState.hasGrabbedObject = false;
        Player.grappleState.Object = null;
        Object = null;
        HasGrabbedObject = false;
        HasGrabbedEnemy = false;
    }
}
