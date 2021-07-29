using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    [SerializeField] private float moving = 1;
    [SerializeField] private float moveSpeed = 20;
    [SerializeField] private float jumpHeight = 10;

    private Rigidbody2D playerRB;
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
        Movement();
    }


    private void Movement()
    {
        moving = moveSpeed * (Input.GetAxisRaw("Horizontal"));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.velocity += jumpHeight * Vector2.up;
        }
            
    }
    
    
    
    
}
