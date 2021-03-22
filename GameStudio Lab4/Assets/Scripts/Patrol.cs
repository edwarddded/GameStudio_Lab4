using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{   
    public float speed;
    private float WaitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    //public Animator enemyani;
    public Text text;
    public float score;
    float life = 3;
    public GameObject enemyboss;
    public GameObject parachute;
    // Start is called before the first frame update
    void Start()
    {
        WaitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        
    }
    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 2f)
        {
            if (WaitTime <=0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                WaitTime = startWaitTime;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
        
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject parachute1 = (GameObject)(Instantiate(parachute, gameObject.transform.position, Quaternion.identity));
            playerscore();
            Destroy(parachute1,1);
            if (score <17)
            {
                GameObject enemy = (GameObject)(Instantiate(gameObject, new Vector2(Random.Range(-8f, 8f), Random.Range(-1f, 4.5f)), Quaternion.identity));
                enemy.GetComponent<SpriteRenderer>().flipY = true;
                enemy.GetComponent<Patrol>().enabled = true;
                enemy.GetComponent<Patrol>().speed = speed;
                enemy.GetComponent<CircleCollider2D>().enabled = true;
            }
            if (score == 16)
            {
                Instantiate(enemyboss, new Vector2(0.3f, 1.66f), Quaternion.identity);
            }
        }
        if (collision.gameObject.tag == "Bullet" && gameObject.tag == "enemyboos")
        {
            Destroy(collision.gameObject);
            life = life - 1;
                if (life == 0)
                {
                Destroy(gameObject);
                SceneManager.LoadScene(3);
            }
            
        }
    }
    void playerscore()
    {
        score++;
        text.text = "Score:" + score.ToString();
    }
}
