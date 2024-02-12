using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    #region Fields

    private static bool canJump = false;
    private static Quaternion targetRotation = Quaternion.Euler(0, 0, 0);

    #endregion


    #region Business Methods

    internal static void MoveLeft(Rigidbody rb, float movementSpeed)
    {
        rb.velocity = new Vector3(
                -movementSpeed,
                rb.velocity.y,
                rb.velocity.z
            );

        targetRotation = Quaternion.Euler(0, 270, 0);
    }

    internal static void MoveRight(Rigidbody rb, float movementSpeed)
    {
        rb.velocity = new Vector3(
                movementSpeed,
                rb.velocity.y,
                rb.velocity.z
            );

        targetRotation = Quaternion.Euler(0, 90, 0);
    }

    internal static void MoveForward(Rigidbody rb, float movementSpeed)
    {
        rb.velocity = new Vector3(
                rb.velocity.x,
                rb.velocity.y,
                movementSpeed
            );

        targetRotation = Quaternion.Euler(0, 0, 0);
    }

    internal static void MoveBackward(Rigidbody rb, float movementSpeed)
    {
        rb.velocity = new Vector3(
                rb.velocity.x,
                rb.velocity.y,
                -movementSpeed
            );

        targetRotation = Quaternion.Euler(0, 180, 0);
    }

    internal static void Rotate(GameObject playerModel, float rotationSpeed)
    {
        playerModel.transform.rotation = Quaternion.Lerp(
            playerModel.transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    internal static void Jump(Rigidbody rb, float jumpSpeed)
    {
        CheckCanJump(rb.transform.position, 1.01f);
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            rb.velocity = new Vector3(
                    rb.velocity.x,
                    jumpSpeed,
                    rb.velocity.z
                );
        }
    }

#endregion


    #region Utility Functions

    private static void CheckCanJump(
        Vector3 position,
        float rayLength
    )
    {
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit, rayLength))
        {
            canJump = true;
        }
    }

    #endregion
}
