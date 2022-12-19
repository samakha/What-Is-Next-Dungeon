using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Walk : StateMachineBehaviour
{
    
    // boss wandering
    // boss move to  player 
    Transform player;
    Rigidbody2D rb;


    private bool isWandering; 
    bool isChasing;
    
    [SerializeField] float chasingSpeed;
    [SerializeField] float distanceToAttack  ;
  
    Enemy02 enemy02;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Assassin").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy02 = animator.GetComponent<Enemy02>();
        isWandering = true; 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (Vector2.Distance(this.rb.position, player.position) <= distanceToAttack) // attack 
        {
            animator.SetBool("Attack", true);
            enemy02.LookAtPlayer();
            
            Vector2 target = new Vector2(player.position.x - 1f, rb.position.y);
            Vector2 movePos = Vector2.MoveTowards(rb.position, target, chasingSpeed * Time.deltaTime);
             
            rb.MovePosition(movePos);

        }
     

        else if (isWandering)
        {
            enemy02.EnemyWandering();
        }
    
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
        isWandering = true; 
    }
    
    
}
