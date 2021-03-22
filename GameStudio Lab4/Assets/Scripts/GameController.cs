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
    public Text Hightext;
    public float highscore;
    public float score;

    public GameObject CameraGameObject;
    private Camera cam;

    public GameObject RadarSweeper;

    void Start()
    {
        round = 1;
        score = 0;
        isNight = false;
        RadarSweeper.SetActive(false);

        cam = CameraGameObject.GetComponent<Camera>();
        highscore = PlayerPrefs.GetFloat("HighScore");
        Hightext.text = "HighestScore:" + highscore;
    }

    void Update()
    {
        if (score > highscore )
        {
            highscore = score;
            Hightext.text = "HighestScore:" + score.ToString();

            PlayerPrefs.SetFloat("HighScore", highscore);
            PlayerPrefs.Save();
        }
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
            RadarSweeper.SetActive(true);
        }
        else
        {
            isNight = false;
            cam.backgroundColor = new Color(0, 0.09803922f, 0.4862745f);
            RadarSweeper.SetActive(false);
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

            GameObject enemy = (GameObject) Instantiate(enemySmall, spawnPosition, transform.rotation * Quaternion.Euler(0, 0, -180));
            enemy.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            // enemy.GetComponent<SpriteRenderer>().color = new Color(0.4325, 0.4325, 0.4325, 1);
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
