using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    PlayerMovement player;

    
    [SerializeField] int damage; 
    bool right; 

    void Start()
    {


        if (GameObject.FindGameObjectWithTag("Assassin").transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            right = true; 
        }

        if (GameObject.FindGameObjectWithTag("Assassin").transform.localScale.x < 0)
        {
            transform.localScale = new Vector2( -transform.localScale.x, transform.localScale.y);
            right = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); 
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        Destroy(gameObject, 0.25f ); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if( collision.tag=="Enemy")
        {
            Destroy(gameObject); 
            collision.GetComponent<EnemyHealth>().TakeDamage(damage); 
        }
        if( collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
