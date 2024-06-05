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
    private bool isGrounded;
    public bool canChangeDirection;
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
    private void OnJump()
    {
        if (!isGrounded) return;
        rb.AddForce(Vector2.up * JumpStrength);
    }

    public void InvertMove()
    {
        if (!canChangeDirection) return;
        print("Swapped direction");
        Acceleration *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == gameObject.name || collision.isTrigger) return;
        isGrounded = true;
        InvertMove();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == gameObject.name || collision.isTrigger) return;
        isGrounded = false;
        InvertMove();
    }
}
