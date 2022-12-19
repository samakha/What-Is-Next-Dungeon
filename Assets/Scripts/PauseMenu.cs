using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    
    public GameObject PauseMenuUI;
    public bool isPaused; 

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Escape))
        {
            if( isPaused)
                   Resume();  
               
          
            else
                Pause(); 
            
        }
    }

    public void Pause()
    { 
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true; 
      
    }
    public void Resume( )
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        isPaused = false; 
       
    }
    public void MenuScene( )
    {
        SceneManager.LoadScene("Menu Scene");
        Time.timeScale = 1f;
    }
    public void QuitGame( )
    {
        Application.Quit(); 
    }
    public void PlayAgain( )
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; 
    }
}
