using UnityEngine;
[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/EnemyStats")]
public class EnemyVariablesScrub : ScriptableObject
{
    [Header("Movement Variables")]
    public float MoveSpeed;
    public float RotateSpeed;
    [Header("Drag")]
    public float GroundDrag;
    public float AirDrag;
    [Header("Player Reference")]
    public GameObjectScrub playerObject;
    [Header("Player Detection")]
    public Vector3 SweetSpotRange;
    public float attentionSpan;
}
