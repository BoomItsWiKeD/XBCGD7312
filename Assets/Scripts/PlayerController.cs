using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f; // Movement speed
    public float jumpForce = 5f; // Jump force
    public float gravity = -9.8f; // Gravity value
    public CharacterController controller; // Reference to CharacterController component

    private Vector3 velocity; // Store current velocity
    private bool isGrounded; // Check if player is grounded

    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController is missing from the GameObject!");
        }
    }

    void Update()
    {
       
        isGrounded = controller.isGrounded;

        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrow

        
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        
        if (move.magnitude > 0.1f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        
        controller.Move(move * moveSpeed * Time.deltaTime);

        
        if (move.magnitude < 0.1f && isGrounded)
        {
            velocity.x = 0f;
            velocity.z = 0f;
        }

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}