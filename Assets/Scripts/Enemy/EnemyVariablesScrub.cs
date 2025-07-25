using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/EnemyStats")]
public class EnemyVariablesScrub : ScriptableObject
{
    [Header("Enemy Stats")]
    public float Health;
    public float Unstoppable;
    public float StunDuration;
    public float IFrameDuration;
    [Header("Movement Variables")]
    public float MoveSpeed;
    public float RotateSpeed;
    public float DetectRotateSpeed;
    [Header("Drag")]
    public float GroundDrag;
    public float AirDrag;
    [Header("Player Reference")]
    public GameObjectScrub playerObject;
    [Header("Player Detection")]
    public Vector3 SweetSpotRange;
    public float attentionSpan;
    [Header("Unique Properties")]
    public EnemyMutation enemyMutation;
    public EnemyEssense enemyEssense;

    public enum EnemyMutation
    {
        None,
        SolarPulse,
        RocketPunch,
        Fireball,
        Boulder,
    }
    public enum EnemyEssense
    {
        None,
        QHeart,
        FullHeart,
        QEnergy,
        FullEnergy,
    }
}
