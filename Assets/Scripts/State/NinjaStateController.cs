using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class NinjaStateController : MonoBehaviour, INinjaContext
{
    private CharacterController characterController;
    private IInputController inputController;
    private Animator anim;

    private INinjaState currentState;
    private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;

    #region INinjaContext implements
    // make it private as only class implement INinjaState can call these functions
    Animator INinjaContext.GetAnimator()
    {
        return anim;
    }

    CharacterController INinjaContext.GetController()
    {
        return characterController;
    }

    IInputController INinjaContext.GetInput()
    {
        return inputController;
    }

    void INinjaContext.SetState(INinjaState newState)
    {
        if (newState == null) throw new ArgumentNullException("newState");
        currentState = newState;

        Debug.Log($"set state {newState}");
    }

    #endregion

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputController = GetComponent<IInputController>();
        anim = GetComponentInChildren<Animator>();

        // because all states are inherit from Monobehaviour
        // so that, we can not use new operator
        currentState = GetComponent<NinjaIdleState>();
    }

    private void Idle() => currentState.Idle(this);
    private void Walk() => currentState.Walk(this);
    private void Crouch() => currentState.Crouch(this);
    private void Jump() => currentState.Jump(this);

    private void Update()
    {
        isGrounded = currentState.CheckGrounded(groundCheckDistance, groundMask);
        float moveZ = inputController.GetAxisInput("Vertical");

        if (isGrounded)
        {
            if (moveZ != 0)
            {
                if (inputController.GetKeyInput(KeyCode.LeftControl))
                {
                    Crouch();
                }
                else
                {
                    Walk();
                }
            }
            else
            {
                Idle();
            }

            if (inputController.GetKeyDownInput(KeyCode.Space))
            {
                Jump();
            }
        }
    }
}