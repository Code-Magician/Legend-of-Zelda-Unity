using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject model;

    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float jumpVelocity;
    [SerializeField] float rotationSpeed;

    bool canJump = false;
    Quaternion targetRotation = Quaternion.Euler(0, 0, 0);


    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        speed = 5f;
        jumpVelocity = 5f;
        rotationSpeed = 5f;
    }

    void Update()
    {
        ProcessInput();

        // Rotating the Player in from current rotation to targetRotation.
        model.transform.rotation = Quaternion.Lerp(
                model.transform.rotation, 
                targetRotation, 
                rotationSpeed * Time.deltaTime
            );

        // Casting Ray Downwards to check if player can jump.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.01f))
        {
            canJump = true;
        }
    }

    // Handling the movement of player.
    void ProcessInput()
    {
        // Stopping the player to move in XZ plane.
        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        // Moving In +X axis
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(
                    speed,
                    rb.velocity.y,
                    rb.velocity.z
                );

            targetRotation = Quaternion.Euler(0, 90, 0);
        }

        // Moving in -X axis.
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(
                    -speed,
                    rb.velocity.y,
                    rb.velocity.z
                );

            targetRotation = Quaternion.Euler(0, 270, 0);
        }

        // Moving in +Z axis.
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(
                    rb.velocity.x,
                    rb.velocity.y,
                    speed
                );

            targetRotation = Quaternion.Euler(0, 0, 0);
        }

        // Moving in -Z axis.
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(
                    rb.velocity.x,
                    rb.velocity.y,
                    -speed
                );

            targetRotation = Quaternion.Euler(0, 180, 0);
        }

        // Jumping in +Y axis.
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            rb.velocity = new Vector3(
                    rb.velocity.x,
                    jumpVelocity,
                    rb.velocity.z
                );
        }
    }
}
