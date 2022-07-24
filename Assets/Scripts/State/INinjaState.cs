using UnityEngine;
public interface INinjaState
{
    void Idle(INinjaContext context);
    void Walk(INinjaContext context);
    void Crouch(INinjaContext context);
    void Jump(INinjaContext context);

    bool CheckGrounded(float groundCheckDistance, LayerMask groundMask);
}