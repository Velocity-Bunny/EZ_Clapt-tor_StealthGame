using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor.Sprites;

using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    protected bool canHide;

    [SerializeField] protected float moving = 1;
    [SerializeField] protected float moveSpeed = 7;
    [SerializeField] protected float jumpHeight = 10;
    protected Rigidbody2D playerRB;

    private Collider2D playerColl;

    //[SerializeField] protected Collider2D wallCol; // you have to set up the collider in the inpsector
    //[SerializeField] protected Collider2D groundCol; // you have to set up the collider in the inpsector
    [SerializeField] protected Collider2D hidingCol; // you have to set up the collider in the inpsector
    public SpriteRenderer playerSprite;

    private bool isMoving = false;

    [SerializeField] protected bool isGrounded = false;

    [SerializeField] protected Transform raycastPos;

    //private Collider2D playerCol;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        raycastPos = GetComponent<Transform>();
        playerColl = GetComponent<Collider2D>();
        playerSprite = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new Vector2(moving, playerRB.velocity.y);
        Movement();
        Hide();

    }

    /// <summary>
    /// Handles player movement
    /// </summary>
    protected void Movement()
    {
        moving = moveSpeed * (Input.GetAxisRaw("Horizontal"));

        if(moving >= 1)
            isMoving = true;
        //speed up the player after a few seconds of moving

        if(moving <= 15 && isMoving)
        {
            // moving += 0.5f * Time.deltaTime;
            moving += Mathf.Lerp(0, moveSpeed * Input.GetAxisRaw("Horizontal"), 0.2f);

        }

        // horizontal movement



        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);

        }

    }


    protected void Hide()
    {

       // if(playerColl.IsTouching(hidingCol))
       // {
        //    if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //    {
                //playerColor.a = 0.25f;
                // Debug.Log("Yes");
       //     }
       // }
       if(canHide)
       {
           if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
           {
               playerSprite.color = new Color(1, 1, 1, 0.25f);
               Debug.Log("changed alpha");
           }
           else if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
           {
               playerSprite.color = new Color(1, 1, 1, 1f);
           }
       }

    }


    protected void OnCollisionEnter(Collision _collision)
    {
        if(_collision.collider.CompareTag("Ground"))
            isGrounded = true;
        else
            isGrounded = false;

        

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Color playerColor = playerSprite.color;

        if(other.CompareTag("HidingSpot"))
        {
            canHide = true;
        }
        else
        {
            canHide = false;
            playerColor.a = 1;
        }
            
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("HidingSpot"))
        {
            canHide = false;
        }
    }
}



