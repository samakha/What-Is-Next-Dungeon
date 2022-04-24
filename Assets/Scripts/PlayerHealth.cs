using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement; 
public class PlayerHealth : MonoBehaviour
{
    public int health;
    private int maxHealth; 
    [SerializeField] AudioClip getHurtAudio;

    public Slider playerHealthBar;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI enemyScoreText; 

   public GameController gameController; 
    private void Start()
    {
        maxHealth = health;
       
       
    }
    private void Update()
    {
        playerHealthBar.value = health;
        keysText.text = ("Keys : " + gameController.currentKeysHave.ToString() + "/" + gameController.keysAtScene.ToString());
        enemyScoreText.text = ("Enemy : " + gameController.enemyGetKilled.ToString() + "/" + gameController.enemyMustKill.ToString()); 
    }
    public void PlayerGetDamage( int damage )
    {
        
        playerHealthBar.maxValue = maxHealth; 
        GetComponent<Animator>().SetTrigger("Hit");
        AudioSource.PlayClipAtPoint(getHurtAudio, transform.position);
        health -= damage; 
        if( health <=0)

        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
            
        }
    }
}
