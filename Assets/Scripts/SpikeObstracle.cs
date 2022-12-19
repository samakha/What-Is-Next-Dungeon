using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeObstracle : MonoBehaviour
{
    [SerializeField] int damage;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag=="Assassin")
        {
            collision.GetComponent<PlayerHealth>().PlayerGetDamage(damage);
         //     Debug.Log(collision.GetComponent<PlayerHealth>().health);

            
        }
    }


}
