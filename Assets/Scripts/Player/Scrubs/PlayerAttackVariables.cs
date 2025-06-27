using UnityEngine;
using SnuggleMoth.Library.Core.Wrappers;
[CreateAssetMenu(fileName = "PlayerAttackVariables", menuName = "PlayerAttackVariables")]
public class PlayerAttackVariables : ScriptableObject
{
    public SerializedDictionary<string, Vector2> Attack;
}
