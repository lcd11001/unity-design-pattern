using System.Collections;
using UnityEngine;

public class NinjaJumpState : NinjaAbstractState, INinjaState
{
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    private Vector3 velocity;
    private bool isJumping;

    public void Idle(INinjaContext context)
    {
        isJumping = false;
        context.SetState(GetComponent<NinjaIdleState>());
    }
    public void Walk(INinjaContext context)
    {
        isJumping = false;
        context.SetState(GetComponent<NinjaWalkState>());
    }
    public void Crouch(INinjaContext context)
    {
        isJumping = false;
        context.SetState(GetComponent<NinjaCrouchState>());
    }
    public void Jump(INinjaContext context)
    {
        velocity = new Vector3(0, Mathf.Sqrt(jumpHeight * -2 * gravity), 0);
        context.GetAnimator().SetTrigger("Jump");
        isJumping = true;
        StartCoroutine(Jumping(context));
    }

    private IEnumerator Jumping(INinjaContext context)
    {
        while (isJumping)
        {
            // gravity is ^2
            velocity.y += gravity * Time.deltaTime;
            context.GetController().Move(velocity * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Landed on the ground");
        // stop applying gravity whenever we're grounded
        velocity.y = -2f;
        context.GetController().Move(velocity);
    }

    public override bool CheckGrounded(float groundCheckDistance, LayerMask groundMask)
    {
        // is jumping up
        if (velocity.y > 0)
        {
            return false;
        }

        // is falling down
        return base.CheckGrounded(groundCheckDistance, groundMask);
    }
}