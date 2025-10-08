using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float speed = 5.0f;
    public float jumpForce = 8.0f;
    public float airControlForce = 10.0f;
    public float airControlMax = 1.5f;

    public float jumpCount = 0.0f;

    public bool grounded;
    public bool onWall;
    // Use this for initialization
   
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        //check that player is grounded

        if (grounded)
        {
            if (Input.GetAxis("Jump") > 0.0f)
                rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            else
                rigidBody.linearVelocity = new Vector2(speed * h, rigidBody.linearVelocityY);
        }

        else
        {
            //allow air movement
            float vx = rigidBody.linearVelocityX;
            if (h * vx < airControlMax)
                rigidBody.AddForce(new Vector2(h * airControlForce, 0));
        }

        if (onWall)
            // experimenting with a wall bounce mechanic
        {
            if (Input.GetAxis("Jump") > 0.0f)
            {
                jumpCount = jumpCount + 1;
                rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            }

            else
            {
            
                    rigidBody.linearVelocity = new Vector2(speed * h, rigidBody.linearVelocityY);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            grounded = true;
        }

        else if (collision.gameObject.layer == 6)
        {
            onWall = true;
            //Debug.Log("onWall");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            grounded = false;
        }

        else if (collision.gameObject.layer == 6)
        {
            onWall = false;
            jumpCount = 0;
            //Debug.Log("offWall");
        }
    }
}
