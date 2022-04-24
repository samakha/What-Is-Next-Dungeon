using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float maxX, minX; 
    [SerializeField]  float rangeDetect;
    [SerializeField] float rangeAttack;

    Rigidbody2D rb;
    GameObject player; 

    bool isFacingRight = true; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Assassin"); 
    }

    // Update is called once per frame
    void Update() // patrol 
                 // get hit /
                 // detect 
                 // attack 
                          
    {
        Patrol(); 
        PlayerMovement();
        CheckForFlip(); 
    }

    private void Patrol( )
    {
       
    }
    private void PlayerMovement( )
    {
            if( isFacingRight)
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); 
        }
    }
    private void CheckForFlip( )
    {

        if( transform.position.x >maxX || transform.position.x < minX   )
        {
            transform.rotation = Quaternion.Euler(0f , 180f, 0f);
            isFacingRight = !isFacingRight; 
        }
  
    }
}
