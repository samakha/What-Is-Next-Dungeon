using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class ChestScript : MonoBehaviour
{
    [SerializeField] AudioClip araSound; 
    [SerializeField] float delayTimeToLoadNextScene;

    public GameObject gameManager;
    public GameObject mainCamera; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if( collision.gameObject.tag == "Assassin")
        {
            if( FindObjectOfType<GameController>().canLoadNextLevel)
            {
                GetComponent<Animator>().SetTrigger("OpenChest");
                AudioSource.PlayClipAtPoint( araSound, mainCamera.transform.position, 10f); 
                
                collision.gameObject.GetComponent<PlayerMovement>().moveSpeed = 0f; 
                collision.gameObject.GetComponent<PlayerMovement>().isFacingRight = true;
                collision.gameObject.GetComponent<PlayerMovement>().isFacingRight = true;

                gameManager.GetComponent<AudioSource>().Stop(); 
                // move to next scene 
                // move to next scene 
                StartCoroutine(DelayExitGame());


            }
        }

    }
    IEnumerator DelayExitGame()
    {
        yield return new WaitForSeconds(delayTimeToLoadNextScene);


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
