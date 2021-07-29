using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    [SerializeField] private float moving = 1;
    [SerializeField] private float moveSpeed = 20;
    [SerializeField] private float jumpHeight = 10;

    private Rigidbody2D playerRB;

    [SerializeField] private bool isGrounded = true;
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
    }


    private void Movement()
    {
        moving = moveSpeed * (Input.GetAxisRaw("Horizontal"));

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.AddForce(Vector2.up * jumpHeight , ForceMode2D.Impulse);
            
        }
            
    }

    private void RigidContact()
    {
        //if
        //playerRB.GetContacts(null);
    }
    
    
    
}
