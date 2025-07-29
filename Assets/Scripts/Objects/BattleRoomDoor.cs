using UnityEngine;

public class BattleRoomDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Awake()
    {
        BattleRoomController.openBattleDoor += ChangeDoorState;
    }
    public void ChangeDoorState(bool Open)
    {
        animator.SetBool("Open", Open);
    }
    private void OnDisable()
    {
        BattleRoomController.openBattleDoor -= ChangeDoorState;
    }
}
