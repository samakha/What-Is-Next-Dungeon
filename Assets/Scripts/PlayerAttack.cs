using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
     // public bool canAttack = true ;
        public Transform hitBoxPos;
    public int damage = 10; 

    [SerializeField] LayerMask Enemy;
    [SerializeField] AudioClip strikeClip;
    [SerializeField] AudioClip shootingClip; 
    public float radius;
    public bool canShoot;  
    Animator anim;


    public GameObject playerProjectiles;
    public Transform firePoint; 
    public float attackTime;
    public float startTimeAttack; 

    private void Start()
    {
        attackTime = startTimeAttack; 
        anim = GetComponent<Animator>(); 
    }
    private void Update()
    {

        if (Input.GetButtonDown("Fire2")) // press F to shoot 
        {
            anim.SetTrigger("Shoot"); 
             
        }    
        if ( attackTime <=0)
        {


            if (Input.GetButtonDown("Fire1") && GetComponent<PlayerMovement>().isGround) 
            {


                Attack(); 

               attackTime = startTimeAttack; 
            } 
            
        }   
       else
            {
                attackTime -= Time.deltaTime;
                anim.SetBool("Attack", false); 
            }

    
    }
    void Attack( )
    {
        anim.SetBool("Attack", true);

        Collider2D[] attackEnemy = Physics2D.OverlapCircleAll(hitBoxPos.position, radius, Enemy);
        foreach (Collider2D enemy in attackEnemy)
        {
            if (enemy.GetComponent<EnemyHealth>().health > 0)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
                Debug.Log("hit ");

            }


        }
    }
    public void ShootingBullet( )
    {
        Instantiate(playerProjectiles, firePoint.position, firePoint.rotation );
        AudioSource.PlayClipAtPoint(shootingClip, transform.position); 
    }
    public void PlayClip()
    {
            AudioSource.PlayClipAtPoint(strikeClip, transform.position); 
    }
    private void OnDrawGizmos()
    {
      //  Gizmos.DrawWireSphere(hitBoxPos.position, radius); 
    }
}
