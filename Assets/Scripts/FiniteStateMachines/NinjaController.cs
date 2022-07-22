using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float crouchSpeed;

    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;
    private bool isGrounded;

    private Vector3 moveDirection;
    private Vector3 velocity;
    private float moveSpeed;

    private CharacterController characterController;
    private IInputController inputController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputController = GetComponent<IInputController>();
    }

    private void Update()
    {
        Move();
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
    }

    private void Move()
    {
        CheckGrounded();
        if (isGrounded && velocity.y < 0)
        {
            // stop applying gravity whenever we're grounded
            velocity.y = -2f;
        }

        float moveZ = inputController.GetAxisInput("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        // fixed: character move to mouse direction
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero)
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

            moveDirection *= moveSpeed;

            if (inputController.GetKeyDownInput(KeyCode.Space))
            {
                Jump();
            }
        }

        characterController.Move(moveDirection * Time.deltaTime);

        // gravity is ^2
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        moveSpeed = 0;
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
    }

    private void Crouch()
    {
        moveSpeed = crouchSpeed;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
