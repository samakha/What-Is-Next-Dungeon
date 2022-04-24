using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    [SerializeField] int bulletDirection =1; 
    Rigidbody2D bulletBody;

    [SerializeField] int damage; 

    public GameObject exploseEffection;

    private void Start()
    {
        bulletBody = GetComponent<Rigidbody2D>();
      
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       bulletBody.velocity = new Vector2( bulletDirection * bulletSpeed, 0f); 
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Assassin") // touching player 
        {
           GameObject objecToDestroy =  Instantiate(exploseEffection, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(objecToDestroy,0.5f);
            col.GetComponent<PlayerHealth>().PlayerGetDamage(damage); 
        }
        if(col.gameObject.tag=="Wall")
        {
            Destroy(gameObject); 
        }
    }
}
