using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMoveInfo : MonoBehaviour
{
    //PHYSIC DATA
    public float speedValue = 10f;
    public float jumpForce = 27f;
    //wJump
    //public float coolDownTime = 0.5f;
    //public float slidingTime = 0.2f;
    //public float slidingStop = 0;
    //public float nextJumpTime = 0;
    public float slideSpeed = 0;


    //PHYSICS
    public float moveInput;
    public Rigidbody2D rigidBody;
    public Animator animPlayer;
    //wJump
    private Collider2D collision;
    public GroundChecker gCheck;

    //CHECK
    public bool facingRight = true;
    //wJump
    public bool canClimb;
    public bool canWallJump;







}

public class PlayerMovement : PlayerMoveInfo
{




    
    void Start()
    {

        //gCheck.extraJumps = gCheck.extraJumpsValue;
        rigidBody = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }

    
    void Update()
    {
        ClimbCondition();

        JumpCondition();
        

    }

    void FixedUpdate()
    {

        Walk();

        Freeze();

        FlipCondition();

    }



    public void Walk()
    {
        moveInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(moveInput * speedValue, rigidBody.velocity.y);
        animPlayer.SetFloat("Running", Mathf.Abs(moveInput));
    }

    public void FlipCondition()
    {
        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Freeze()
    {
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    //логика прыжка

    /*private void DoJump()
    {
        rigidBody.velocity = Vector2.up * jumpForce;
    }*/


    private void JumpCondition()
    {
        if ((gCheck.isGrounded || canWallJump) && Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            //animPlayer.SetBool("IsJumping", true);
        }

        else if (gCheck.isGrounded == false)
        {
            animPlayer.SetBool("IsJumping", true);
        }

        else if (gCheck.isGrounded == true)
        {
            animPlayer.SetBool("IsJumping", false);
            animPlayer.SetBool("IsClimbing", false);
        }



    }

    private void ClimbCondition()
    {
        if (Input.GetKey(KeyCode.J) && canClimb && !gCheck.isGrounded)
        {
            animPlayer.SetBool("IsJumping", false);
            animPlayer.SetBool("IsClimbing", true);
            canWallJump = true;
            rigidBody.velocity = new Vector2(0, slideSpeed);
        }

        else
        {
            canWallJump = false;
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            animPlayer.SetBool("IsClimbing", false);
            canClimb = false;
        }

    }




}
