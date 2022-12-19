using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool onElevator;
    [SerializeField] AudioClip getKeySound; 
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "elevator")
        {
            onElevator = true; 
            transform.parent = col.gameObject.transform;
            // GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
            //  GetComponent<Animator>().SetBool("onElevator", onElevator); 
        }
        if( col.gameObject.tag == "Key")
        {
            AudioSource.PlayClipAtPoint(getKeySound, col.transform.position); 
            FindObjectOfType<GameController>().currentKeysHave += 1;
            Destroy(col.gameObject); 

        }    
    }
    private void OnTriggerExit2D(Collider2D collision)

    {

        if (collision.gameObject.tag == "elevator")
        {
            transform.parent = null;
            onElevator = false; 
        }
    }

    private void Update()
    {
        GetComponent<Animator>().SetBool("onElevator", onElevator);

    }
}
