using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WP.Zelda.PlayerScripts
{
    [Serializable]
    public class PlayerConfigurations
    {
        [Header("Movement")]
        public float movementSpeed;
        public float jumpSpeed;
        public float rotationSpeed;
        public MovementKeyMap movementKeyMap;
        public KeyCode jumpKey;
    };

    [Serializable]
    public class MovementKeyMap
    {
        public KeyCode forward, backward, right, left;
    }
}
