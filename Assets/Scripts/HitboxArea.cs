using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxArea : MonoBehaviour
{
    PlantController plant;
    private void Start()
    {
        plant = GetComponent<PlantController>(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Assassin")
        {
            plant.plantShoot = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Assassin")
        {
            plant.plantShoot = true;
        }
    }
}
