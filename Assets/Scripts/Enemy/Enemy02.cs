using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour
{
    // Start is called before the first frame update
    private int maxDis;
    private int minDis;
    public float rangeMove;
    public float wanderingSpeed;
    public bool isWandering ;
   

    public Transform player;
    public float distanceToAttack = 3f; 
    bool isFlipped = false;
  public bool isFacingRight = true; 
    Rigidbody2D rb;

    public LayerMask assassin;
    public LayerMask whatIsGround; 
    public Transform hitBox;
    public Transform groundCheckPos; 
    public float radius;
    public float radiusGroundCheck; 
    public int damage;
    public int distaceToPlayer;


    private void Start()
    {
        minDis = (int)(transform.position.x - rangeMove/2) ;
        maxDis = (int)(transform.position.x + rangeMove/2) ;
        rb = GetComponent<Rigidbody2D>();
    }
 
    public void LookAtPlayer() // chasing enemy
   {
        isWandering = false; 
        

        if (transform.position.x > player.position.x && isFacingRight)
        {
            FlipEnemy();
          
        }
        else if (transform.position.x < player.position.x && !isFacingRight)
        {
            FlipEnemy(); 
        }
    }

    public void EnemyWandering() // wandering 
    {
        rb.velocity = new Vector2(wanderingSpeed, rb.velocity.y) * Time.deltaTime; 
        //GetComponent<Animator>().SetBool("Attack", false); 
        isWandering = true;
        if (isFacingRight && transform.position.x <= maxDis)
        {
            rb.velocity = new Vector2(wanderingSpeed, rb.velocity.y) * Time.deltaTime;

        }
        else if (!isFacingRight && transform.position.x >= minDis)
        {
            rb.velocity = new Vector2(-wanderingSpeed, rb.velocity.y) * Time.deltaTime;

        }
        else if (transform.position.x > maxDis || transform.position.x < minDis)
        {
            FlipEnemy();
        }


        
    }
    private void FlipEnemy( )
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale; 
    }
    
      
      public void AttackPlayer( )
    {
        Collider2D col = Physics2D.OverlapCircle(hitBox.position, radius, assassin);
        if (col != null)
        {
            col.GetComponent<PlayerHealth>().PlayerGetDamage(damage);
        }
        else
            Debug.LogWarning("  player has dealth "); 
    }
    // using raycast to check ground


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitBox.position, radius);     
    }

}
    
   




