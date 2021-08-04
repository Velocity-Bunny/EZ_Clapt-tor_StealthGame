using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    
    [SerializeField] protected float moving = 1;
    [SerializeField] protected float moveSpeed = 20;
    [SerializeField] protected float jumpHeight = 10;
    protected Rigidbody2D playerRB;
    [SerializeField] protected Collider2D wallCol; // you have to set up the collider in the inpsector
    [SerializeField] protected Collider2D groundCol; // you have to set up the collider in the inpsector


    [SerializeField] protected bool isGrounded = true;
    //private Collider2D playerCol;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        //playerCol = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new Vector2(moving, playerRB.velocity.y);
        Movement();
        ContactMe();
    }

    /// <summary>
    /// Handles player movement
    /// </summary>
    protected void Movement()
    {
        // horizontal movement
        moving = moveSpeed * (Input.GetAxisRaw("Horizontal"));

        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.AddForce(Vector2.up * jumpHeight , ForceMode2D.Impulse);
            
        }
            
    }


    protected void ContactMe()
    {
        if(playerRB.IsTouching(groundCol))
        {
            isGrounded = true;
        }
        else
            isGrounded = false;
    }
    
    
    
}
