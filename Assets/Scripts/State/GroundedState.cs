public class GroundedState : ILocomotionState
{
    public void Jump(ILocomotionContext context)
    {
        context.SetState(new InAirState());
    }
    public void Fall(ILocomotionContext context)
    {
        context.SetState(new InAirState());
    }
    public void Land(ILocomotionContext context)
    {
        // do  nothing on grounded
    }
    public void Crouch(ILocomotionContext context)
    {
        context.SetState(new CrouchingState());
    }
}
