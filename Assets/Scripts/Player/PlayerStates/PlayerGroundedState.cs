using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGroundedState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager Player)
    {
        Debug.Log("Hello from the GroundedState!");
        Player.Rigidbody.linearDamping = Player.PlayerVars.GroundDrag;
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        //Speed limit
        Vector3 flatVel = new Vector3(Player.Rigidbody.linearVelocity.x, 0f, Player.Rigidbody.linearVelocity.z);

        if (flatVel.magnitude > Player.PlayerVars.MaxMoveSpeed)
        {
            Vector3 LimitedVel = flatVel.normalized * Player.PlayerVars.MoveSpeed;
            Player.Rigidbody.linearVelocity = new Vector3(LimitedVel.x, Player.Rigidbody.linearVelocity.y, LimitedVel.z);
        }
    }

    public override void FixedUpdateState(PlayerStateManager Player)
    {
        if (!Player.IsGrounded)
        {
            Debug.Log("Player is Airborne");
            Player.SwitchState(Player.airborneState);
        }
        //Move Player


        Player.Rigidbody.AddForce(Player.MoveDirection * Player.PlayerVars.MoveSpeed * 10, ForceMode.Force);

        /*
        if (Player.Rigidbody.linearVelocity.magnitude > Player.PlayerVars.MaxMoveSpeed)
        {
            Vector3 currentVelocity = Player.Rigidbody.linearVelocity;
            currentVelocity.y = 0;
            Vector3 newVelocity = Vector3.ClampMagnitude(currentVelocity, Player.PlayerVars.MaxMoveSpeed);
            float yVelocity = Player.Rigidbody.linearVelocity.y;
            newVelocity.y = yVelocity;

            Player.Rigidbody.linearVelocity = newVelocity;
        }*/

        //Rotate Player
        if (Player.MoveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Player.MoveDirection, Vector3.up);

            Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, toRotation, Player.PlayerVars.RotateSpeed * Time.deltaTime);
        }
        
        //Slowing down
        if(Player.MoveVector.x == 0 && Player.MoveVector.y == 0)
        {
            Player.Rigidbody.linearVelocity = Player.Rigidbody.linearVelocity * Player.PlayerVars.SlowingDownSpeed * Time.deltaTime;
        }
        
    }
    public override void OnCollissionEnter(PlayerStateManager Player, Collision collision)
    {

    }
    public override void Dodge(PlayerStateManager Player)
    {
        Player.SwitchState(Player.dodgeState);
    }

    public override void Interact(PlayerStateManager Player)
    {

    }

    public override void Jump(PlayerStateManager Player)
    {
        Debug.Log("Player Jumped");
        Player.airborneState.didPlayerJump = true;
        Player.SwitchState(Player.airborneState);
    }

    public override void LeftPunch(PlayerStateManager Player)
    {
        Player.SwitchState(Player.attackState);
        Player.attackState.wasLastInputLeft = true;
    }

    public override void LeftSpecial(PlayerStateManager Player)
    {

    }



    public override void RightPunch(PlayerStateManager Player)
    {
        Player.SwitchState(Player.attackState);
        Player.attackState.wasLastInputLeft = false;
    }

    public override void RightSpecial(PlayerStateManager Player)
    {

    }

    public override void Cancel(PlayerStateManager Player)
    {

    }
}
