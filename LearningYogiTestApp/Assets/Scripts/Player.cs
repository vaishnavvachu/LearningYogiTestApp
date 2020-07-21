using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float jumpForce;

    private bool running, up, down, jumping;
    private Rigidbody2D playerRB;
    private Animator animator;



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
    void Update()
    {

        if (jumping == false)
        {

            Movement();

        }

        Jump();


    }

    void Movement()
    {

        animator.SetBool("Walking", true);

    }

    void Jump()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && playerRB.velocity.y == 0)
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
