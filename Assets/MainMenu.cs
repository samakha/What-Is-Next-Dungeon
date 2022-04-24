using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioClip audioClick; 
    
    public void PlayButton()
        {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioSource.PlayClipAtPoint(audioClick , transform.position); 
        }

    public void OptionButton( )
    {
        AudioSource.PlayClipAtPoint(audioClick, transform.position);
    }
    public void ExitButton()
    {
        AudioSource.PlayClipAtPoint(audioClick, transform.position);
        Application.Quit(); 
    }
}
