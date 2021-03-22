using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int round;
    public bool isNight;
    public GameObject enemySmall;
    public GameObject enemyLarge;

    public Text text;
    public float score;
    public GameObject CameraGameObject;
    private Camera cam;

    void Start()
    {
        round = 1;
        isNight = false;

        cam = CameraGameObject.GetComponent<Camera>();
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
        {
            isNight = true;
            cam.backgroundColor = new Color(0, 0, 0);
        }
        else
        {
            isNight = false;
            cam.backgroundColor = new Color(0, 0.09803922f, 0.4862745f);
        }

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

            Instantiate(enemySmall, spawnPosition, transform.rotation * Quaternion.Euler(0, 0, -180));
        }
        else{
            // otherwise spawn a regular enemy 
            Instantiate(enemySmall, spawnPosition, transform.rotation * Quaternion.Euler(0, 0, -180));
        }
    }

    public void AddToScore()
    {
        score++;
        text.text = "Score:" + score.ToString();
    }
}
