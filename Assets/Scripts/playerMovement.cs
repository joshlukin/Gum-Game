using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;

public class playerMovement : MonoBehaviour
{
    [Header("Components")]

        private InputActions input = null;
        private Rigidbody2D body;
        private BoxCollider2D hitbox;

        InputAction moveAction;
        InputAction jumpAction;

        [Header("Movement Stats")]
        [SerializeField, Range(0f, 40f)][Tooltip("Maximum movement speed")] public float maxSpeed = 10f;
        [SerializeField, Range(0f, 100f)][Tooltip("How fast to reach max speed")] public float maxAcceleration = 52f;
        [SerializeField, Range(0f, 100f)][Tooltip("How fast to stop after letting go")] public float maxDecceleration = 52f;

        [Header("Options")]
        [Tooltip("When false, the charcter will skip acceleration and deceleration and instantly move and stop")] public bool useAcceleration;

        [Header("Calculations")]
        public float directionX;
        private Vector2 desiredVelocity;
        public Vector2 velocity;
        private float maxSpeedChange;
        private float acceleration;
        private float deceleration;
        private float turnSpeed;

        [Header("Current State")]
        public bool onGround;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
        input = new InputActions();
        

    }
    private void OnEnable(){
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void onDisable(){
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    void FixedUpdate(){
        velocity = body.velocity;
        body.velocity = desiredVelocity;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value){
        desiredVelocity = value.ReadValue<Vector2>()*maxSpeed;
        
    }
    private void OnMovementCancelled(InputAction.CallbackContext value){
        desiredVelocity = Vector2.zero;
    }
    

}
