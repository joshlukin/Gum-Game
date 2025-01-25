using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;

public class playerMovement : MonoBehaviour
{
    [Header("Components")]

        private Rigidbody2D body;
        private BoxCollider2D hitbox;

        [Header("Movement Stats")]
        [SerializeField, Range(0f, 40f)][Tooltip("Maximum movement speed")] public float maxSpeed = 10f;
        [SerializeField, Range(0f, 40f)][Tooltip("Maximum jump speed")] public float jumpStrength = 10f;
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
        [SerializeField, Range(0f, 5f)]public float castLength;
        public bool onGround; 
        private float horizontal;
        
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate(){
        body.velocity = new Vector2(horizontal*maxSpeed, body.velocity.y);
        velocity = body.velocity;
        
        onGround = Physics2D.Raycast(transform.position, Vector2.down, castLength, LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * castLength, Color.red);

    }

     public void OnMovement(InputAction.CallbackContext value){
        horizontal = value.ReadValue<Vector2>().x;
        
    }
    public void OnJump(InputAction.CallbackContext ctx){
        Debug.Log("jump pressed");
        if(onGround){
            body.velocity = new Vector2(body.velocity.x, jumpStrength);
        }
    }
}
