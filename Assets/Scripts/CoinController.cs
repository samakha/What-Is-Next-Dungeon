using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public AudioClip pickUpCoin; 
    // Start is called before the first frame update
    [SerializeField] int pointOfCoin; 
    [SerializeField] int value;
    
    void Start()
    {
                   
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if( col.gameObject.tag=="Assassin")
        {

            FindObjectOfType<GameController>().PlayerPickUpCoin(pointOfCoin);
            AudioSource.PlayClipAtPoint(pickUpCoin, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
         
           
           
        }
    }
}