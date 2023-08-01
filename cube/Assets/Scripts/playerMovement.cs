using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private int jumps = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new Vector2(dirX*7f, rb.velocity.y);
        
        if( Input.GetButtonDown("Jump") && (isGrounded || jumps >0)){

            if( !isGrounded){
                jumps--;
            }

            rb.velocity = new Vector2(rb.velocity.x,10);
            isGrounded = false;
        }       

    }


    private void OnCollisionEnter2D(Collision2D collision)  // uppercase O
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            Debug.Log(jumps);
            isGrounded = true;
            jumps = 1;
        }
    }
}
