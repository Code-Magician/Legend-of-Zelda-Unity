using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WP.Zelda.Player
{
    [Serializable]
    public class PlayerConfigurations
    {
        [Header("Movement")]
        public float movementSpeed;
        public float jumpSpeed;
        public float rotationSpeed;
    }
}
