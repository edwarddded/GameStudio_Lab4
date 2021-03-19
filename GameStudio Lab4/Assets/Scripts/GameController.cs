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

    public void enemyDestroyed()
    {
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
        if (round == 15)
        {
            // spawn large enemy 

        }
        else if (isNight)
        {
            // check to see if game is in night mode and spawn dark enemy

        }
        else
        {
            // otherwise spawn a regular enemy 

        }
    }

    public void gameOver()
    {
        // function is called when the player is hit
    }
}
