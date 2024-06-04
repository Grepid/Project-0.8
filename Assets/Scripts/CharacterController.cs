using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class CharacterController : MonoBehaviour
{
    public float Acceleration;
    public Vector2 MaxSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 100);
        }
        rb.AddForce(new Vector2(Acceleration*Time.deltaTime, 0));

        EnforceVelocity();
        print(rb.velocity);
    }

    public void AddVelocity(Vector2 force)
    {
        
    }
    private void EnforceVelocity()
    {
        Vector2 speed = Vector2.zero;
        speed.x = Mathf.Clamp(rb.velocity.x, -MaxSpeed.x, MaxSpeed.x);
        speed.y = Mathf.Clamp(rb.velocity.y, -MaxSpeed.y, MaxSpeed.y);
        rb.velocity = speed;
    }
}
