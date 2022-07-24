using UnityEngine;

public interface INinjaContext
{
    void SetState(INinjaState newState);
    IInputController GetInput();
    Animator GetAnimator();
    CharacterController GetController();
}
