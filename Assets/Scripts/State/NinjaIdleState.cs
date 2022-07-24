using UnityEngine;

public class NinjaIdleState : NinjaAbstractState, INinjaState
{
    public void Idle(INinjaContext context)
    {
        context.GetController().Move(Vector3.zero);
        context.GetAnimator().SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    public void Walk(INinjaContext context)
    {
        // context.SetState(new NinjaWalkState());

        var walkState = GetComponent<NinjaWalkState>();
        context.SetState(walkState);

        // walkState.Walk(context);
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