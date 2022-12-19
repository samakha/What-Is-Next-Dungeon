using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int currentGold;
    public int enemyGetKilled;  
    public int enemyMustKill; 

    public int keysAtScene;  // key to pass the scene 
    public int currentKeysHave = 0;

    public bool canLoadNextLevel = false ; 
    void Start()
    {
        enemyGetKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if( currentKeysHave >= keysAtScene && enemyGetKilled >=enemyMustKill)
        {
            canLoadNextLevel = true; 
        }
    }
    public void PlayerPickUpCoin( int coin)
    {
        currentGold += coin;
        Debug.Log("current coint " + currentGold);  
    }
    
}
