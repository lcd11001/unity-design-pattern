using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionStatePattern : MonoBehaviour, ILocomotionContext
{
    ILocomotionState currentState = new GroundedState();

    public void Crouch() => currentState.Crouch(this);
    public void Fall() => currentState.Fall(this);
    public void Jump() => currentState.Jump(this);
    public void Land() => currentState.Land(this);

    void ILocomotionContext.SetState(ILocomotionState newState)
    {
        currentState = newState;
    }
}
