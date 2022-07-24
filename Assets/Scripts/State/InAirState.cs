public class InAirState : ILocomotionState
{
    public void Jump(ILocomotionContext context)
    {
        // do nothing
    }
    public void Fall(ILocomotionContext context)
    {
        // do nothing
    }
    public void Land(ILocomotionContext context)
    {
        context.SetState(new GroundedState());
    }
    public void Crouch(ILocomotionContext context)
    {
        // do nothing
    }
}
