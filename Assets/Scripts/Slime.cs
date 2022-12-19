using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] int slimeDamage; 
    public Transform groundCheckPos;
    [SerializeField] LayerMask ground; 
    public float radius; 
    [SerializeField] float slimeMoveSpeed;
    GameObject player;
    public bool getHit;
    public bool patrol = true; 
    bool rayCheck; 
    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(slimeMoveSpeed, 0f);
        
        if( patrol) Patrol();
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Slime_Hit"))
        {
            patrol = false; 
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y); 
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(slimeMoveSpeed, 0f);
            patrol = true; 
        } 
            
        
    }
    private void FixedUpdate()
    {
         rayCheck = Physics2D.OverlapCircle(groundCheckPos.position, radius,ground ); 
     
    
    }
    void Patrol( )
    {
        if(!rayCheck  ) // slime does'nt patrol on ground and not getting hit 

        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            slimeMoveSpeed *= -1;  
        }
        if( getHit)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(slimeMoveSpeed, 0f);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPos.position, radius); 
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Assassin" )
        {
                GameObject.FindGameObjectWithTag("Assassin").GetComponent<PlayerHealth>().PlayerGetDamage(slimeDamage) ; 
        }
    }
}
