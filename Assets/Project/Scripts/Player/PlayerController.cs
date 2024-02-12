using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WP.Zelda.PlayerScripts
{ 
    public class PlayerController
    {
        #region Fields

        private bool canJump = false;
        private Quaternion targetRotation = Quaternion.Euler(0, 0, 0);

        #endregion


        #region Business Methods

        internal void ProcessMovement(
            Rigidbody rb,
            float movementSpeed
        )
        {
            ProcessMoveLeft(rb, movementSpeed);
            ProcessMoveRight(rb, movementSpeed);
            ProcessMoveForward(rb, movementSpeed);
            ProcessMoveBackward(rb, movementSpeed);
        }

        internal void ProcessRotation(
                GameObject playerModel,
                float rotationSpeed
        )
        {
            playerModel.transform.rotation = Quaternion.Lerp(
                    playerModel.transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
        }

        internal void ProcessJump(Rigidbody rb, float jumpSpeed)
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

        private void ProcessMoveLeft(Rigidbody rb, float movementSpeed)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector3(
                        -movementSpeed,
                        rb.velocity.y,
                        rb.velocity.z
                    );

                targetRotation = Quaternion.Euler(0, 270, 0);
            }
        }

        private void ProcessMoveRight(Rigidbody rb, float movementSpeed)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(
                        movementSpeed,
                        rb.velocity.y,
                        rb.velocity.z
                    );

                targetRotation = Quaternion.Euler(0, 90, 0);
            }
        }

        private void ProcessMoveForward(Rigidbody rb, float movementSpeed)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(
                        rb.velocity.x,
                        rb.velocity.y,
                        movementSpeed
                    );

                targetRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        private void ProcessMoveBackward(Rigidbody rb, float movementSpeed)
        {
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector3(
                        rb.velocity.x,
                        rb.velocity.y,
                        -movementSpeed
                    );

                targetRotation = Quaternion.Euler(0, 180, 0);
            }
        }

        private void CheckCanJump(
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
}
