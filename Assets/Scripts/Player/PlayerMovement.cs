using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // jump , run , idle // sound 

     public float moveSpeed;
    public float AttackMoveSpeed; 
     public float defaultSpeed ; 
    [SerializeField] float jumpForce;
    [SerializeField] float radius;
    private float moveInput;


    Rigidbody2D rb;
    Animator anim;

    public bool isFacingRight = true;
    public bool isGround;
    public bool isFalling;
    public bool canJump;

    public LayerMask whatIsGround;

    public Transform groundCheck;
    void Start()
    {
        moveSpeed = defaultSpeed; 
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal") ;
        rb.velocity = new Vector2(moveInput * moveSpeed * Time.deltaTime, rb.velocity.y);

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_Attack(s2)") || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerShoot"))
        {
            rb.velocity = new Vector2(AttackMoveSpeed * moveInput * Time.deltaTime, rb.velocity.y);
        }
        CheckForFlip();
        AnimationController();
        PlayerJump();
        PlayerFalling();
    }
    private void FixedUpdate()
    {
        CheckForGround();
    }
    void CheckForFlip()
    {
        if (isFacingRight && moveInput < 0 || !isFacingRight && moveInput > 0)
        { FlipPlayer(); }
    }
    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void AnimationController()
    {
        anim.SetFloat("VelocityX", Mathf.Abs(rb.velocity.x));
        anim.SetBool("canJump", canJump);
        anim.SetBool("isFalling", isFalling);
        anim.SetBool("isGround", isGround);
        // anim.SetFloat("VelocityY", rb.velocity.y); 
    }
    void PlayerJump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown( KeyCode.W)) && (isGround || GetComponent<PlayerCollision>().onElevator))



        {
            canJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
       
        if (rb.velocity.y > 0 && !isGround) canJump = true;  
        else canJump = false; 
              
    }
    
  
    void PlayerFalling( )
    {
        if (rb.velocity.y < 0 && !isGround) isFalling = true; 
            
    }
    void CheckForGround()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);
        if (isGround)
        {
          
            isFalling = false;
            
        }
        
    }
    // check move on elevator
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius); 
    }

    
}
