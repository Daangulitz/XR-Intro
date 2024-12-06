using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 2f;

    private Vector3 moveDirection;

    void Update()
    {
        // Input for 3D movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Define movement direction
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Move the player
        if (moveDirection.magnitude > 0.1f)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);
        }

        // Update the Animator's Speed parameter
        animator.SetFloat("Speed", moveDirection.magnitude * moveSpeed);
    }
}

