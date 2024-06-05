using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public float Acceleration;
    public Vector2 MaxSpeed;
    public float JumpStrength;
    private Rigidbody2D rb;
    public bool IsGrounded;
    public bool canChangeDirection;
    public bool QueuedDirectionSwap;
    private bool justJumped;
    public bool moveDirectionLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (new Vector2(Acceleration*Time.deltaTime, rb.velocity.y));

        EnforceVelocity();
    }
    private void EnforceVelocity()
    {
        Vector2 speed = Vector2.zero;
        speed.x = Mathf.Clamp(rb.velocity.x, -MaxSpeed.x, MaxSpeed.x);
        speed.y = Mathf.Clamp(rb.velocity.y, -MaxSpeed.y, MaxSpeed.y);
        rb.velocity = speed;
    }
    private void OnJumpLeft()
    {
        if (!IsGrounded) return;
        Acceleration = -Mathf.Abs(Acceleration);
        rb.AddForce(Vector2.up * JumpStrength);
    }
    private void OnJumpRight()
    {
        if (!IsGrounded) return;
        Acceleration = Mathf.Abs(Acceleration);
        rb.AddForce(Vector2.up * JumpStrength);
    }

    private void OnMoveLeft()
    {
        moveDirectionLeft = true;
        if (IsGrounded) EnforceMoveDirection();
    }
    private void OnMoveRight()
    {
        moveDirectionLeft = false;
        if(IsGrounded) EnforceMoveDirection();
    }

    public void EnforceMoveDirection()
    {
        if (moveDirectionLeft)
        {
            Acceleration = -Mathf.Abs(Acceleration);
        }
        if(!moveDirectionLeft) Acceleration = Mathf.Abs(Acceleration);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == gameObject.name || collision.isTrigger) return;
        IsGrounded = true;
        EnforceMoveDirection();
        print("Entered Ground");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == gameObject.name || collision.isTrigger) return;
        IsGrounded = false;
        print("Left Ground");
        
    }
}
