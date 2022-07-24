using UnityEngine;

public class NinjaCrouchState : NinjaAbstractState, INinjaState
{
    [SerializeField] private float crouchSpeed;
    private Vector3 moveDirection;

    public void Idle(INinjaContext context)
    {
        var idleState = GetComponent<NinjaIdleState>();
        context.SetState(idleState);
    }
    public void Walk(INinjaContext context)
    {
        var walkState = GetComponent<NinjaWalkState>();
        context.SetState(walkState);
    }
    public void Crouch(INinjaContext context)
    {
        float moveZ = context.GetInput().GetAxisInput("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        // fixed: character move to mouse direction
        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection *= crouchSpeed;

        context.GetController().Move(moveDirection * Time.deltaTime);
        context.GetAnimator().SetFloat("Speed", 1.0f, 0.1f, Time.deltaTime);
    }
    public void Jump(INinjaContext context)
    {
        var jumpState = GetComponent<NinjaJumpState>();
        context.SetState(jumpState);

        jumpState.Jump(context);
    }
}