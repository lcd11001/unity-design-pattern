public class CrouchingState : ILocomotionState
{
    public void Jump(ILocomotionContext context)
    {
        context.SetState(new GroundedState());
    }
    public void Fall(ILocomotionContext context)
    {
        context.SetState(new InAirState());
    }
    public void Land(ILocomotionContext context)
    {
        // do nothing
    }
    public void Crouch(ILocomotionContext context)
    {
        context.SetState(new GroundedState());
    }
}
