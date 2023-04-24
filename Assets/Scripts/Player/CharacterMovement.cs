using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private const float gravityValue = -9.81f;
    private CharacterController controller;
    private Vector3 playerVelocity = new Vector3();
    private bool groundedPlayer;
    [SerializeField]
    private float playerWalkSpeed = 5.0f;
    [SerializeField]
    private float playerRunnSpeed = 10.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        ResetPlayerVelocityY();
        Jump();
        Vector3 move = Move();
        ApplyGravity();
        RotateIntoMoveDirection(move);
    }

    private Vector3 Move()
    {
        float playerSpeed = (Input.GetButton("Run") ? playerRunnSpeed : playerWalkSpeed);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move((move * playerSpeed + playerVelocity) * Time.deltaTime);
        return move;
    }

    private void Jump()
    {
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += jumpHeight * -1f * gravityValue;
        }
    }

    private void ResetPlayerVelocityY()
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    private void ApplyGravity()
    {
        playerVelocity.y += gravityValue * Time.deltaTime;

    }

    private void RotateIntoMoveDirection(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection;
        }
    }
}