using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anime;

    public Transform floorCheckTransform;
    public float speed;
    private bool jump;
    public float jumpForce;
    public float cutJumpVelocity;
    public bool Grounded;
    public float floorCheckRadius;
    public LayerMask whatIsGround;
    public float fallMultiplier;
    public float jumpUpMultiplier;

    public GameObject doubleJumpParticles;
    private int doubleJump = 1;

    public CutAttack attackScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        anime = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(9,10); //Player and Enemy
        Physics2D.IgnoreLayerCollision(9,11); //Player and Shuriken
    }

   void Update() {
       VerticalMovement();        
   }

    void FixedUpdate() {     
        HorizontalMovement();   
    }

    public void HorizontalMovement(){
        float xAxis = Input.GetAxisRaw("Horizontal");
        if (xAxis != 0 && !attackScript.isAttackin()){
            anime.SetBool("isWalking", true);
        }
        else{
            anime.SetBool("isWalking", false);
        }
   
        if (!attackScript.isAttackin()){
             rb.velocity = new Vector2(xAxis * speed, rb.velocity.y);
        }   
    }

    public void VerticalMovement(){  
        jump = Input.GetButtonDown("Jump");
        Grounded = Physics2D.OverlapCircle(floorCheckTransform.position, floorCheckRadius, whatIsGround);
        if(Grounded && doubleJump <= 0){
            doubleJump += 1;
        }
        if (Grounded && jump){
            rb.velocity = Vector2.up * jumpForce;
        }
        else if (doubleJump > 0 && jump){
            rb.velocity = Vector2.up * jumpForce;
            Instantiate(doubleJumpParticles, transform.position, doubleJumpParticles.transform.rotation);
            doubleJump -= 1;
        }

        if(!Grounded){
            anime.SetBool("isJumping", true);
        }
        else{
            anime.SetBool("isJumping", false);
        }

        //Gravity multiplier
        if (rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpUpMultiplier - 1) * Time.deltaTime;
        }

    }
}
