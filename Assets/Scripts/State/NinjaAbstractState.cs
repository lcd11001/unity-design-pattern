using UnityEngine;
public abstract class NinjaAbstractState : MonoBehaviour
{
    public virtual bool CheckGrounded(float groundCheckDistance, LayerMask groundMask)
    {
        return Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
    }
}