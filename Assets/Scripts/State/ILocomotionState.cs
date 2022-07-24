public interface ILocomotionState
{
    void Jump(ILocomotionContext context);
    void Fall(ILocomotionContext context);
    void Land(ILocomotionContext context);
    void Crouch(ILocomotionContext context);
}
