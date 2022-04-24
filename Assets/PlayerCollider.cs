using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
       if( col.gameObject.tag=="elevator")
        {
            transform.parent = col.gameObject.transform; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "elevator")
        {
            transform.parent = null; 
        }
    }
}
