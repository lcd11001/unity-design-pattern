using UnityEngine;

public class NinjaWalkState : NinjaAbstractState, INinjaState
{
    [SerializeField] private float walkSpeed;
    private Vector3 moveDirection;

    public void Idle(INinjaContext context)
    {
        // context.SetState(new NinjaIdleState());

        var idleState = GetComponent<NinjaIdleState>();
        context.SetState(idleState);

        // idleState.Idle(context);
    }
    public void Walk(INinjaContext context)
    {
        float moveZ = context.GetInput().GetAxisInput("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        // fixed: character move to mouse direction
        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection *= walkSpeed;

        context.GetController().Move(moveDirection * Time.deltaTime);
        context.GetAnimator().SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
    public void Crouch(INinjaContext context)
    {
        // context.SetState(new NinjaCrouchState());

        var crouchState = GetComponent<NinjaCrouchState>(); 
        context.SetState(crouchState);

        // crouchState.Crouch(context);
    }
    public void Jump(INinjaContext context)
    {
        // context.SetState(new NinjaJumpState());

        var jumpState = GetComponent<NinjaJumpState>();
        context.SetState(jumpState);

        jumpState.Jump(context);
    }
}