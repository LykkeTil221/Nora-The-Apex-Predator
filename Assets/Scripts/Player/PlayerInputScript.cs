using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    public Vector2 moveVector;
    public void MoveInput(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    public void JumpInput()
    {
        print("Jump Input");
    }
    public void LeftAttack()
    {

    }
    public void RightAttack()
    {

    }
    public void LeftSpecial()
    {

    }
    public void RightSpecial()
    {

    }
    public void DodgeInput()
    {

    }
    public void InterractInput()
    {

    }
    public void PauseInput()
    {

    }
    public void SwitchSpecial()
    {

    }
    public void CancelInput()
    {

    }
    public void LockOnInput()
    {

    }
}
