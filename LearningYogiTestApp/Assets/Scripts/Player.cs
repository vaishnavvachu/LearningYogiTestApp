using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Player movement control and 
public class Player : MonoBehaviour
{
    
    public float jumpForce;                                    //how high should he jump?

    private bool running, up, down, jumping;
    private Rigidbody2D playerRB;
    private Animator animator;                                  //attach the animator controller to the player gameobject
    
    // Use this for initialization
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        running = false;
        up = false;
        down = false;
        jumping = false;

    }

    // Update is called once per frame
    //Keep the player walking until he jumps
    void Update()
    {

        if (jumping == false)
        {

            Movement();

        }

        Jump();
        
    }

    //show the walk animation
    void Movement()
    {

        animator.SetBool("Walking", true);

    }

    //Show Jump Up animation when player taps on screen
    //jump Up
    //come down
    //continue walking
    void Jump()
    {
        //Jump
        if (Input.GetButton("Fire1") && playerRB.velocity.y == 0)
        {
            playerRB.AddForce(new Vector2(0, jumpForce));

        }

        //Jump Animation
        if (playerRB.velocity.y > 0 && up == false)
        {
            up = true;
            jumping = true;
            animator.SetTrigger("Up");
        }
        else if (playerRB.velocity.y < 0 && down == false)
        {
            down = true;
            jumping = true;
            animator.SetTrigger("Down");
        }
        else if (playerRB.velocity.y == 0 && (up == true || down == true))
        {
            up = false;
            down = false;
            jumping = false;
            animator.SetTrigger("Ground");
        }
    }




}
