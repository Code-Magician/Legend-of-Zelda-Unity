using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


namespace WP.Zelda.PlayerScripts
{
    public class PlayerView : MonoBehaviour
    {
        #region Fields

        [Header("References")]
        [SerializeField] Rigidbody rb;
        [SerializeField] GameObject model;

        [Header("Player Configurations")]
        [SerializeField] PlayerConfigurations playerConfs;

        private PlayerController controller;

        #endregion


        #region MonoBehaviour Functions

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            controller = new PlayerController();
        }

        void Update()
        {
            ProcessInputs();
        }

        #endregion


        #region Utility Functions

        private void ProcessInputs()
        {
            controller.ProcessMovement(rb, playerConfs.movementSpeed, playerConfs.movementKeyMap);
            controller.ProcessRotation(model, playerConfs.rotationSpeed);
            controller.ProcessJump(rb, playerConfs.jumpSpeed, playerConfs.jumpKey);
        }

        #endregion
    }
}
