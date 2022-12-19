using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    private float maxHealth;
    public Transform popUpPosition;
    public GameObject explosionEffect; 
    public HealthBarCtr healthBar;

    Animator anim;

    public AudioClip explosionAudio; 

    public GameObject floatText; 
    private void Start()
    {
        maxHealth = health;
        healthBar.SetHealth(health, maxHealth);
        anim = GetComponent<Animator>();
       
    }

    public void TakeDamage( int damage )
    {
        anim.SetTrigger("Hit");
        ShowDamageText("-" + damage.ToString()); 
        health -= damage;
        healthBar.SetHealth(health, maxHealth);

        if ( health <= 0 )
        {
         
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosionAudio , transform.position); 
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 0.7f);

           FindObjectOfType<GameController>().enemyGetKilled +=1;
           
        }
    }
    public void ShowDamageText( string text )
    {
        if( floatText)
        {
            GameObject textPreb = Instantiate(floatText, popUpPosition.position, Quaternion.identity);
            textPreb.GetComponentInChildren<TextMesh>().text = text; 
        }

    }
}
