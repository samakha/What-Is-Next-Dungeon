using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HealthBarCtr : MonoBehaviour
{
    public Slider slider;
  
    public void SetHealth(float health, float maxHealth)
    {
     
     //   {
     //       slider.gameObject.SetActive(false); 
     //   }
        slider.value = health;
        slider.maxValue = maxHealth;
    }
  


}