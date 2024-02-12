using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WP.Zelda.PlayerScripts
{ 
    public class PlayerController
    {
        #region Business Methods

        internal void ProcessMovement(Rigidbody rb, float movementSpeed, MovementKeyMap movementKeyMap)
        {
            if(Input.GetKey(movementKeyMap.forward))
            {
                Movement.MoveForward(rb, movementSpeed);
            }
            else if (Input.GetKey(movementKeyMap.backward))
            {
                Movement.MoveBackward(rb, movementSpeed);
            }
            else if (Input.GetKey(movementKeyMap.right))
            {
                Movement.MoveRight(rb, movementSpeed);
            }
            else if (Input.GetKey(movementKeyMap.left))
            {
                Movement.MoveLeft(rb, movementSpeed);
            }
        }

        internal void ProcessRotation(GameObject playerModel, float rotationSpeed)
        {
            Movement.Rotate(playerModel, rotationSpeed);
        }

        internal void ProcessJump(Rigidbody rb, float jumpSpeed)
        {
            Movement.Jump(rb, jumpSpeed);
        }

        #endregion
    }
}
