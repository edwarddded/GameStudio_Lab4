using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int round;
    public bool isNight;
    public GameObject enemySmall;
    public GameObject enemyLarge;

    void Start()
    {
        round = 1;
        isNight = false;
    }

    void Update()
    {
        
    }

    public void enemyDestroyed() {
        // Call this function in the enemy script when they are destroyed

        if (round == 15)
            round = 0;

        round += 1;

        if (round >= 6 && round <= 9)
            isNight = true;
        else 
            isNight = false;

        spawnNewEnemy();

    }

    private void spawnNewEnemy()
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(Screen.height/2, Screen.height), Camera.main.farClipPlane / 2));
        if (round == 15)
        {
            
            Instantiate(enemyLarge, spawnPosition, transform.rotation * Quaternion.Euler(0, 0, -180));

        }
        else if(isNight){
            // check to see if game is in night mode and spawn dark enemy

        }
        else{
            // otherwise spawn a regular enemy 
            Instantiate(enemySmall, spawnPosition, transform.rotation * Quaternion.Euler(0, 0, -180));
        }
    }

    public void gameOver()
    {
        // function is called when the player is hit
    }
}
