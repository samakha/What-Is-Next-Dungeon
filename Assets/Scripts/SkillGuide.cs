using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGuide : MonoBehaviour
{

    [SerializeField] GameObject dialogBox;

    private void Start()
    {
        dialogBox.SetActive(false); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Assassin")
        {
            dialogBox.SetActive(true); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Assassin")
        {
            dialogBox.SetActive(false);
        }
    }
}
