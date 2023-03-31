using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerWalkSpeed = 5.0f;
    [SerializeField]
    private float playerRunnSpeed = 10.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    private const float gravityValue = -9.81f;

    void Start()
    {
       controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {

        groundedPlayer = controller.isGrounded;
        StopFall();
        Movement();
    }

    private void StopFall()
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    private void Movement()
    {
        // x and z axis movement
        float playerSpeed = (Input.GetButton("Run") ? playerRunnSpeed : playerWalkSpeed);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // y axis movement
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;

        controller.Move((move * playerSpeed + playerVelocity) * Time.deltaTime);

        // Object Rotation by changing the forward vector
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

}
