using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ExitGate : MonoBehaviour
{
    [SerializeField] float waitDelayTime; 
    [SerializeField] int goldToLoadNextLevel ; 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if( col.gameObject.tag=="Assassin")
        {
          if(  FindObjectOfType<GameController>().canLoadNextLevel) 
            StartCoroutine(LoadNextScene());
            
        }
    }
    IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(waitDelayTime);
        Debug.Log(SceneManager.GetActiveScene().buildIndex); 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1); 
    }
}
