using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    // check for attack player 
    // shoot enemy 
    // instance bullet 

  //   [SerializeField] float distanceToAttack;

    public Transform shootPos;
    public Transform poinA;

    public float raycastRange;
    public float timeBTWShoot;
    public float currentTime; 
    Animator anim;
    public GameObject plantBullet;
    public LayerMask assassin; 

   public  bool plantShoot = false;
    void Start()
    {
       
            anim = GetComponent<Animator>();
        currentTime = timeBTWShoot;
    }
    private void Update()
    {
          anim.SetBool("plantShoot", plantShoot);
        
    }

    // Update is called once per frame
    private   void FixedUpdate()
    {
        if (currentTime <= 0)
        {


            RaycastHit2D ray;
            ray = Physics2D.Raycast(poinA.position, Vector2.left, raycastRange, assassin);
            if (ray.collider != null)
            {
                plantShoot = true;
            }
            else plantShoot = false;

            currentTime = timeBTWShoot; 
        } 
        else
        {
            currentTime -= Time.deltaTime; 
            plantShoot = false; 
        }
    }
  
    public void PlantShoot()
    {
        Instantiate(plantBullet, shootPos.position, Quaternion.identity);

    }
  
}


