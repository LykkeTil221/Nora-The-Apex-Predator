using UnityEngine;

public class PlayerGrabbingState : PlayerBaseState
{
    public EnemyStateManager Enemy;
    public bool HasGrabbedEnemy;
    public bool HasGrabbedObject;
    public LockDamageManager Object;
    private float leftTimer;
    private float rightTimer;


    public override void EnterState(PlayerStateManager Player)
    {
        Player.CurrentPlayerUnstoppable += Player.PlayerVars.GrappleUnstoppableNegativeBonus;
        if(Enemy != null)
        {
            Player.grappleState.hasGrabbedEnemy = false;
            Player.GrappleCollider.transform.position = Enemy.transform.position;
            Enemy.Rigidbody.isKinematic = true;
            Debug.Log("Grabbed Enemy");
            Debug.Log(Enemy);
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
        Debug.Log(Enemy);
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

        if (HasGrabbedEnemy && !Enemy.gameObject.activeSelf)
        {
            Debug.Log("Consumed Enemy");
            Consume(Player);
        }
        if(HasGrabbedObject && Object.isDestroyed)
        {
            Debug.Log("Consumed Object");
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
            if (Enemy != null)
            {
                Enemy.gameObject.GetComponent<EnemyDamageManager>().TakeDamage(new Vector3(Player.Attacks.Attack[Player.AbsorbAttackName].x, Player.Attacks.Attack[Player.AbsorbAttackName].y,0), Player.AbsorbAttackName, Player.transform);
            }
            
            if (Object != null) Object.TakeDamage(new Vector3(Player.Attacks.Attack[Player.AbsorbAttackName].x, Player.Attacks.Attack[Player.AbsorbAttackName].y, 0), Player.AbsorbAttackName, Player.transform);
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
            if (Enemy != null) Enemy.gameObject.GetComponent<EnemyDamageManager>().TakeDamage(new Vector3(Player.Attacks.Attack[Player.AbsorbAttackName].x, Player.Attacks.Attack[Player.AbsorbAttackName].y, 0), Player.AbsorbAttackName, Player.transform);
            if (Object != null) Object.TakeDamage(new Vector3(Player.Attacks.Attack[Player.AbsorbAttackName].x, Player.Attacks.Attack[Player.AbsorbAttackName].y, 0), Player.AbsorbAttackName, Player.transform);
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
        Player.CurrentPlayerUnstoppable -= Player.PlayerVars.GrappleUnstoppableNegativeBonus;
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
        Player.grappleState.Enemy = null;
        Player.grappleState.hasGrabbedObject = false;
        Player.grappleState.Object = null;
        Object = null;
        HasGrabbedObject = false;
        HasGrabbedEnemy = false;
        Player.CurrentPlayerUnstoppable -= Player.PlayerVars.GrappleUnstoppableNegativeBonus;
        Player.GrappleCollider.SetActive(false);
        Enemy.SwitchToNeutralState();
    }

    public void Consume(PlayerStateManager Player)
    {
        Debug.Log("Consume");
        if (HasGrabbedEnemy)
        {
            Player.EnergyManager.MaxGainEnergy();
            float healthGain = Enemy.EnemyStats.Health / Player.PlayerVars.absorbedHealthDivider;
            healthGain = Mathf.Ceil(healthGain);
            Player.HealthManager.HealHeallth(healthGain);
            Debug.Log("PLayer healed " + healthGain);
            if(Enemy.EnemyStats.enemyEssense == EnemyVariablesScrub.EnemyEssense.QHeart)
            {
                Player.unlockManager.CollectEssence(true, 1);

            }
            if (Enemy.EnemyStats.enemyEssense == EnemyVariablesScrub.EnemyEssense.FullHeart)
            {
                Player.unlockManager.CollectEssence(true, 4);

            }
            if (Enemy.EnemyStats.enemyEssense == EnemyVariablesScrub.EnemyEssense.QEnergy)
            {
                Player.unlockManager.CollectEssence(false, 1);
            }
            if (Enemy.EnemyStats.enemyEssense == EnemyVariablesScrub.EnemyEssense.FullEnergy)
            {
                Player.unlockManager.CollectEssence(false, 4);
            }
            if(Enemy.EnemyStats.enemyMutation == EnemyVariablesScrub.EnemyMutation.SolarPulse)
            {
                Debug.Log("Consumed enemy with Solar Pulse");
                Player.unlockManager.UnlockSolarPulse();
            }
            if (Enemy.EnemyStats.enemyMutation == EnemyVariablesScrub.EnemyMutation.Fireball)
            {
                Debug.Log("Consumed enemy with FireBall");
                Player.unlockManager.UnlockFireBall();
            }
        }
        if (HasGrabbedObject)
        {
            //Player.EnergyManager.GainEnergy(25);
            Debug.Log("PlayerConsumedObject");
            if (Object.isFruit)
            {
                Player.EnergyManager.MaxGainEnergy();
                Player.HealthManager.HealHeallth(4*4);
            }
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
        Player.CurrentPlayerUnstoppable -= Player.PlayerVars.GrappleUnstoppableNegativeBonus;
    }
}
